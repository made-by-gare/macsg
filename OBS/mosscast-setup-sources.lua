---@diagnostic disable-next-line: undefined-global
local obs = obslua

local SOURCES = {}
local SOURCE_PREFIX = "MossCast - %02d - "
local SOURCE_SUFFIX_CAPTURE = "Capture"
local SOURCE_SUFFIX_NAME = "Name"
local SOURCE_SUFFIX_PRONOUNS = "Pronouns"
local SOURCE_SUFFIX_SCORE = "Score"

local mosscast_num_streams = 0
local mosscast_width = 0
local mosscast_height = 0
local mosscast_active_streams = 0
local mosscast_dir = ""
local mosscast_scene_add_capture = false
local mosscast_scene_add_name = false
local mosscast_scene_add_pronouns = false
local mosscast_scene_add_score = false


local function isempty(s)
    return s == nil or s == ''
end

local function split(str, delim)
    local out = {}
    for part in string.gmatch(str, "([^" .. delim .. "]+)") do
        table.insert(out, part)
    end

    return out
end

local function get_or_create_source(name, type)
    local source = SOURCES[name]
    if source == nil then
        print(string.format("Failed to find source (%s) in cache", name))
        source = obs.obs_get_source_by_name(name)
    end

    if source == nil then
        print(string.format("Failed to find source (%s). Creating.", name))
        source = obs.obs_source_create(type, name, nil, nil)
    end

    if SOURCES[name] == nil then
        SOURCES[name] = source
    end

    return source
end

local function create_or_update_game_capture_source(name, idx)
    local settings = obs.obs_data_create()
    obs.obs_data_set_string(settings, "capture_mode", "window")
    obs.obs_data_set_string(settings, "window",
        string.format("Stream%02d - VLC media player:Qt5QWindowIcon:vlc.exe", idx))

    local source = get_or_create_source(name, "game_capture")
    obs.obs_source_reset_settings(source, settings)

    obs.obs_data_release(settings)
end

local function create_or_update_text_source(name, filepath, size)
    -- Ensure file exists
    local handle, err = io.open(filepath, "a+")
    if err ~= nil then
        print(string.format("Failed to ensure file (%s) exists: %s", filepath, err))
        return
    end
    if handle ~= nil then
        handle:close()
    end

    local font_settings = obs.obs_data_create()
    obs.obs_data_set_string(font_settings, "face", "Arial")
    obs.obs_data_set_string(font_settings, "style", "Regular")
    obs.obs_data_set_int(font_settings, "size", size)
    obs.obs_data_set_int(font_settings, "flags", 0)

    local settings = obs.obs_data_create()
    obs.obs_data_set_bool(settings, "read_from_file", true)
    obs.obs_data_set_string(settings, "file", filepath)
    obs.obs_data_set_bool(settings, "outline", true)
    obs.obs_data_set_int(settings, "outline_color", 4278190080)
    obs.obs_data_set_int(settings, "outline_size", 2)
    obs.obs_data_set_obj(settings, "font", font_settings)

    local source = get_or_create_source(name, "text_gdiplus_v2")
    obs.obs_source_reset_settings(source, settings)

    obs.obs_data_release(settings)
    obs.obs_data_release(font_settings)
end

local function print_source_details(name)
    local source = obs.obs_get_source_by_name(name)
    if source == nil then
        print "No such source"
        return
    end

    print("ID: " .. obs.obs_source_get_id(source))
    local settings = obs.obs_source_get_settings(source)
    print("Settings" .. obs.obs_data_get_json(settings))

    obs.obs_source_release(source)
end

local function mosscast_sync(props, property, data)
    if isempty(mosscast_dir) then
        print("MossCast AppData Directory not set...")
        return
    end

    for idx = 1, mosscast_num_streams do
        local prefix = string.format(SOURCE_PREFIX, idx)
        create_or_update_game_capture_source(prefix .. SOURCE_SUFFIX_CAPTURE, idx)
        create_or_update_text_source(prefix .. SOURCE_SUFFIX_NAME,
            string.format("%s/streamer-%02d.txt", mosscast_dir, idx), 72)
        create_or_update_text_source(prefix .. SOURCE_SUFFIX_PRONOUNS,
            string.format("%s/streamer-pronouns-%02d.txt", mosscast_dir, idx), 64)
        create_or_update_text_source(prefix .. SOURCE_SUFFIX_SCORE, string.format("%s/score-%02d.txt", mosscast_dir, idx),
            72)
    end
end

local function add_source(scene, name)
    if obs.obs_scene_find_source_recursive(scene, name) ~= nil then
        return
    end
    local source = SOURCES[name]
    if source == nil then
        return
    end

    obs.obs_scene_add(scene, source)
