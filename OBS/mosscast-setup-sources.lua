local obs = obslua

local SOURCES = {}
local SOURCE_PREFIX = "MossCast - %02d - "
local SOURCE_SUFFIX_CAPTURE = "Capture"
local SOURCE_SUFFIX_NAME = "Name"
local SOURCE_SUFFIX_PRONOUNS = "Pronouns"
local SOURCE_SUFFIX_SCORE = "Score"

local mosscast_num_streams = 1
local mosscast_dir = ""

local function isempty(s)
    return s == nil or s == ''
end


local function get_or_create_source(name, type, settings)
    local source = SOURCES[name]
    if source == nil then
        print(string.format("Failed to find source (%s) in cache", name))
        source = obs.obs_get_source_by_name(name)
    end

    if source == nil then
        print(string.format("Failed to find source (%s). Creating.", name))
        source = obs.obs_source_create(type, name, settings, nil)
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

    local source = get_or_create_source(name, "game_capture", settings)
    obs.obs_source_reset_settings(source, settings)

    obs.obs_data_release(settings)
end

local function create_or_update_text_source(name, filepath)
    -- Ensure file exists
    local handle, err = io.open(filepath, "a+")
    if err ~= nil then
        print(string.format("Failed to ensure file (%s) exists: %s", filepath, err))
        return
    end
    if handle ~= nil then
        handle:close()
    end

    local settings = obs.obs_data_create()
    obs.obs_data_set_bool(settings, "read_from_file", true)
    obs.obs_data_set_string(settings, "file", filepath)
    obs.obs_data_set_bool(settings, "outline", true)
    obs.obs_data_set_int(settings, "outline_color", 4278190080)
    obs.obs_data_set_int(settings, "outline_size", 2)

    local source = get_or_create_source(name, "text_gdiplus_v2", settings)
    print(tostring(source))
    obs.obs_source_reset_settings(source, settings)

    obs.obs_data_release(settings)
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
            string.format("%s/streamer-%02d.txt", mosscast_dir, idx))
        create_or_update_text_source(prefix .. SOURCE_SUFFIX_PRONOUNS,
            string.format("%s/streamer-pronouns-%02d.txt", mosscast_dir, idx))
        create_or_update_text_source(prefix .. SOURCE_SUFFIX_SCORE, string.format("%s/score-%02d.txt", mosscast_dir, idx))
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
        add_source(scene, prefix .. SOURCE_SUFFIX_CAPTURE)
    end
    for idx = mosscast_num_streams, 1, -1 do
        local prefix = string.format(SOURCE_PREFIX, idx)
        add_source(scene, prefix .. SOURCE_SUFFIX_SCORE)
        add_source(scene, prefix .. SOURCE_SUFFIX_PRONOUNS)
        add_source(scene, prefix .. SOURCE_SUFFIX_NAME)
    end
end

local function preload_source(name)
    SOURCES[name] = obs.obs_get_source_by_name(name)
end

-- OBS Lifecycle Functions

function script_properties()
    local props = obs.obs_properties_create()
    obs.obs_properties_add_path(
        props,
        "mosscast_dir",
        "MossCast Directory",
        obs.OBS_PATH_DIRECTORY,
        "",
        nil
    )
    obs.obs_properties_add_int_slider(props, "mosscast_num_streams", "Number of Streams", 1, 12, 1)
    obs.obs_properties_add_button(props, "mosscast_sync", "Create/Update Sources", mosscast_sync)
    obs.obs_properties_add_button(props, "mosscast_add", "Add to Current Scene", mosscast_add)
    return props
end

function script_update(settings)
    mosscast_dir = obs.obs_data_get_string(settings, "mosscast_dir")
    mosscast_num_streams = obs.obs_data_get_int(settings, "mosscast_num_streams")

    for idx = 1, mosscast_num_streams do
        local prefix = string.format(SOURCE_PREFIX, idx)
        preload_source(prefix .. SOURCE_SUFFIX_CAPTURE)
        preload_source(prefix .. SOURCE_SUFFIX_NAME)
        preload_source(prefix .. SOURCE_SUFFIX_PRONOUNS)
        preload_source(prefix .. SOURCE_SUFFIX_SCORE)
    end
end

function script_unload()
    for key, value in pairs(SOURCES) do
        if value ~= nil then
            obs.obs_source_release(value)
        end
    end
end
