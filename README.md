# DarkLoader [![Build status](https://ci.appveyor.com/api/projects/status/evq3v5pgw6wxegi4?svg=true)](https://ci.appveyor.com/project/dark-c0de/darkloader)
Halo Loader for all Halo Online Versions

![DarkLoader](https://halo.click/jridZJ)

DarkLoader is a tool aimed to work with all builds of Halo Online to date, and future builds to come.

Anyone is welcome to help work on DarkLoader, so please, please do! 

Please also leave a comment on the [Forum Thread](https://forum.halo.click/index.php?/topic/234-program-darkloader/) if you enjoyed this tool, maybe you have a question, or maybe it doesn't work at all for you! Let us know. 

## Tested Versions
* 1.106708_cert_ms23___release (April 12th, 2015)
* Live_release_0.4.1.332089 (?)
* Live_release_8.1.373869 (July 20th, 2015)
* Live_release_9.1.416138 (August 1st, 2015)
* Live_release_10.1.430653 (August 7th, 2015)

### Here's a feature list of what it can do right now:
1. "DarkLoad" maps on every available gametype, and every map type. (Including Forge!), from every "known" build of Halo Online.
2. A Halo Online Launcher button to launch the game.
3. A list of maps available for the version of Halo Online you're running (Click them to load them).

DarkLoader heavily relies on Pattern Scanning to support multiple versions of Halo Online. With the latest release of Halo Online "Live" build, they seemed to have randomized the memory in such a way that static address on your machine might not be in the same memory space as the same static address on other machines. 

### Here's what's planned:
1. Fully functional pattern scanning for as many Eldewrito functions as possible, we already have a good understanding of where things live from the original build, now we need to build patterns and implement them.
2. Patterns that can patch all halo online exe's to support custom tag edits, resources, etc. 
3. Basically anything someone might want to do that they don't want to break on a new build of Halo Online.

Enjoy!