end

local function add_source_for_streams(scene, name, should_run)
    if not should_run then
        return
    end
    add_source(scene, name)
end

local function mosscast_add(props, property, data)
    local scene_source = obs.obs_frontend_get_current_scene()
    if scene_source == nil then
        return
    end
    local scene = obs.obs_scene_from_source(scene_source)
    if scene == nil then
        return
    end

    for idx = mosscast_num_streams, 1, -1 do
        local prefix = string.format(SOURCE_PREFIX, idx)
        add_source_for_streams(scene, prefix .. SOURCE_SUFFIX_SCORE, mosscast_scene_add_score)
        add_source_for_streams(scene, prefix .. SOURCE_SUFFIX_PRONOUNS, mosscast_scene_add_pronouns)
        add_source_for_streams(scene, prefix .. SOURCE_SUFFIX_NAME, mosscast_scene_add_name)
        add_source_for_streams(scene, prefix .. SOURCE_SUFFIX_CAPTURE, mosscast_scene_add_capture)
    end
end

local function get_streamers(scene)
    local streamers = {}

    local items = obs.obs_scene_enum_items(scene)
    for idx, item in ipairs(items) do
        local source = obs.obs_sceneitem_get_source(item)
        local name = obs.obs_source_get_name(source)
        local parts = split(name, "-")
        if #parts == 3 and parts[1] == "MossCast " then
            local stream_idx = tonumber(string.format("%d", parts[2]:gsub("%s+", "")))
            if stream_idx ~= nil then
                if streamers[stream_idx] == nil then
                    streamers[stream_idx] = {}
                end
                table.insert(streamers[stream_idx], name)
            end
        end
    end
    obs.sceneitem_list_release(items)

    return streamers
end


local function mosscast_organize_capture(scene, stream_idx, source_name)
    local sceneitem = obs.obs_scene_find_source(scene, source_name)
    if sceneitem == nil then
        return
    end

    local columns = math.ceil(math.sqrt(mosscast_active_streams))
    local rows = math.ceil(mosscast_active_streams / columns)
    local padding_width = mosscast_width / columns * 0.2
    local padding_height = mosscast_height / rows * 0.2

    local bounds = obs.vec2()
    bounds.x = mosscast_width / columns - padding_width
    bounds.y = bounds.x / 16 * 9

    local pos = obs.vec2()
    if stream_idx > mosscast_active_streams then
        pos.x = mosscast_width + 10
        pos.y = 0
    else
        pos.x = (stream_idx - 1) % columns * (bounds.x + padding_width) + (padding_width / 2)
        pos.y = math.floor((stream_idx - 1) / columns) * (bounds.y + padding_height) + (padding_height / 2)
    end

    obs.obs_sceneitem_set_pos(sceneitem, pos)
    obs.obs_sceneitem_set_bounds_type(sceneitem, obs.OBS_BOUNDS_SCALE_INNER)
    obs.obs_sceneitem_set_bounds(sceneitem, bounds)
end



local function mosscast_organize_text(scene, stream_idx, source_name, text_idx)
    local sceneitem = obs.obs_scene_find_source(scene, source_name)
    if sceneitem == nil then
        return
    end

    local columns = math.ceil(math.sqrt(mosscast_active_streams))
    local rows = math.ceil(mosscast_active_streams / columns)
    local padding_width = mosscast_width / columns * 0.2
    local padding_height = mosscast_height / rows * 0.2

    local bounds_x = mosscast_width / columns - padding_width
    local bounds_y = bounds_x / 16 * 9


    local pos = obs.vec2()
    if stream_idx > mosscast_active_streams then
        pos.x = mosscast_width + 10
        pos.y = 0
    else
        pos.x = (stream_idx - 1) % columns * (bounds_x + padding_width) + (padding_width / 2)
        pos.y = math.floor((stream_idx - 1) / columns) * (bounds_y + padding_height) + (padding_height / 2) +
            (text_idx * 80)
    end

    obs.obs_sceneitem_set_pos(sceneitem, pos)
end



local function mosscast_organize(props, property, data)
    local scene_source = obs.obs_frontend_get_current_scene()
    if scene_source == nil then
        return
    end
    local scene = obs.obs_scene_from_source(scene_source)
    if scene == nil then
        return
    end


    local streamers = get_streamers(scene)

    for stream_idx, source_names in ipairs(streamers) do
        local text_idx = 0
        for _i, source_name in ipairs(source_names) do
            local source_type = string.sub(source_name, 17, -1)
            print(source_type)
            if source_type == "Capture" then
                mosscast_organize_capture(scene, stream_idx, source_name)
            else
                mosscast_organize_text(scene, stream_idx, source_name, text_idx)
                text_idx = text_idx + 1
            end
        end
    end
