# DarkLoader [![Build status](https://ci.appveyor.com/api/projects/status/evq3v5pgw6wxegi4?svg=true)](https://ci.appveyor.com/project/dark-c0de/darkloader)
Halo Loader for all Halo Online Versions.

![DarkLoader](https://halo.click/OBc7ik)
![PatchEditor](https://halo.click/yQJX3K)
![MemoryViewer](https://halo.click/DqHdQ3)
![HexHelper](https://halo.click/7869yL)

DarkLoader is a tool aimed to work with all builds of Halo Online to date, and future builds to come.

Anyone is welcome to help work on DarkLoader, so please, please do! 

Please also leave a comment on the [Forum Thread](https://forum.halo.click/index.php?/topic/234-program-darkloader/) if you enjoyed this tool, maybe you have a question, or maybe it doesn't work at all for you! Let us know. 

You can easily help us by building patches, no C# compiling required. Check out the [PatchEditor](https://github.com/dark-c0de/DarkLoader/wiki/Patch-Editor)

## Tested Versions
* 1.106708_cert_ms23___release (April 12th, 2015)
* Live_release_0.4.1.332089 (?)
* Live_release_8.1.373869 (July 20th, 2015)
* Live_release_9.1.416138 (August 1st, 2015)
* Live_release_10.1.430653 (August 7th, 2015)
* Live_release_11.1.498295 (September 14th, 2015)

### Here's a feature list of what it can do right now:
1. "DarkLoad" maps on every available gametype, and every map type. (Including Forge!), from every "known" build of Halo Online.
2. Load Halo Online in English
3. A list of maps available for the version of Halo Online you're running (Click them to load them).
4. Hide, Show hud for every game.
5. Pattern scan and create patterns and patches to share with other users (pull requests!), see [PatchEditor](https://github.com/dark-c0de/DarkLoader/wiki/Patch-Editor)

DarkLoader heavily relies on Pattern Scanning to support multiple versions of Halo Online. With the latest release of Halo Online "Live" build, they seemed to have randomized the memory in such a way that static address on your machine might not be in the same memory space as the same static address on other machines. 

### Here's what's planned:
1. Fully functional pattern scanning for as many Eldewrito functions as possible, we already have a good understanding of where things live from the original build, now we need to build patterns and implement them.
2. Patterns that can patch all halo online exe's to support custom tag edits, resources, etc. 
3. Basically anything someone might want to do that they don't want to break on a new build of Halo Online.

### Patches we still need
* Tag Edit Patching
* Map Checksum verification patching
* etc

### TODO
If you're a developer and you can help dig into the code, here's some things that need to be done.
* Add pattern matching to the `MagicPatches.ExePatches`. Currently ExePatches do not support matching like the memory scanner does. 
* Allow people to update their patch JSON without removing changes they've made.
* Checksom the JSON and only alert that they are about to overwrite changes if the old hash is different.
* UI Improvements to DarkLoader
* 4game login support
* etc

Enjoy!
