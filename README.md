#SampleProjects repository
This repository contains some personal projects that I've put together over time. Here is a brief summary of each solution
and what it does:

##Eliminator
This is a fun Windows Forms application that I put together to create and run a single-elimination tournament bracket. It 
supports user-defined or random seeding and saving started tournaments to file for later use. I plan on adding auto-focusing 
for brackets and the ability to zoom.

##MusicSync
This solution contains two Windows service applications that are designed to gather music media and usage information from Windows Media Player (WMP). When configured for a specific user account, the MusicSync.LibrarySyncService will poll the WMP database at regular intervals and store artist, album and song titles for MP3 files in the current user's WMP library. Likewise, the MusicSync.UsageSyncService will poll the WMP database to retrieve information for recently played songs and also store this information in the SQL database. The idea behind this project is to gather usage information from multiple machines using a local copy of the same library. This information could be relayed to social networking and other websites on a regular basis.

The projects contained within this solution are listed below, along with a description of each:
###MusicSync.Common
Contains interfaces, business object classes and thread controller classes used by both services.

###MusicSync.Database
Database project that defines the schema for the SQL database that both services write to.

###MusicSync.Implementation
Contains repository and configuration implementation classes.

###MusicSync.LibrarySyncService
Windows service application project that hosts and runs a thread controller object to sync library information.

###MusicSync.TestConsole
Console application that hosts and runs a thread controller to either sync library information or pull and store media usage information. This is primarily used to test/debug the controller classes that the Windows services host.

###MusicSync.UsageSyncService
Windows service application project that hosts and runs a thread controller object to pull and store media usage information.

###Wes.Database
Class library I developed to act as a wrapper for ADO.NET connection/command creation and execution. I use this when putting together my own SQL data access layers (DALs).
