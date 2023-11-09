# MossCast

GUI frontend for Streamlink. This was originally developed for the NecroDancer racing community as [MacSG](https://github.com/necrommunity/macsg). While I would like to think some of these changes could be contributed back upstream I have extensive changes to make to support Spelunky events and ported the code base from VB.net to C# to make it easier for our community to make changes quickly.

## Getting started

You'll need [VLC Media Player](https://www.videolan.org/vlc/download-windows.en_GB.html) and [Streamlink](https://github.com/streamlink/windows-builds/releases).

## Automated text sources

MossCast outputs the streamer names and pronouns provided into plain text files, located at `%AppData%\MossCast` (which can be opened via File > Open AppData Folder). You can use these inside OBS using the Text GDI+ source type, and checking the "Read from file" checkbox. By default, streamer names and their pronouns are written to 2 separate files, e.g. `streamer-01.txt` and `streamer-pronouns-01.txt`. You can write both the name and pronouns to one file by clicking File > Combine Names and Pronouns, which for `MacND` and `He/They` results in an output format of `MacND (He/They)`.

## Customising VLC behaviour

You can configure VLC to have certain behaviours exclusively with MossCast, such as hiding the VLC interface, by modifing the configuration file located at `%AppData%\MossCast\vlcrc`. Some common items you may want to change:

- Set `qt-minimal-view=1` to hide the user interface automatically
- Set `video-title-show=0` to hide the name of the media being played, this dispalys as `fd://0` for Streamlink
- Set `video-on-top=1` to have VLC always be on top of other windows
- Set `audio=0` to have streams always be muted when started