end

local function preload_source(name)
    SOURCES[name] = obs.obs_get_source_by_name(name)
end

-- OBS Lifecycle Functions

---@diagnostic disable-next-line: lowercase-global
function script_properties()
    local props = obs.obs_properties_create()

    obs.obs_properties_add_int_slider(props, "mosscast_num_streams", "Number of Streams", 1, 12, 1)
    obs.obs_properties_add_int(props, "mosscast_width", "Output Width", 0, 10000, 1)
    obs.obs_properties_add_int(props, "mosscast_height", "Output Height", 0, 10000, 1)

    local source_props = obs.obs_properties_create()
    obs.obs_properties_add_group(props, "mosscast_source_settings", "Source Settings", obs.OBS_GROUP_NORMAL, source_props)
    obs.obs_properties_add_path(
        source_props,
        "mosscast_dir",
        "MossCast Directory",
        obs.OBS_PATH_DIRECTORY,
        "",
        nil
    )
    obs.obs_properties_add_button(source_props, "mosscast_sync", "Create/Update Sources", mosscast_sync)

    local add_scene_props = obs.obs_properties_create()
    obs.obs_properties_add_group(props, "mosscast_add_scene_settings", "Add Scene Settings", obs.OBS_GROUP_NORMAL,
        add_scene_props)

    obs.obs_properties_add_bool(add_scene_props, "mosscast_scene_add_capture", "Add Capture")
    obs.obs_properties_add_bool(add_scene_props, "mosscast_scene_add_name", "Add Name")
    obs.obs_properties_add_bool(add_scene_props, "mosscast_scene_add_pronouns", "Add Pronouns")
    obs.obs_properties_add_bool(add_scene_props, "mosscast_scene_add_score", "Add Score")

    obs.obs_properties_add_button(add_scene_props, "mosscast_add", "Add to Current Scene", mosscast_add)


    local organize_scene_props = obs.obs_properties_create()
    obs.obs_properties_add_group(props, "mosscast_organize_scene_settings", "Organize Scene Settings",
        obs.OBS_GROUP_NORMAL,
        organize_scene_props)

    obs.obs_properties_add_int_slider(organize_scene_props, "mosscast_active_streams", "Active Streams", 1, 12, 1)

    obs.obs_properties_add_button(organize_scene_props, "mosscast_organize", "Organize Current Scene", mosscast_organize)


    return props
end

---@diagnostic disable-next-line: lowercase-global
function script_update(settings)
    mosscast_dir = obs.obs_data_get_string(settings, "mosscast_dir")
    mosscast_num_streams = obs.obs_data_get_int(settings, "mosscast_num_streams")
    mosscast_width = obs.obs_data_get_int(settings, "mosscast_width")
    mosscast_height = obs.obs_data_get_int(settings, "mosscast_height")
    mosscast_active_streams = obs.obs_data_get_int(settings, "mosscast_active_streams")
    mosscast_scene_add_capture = obs.obs_data_get_bool(settings, "mosscast_scene_add_capture")
    mosscast_scene_add_name = obs.obs_data_get_bool(settings, "mosscast_scene_add_name")
    mosscast_scene_add_pronouns = obs.obs_data_get_bool(settings, "mosscast_scene_add_pronouns")
    mosscast_scene_add_score = obs.obs_data_get_bool(settings, "mosscast_scene_add_score")


    for idx = 1, mosscast_num_streams do
        local prefix = string.format(SOURCE_PREFIX, idx)
        preload_source(prefix .. SOURCE_SUFFIX_CAPTURE)
        preload_source(prefix .. SOURCE_SUFFIX_NAME)
        preload_source(prefix .. SOURCE_SUFFIX_PRONOUNS)
        preload_source(prefix .. SOURCE_SUFFIX_SCORE)
    end
end

---@diagnostic disable-next-line: lowercase-global
function script_defaults(settings)
    obs.obs_data_set_default_int(settings, "mosscast_num_streams", 4)
    obs.obs_data_set_default_int(settings, "mosscast_width", 1920)
    obs.obs_data_set_default_int(settings, "mosscast_height", 1080)
    obs.obs_data_set_default_int(settings, "mosscast_active_streams", 4)
    obs.obs_data_set_default_bool(settings, "mosscast_scene_add_capture", true)
    obs.obs_data_set_default_bool(settings, "mosscast_scene_add_name", true)
end

---@diagnostic disable-next-line: lowercase-global
function script_unload()
    for key, value in pairs(SOURCES) do
        if value ~= nil then
            obs.obs_source_release(value)
        end
    end
end
