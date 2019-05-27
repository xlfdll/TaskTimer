# Task Timer
A simple program to show large-sized time countdown on screen for a specific task

<p align="center">
  <img src="https://github.com/xlfdll/xlfdll.github.io/raw/master/images/projects/TaskTimer/TaskTimer-MainScreen.png"
       alt="Task Timer">
</p>

## System Requirements
* .NET Framework 4.8

[Runtime configuration](https://docs.microsoft.com/en-us/dotnet/framework/migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5) is needed for running on other versions of .NET Framework.

## Usage
1. Run the program
2. Set period of time in 24-hour HH:MM:SS format (Hour:Minute:Second)
3. If preferred, enter a note in the text box below
4. Click timer icon <img src="https://github.com/xlfdll/xlfdll.github.io/raw/master/images/projects/TaskTimer/TaskTimer-Start.png"
       alt="Timer Start" width="32"> to start countdown. Click again <img src="https://github.com/xlfdll/xlfdll.github.io/raw/master/images/projects/TaskTimer/TaskTimer-Pause.png"
       alt="Timer Pause" width="32"> to pause

When time reaches 00:00:00, a message box will pop up to notify you the time is up:

<p align="center">
  <img src="https://github.com/xlfdll/xlfdll.github.io/raw/master/images/projects/TaskTimer/TaskTimer-TimeIsUp.png"
       alt="Timer is up">
</p>

Time will reset afterwards.

Adjust window size or maximize to enlarge time display.

## Development Prerequisites
* Visual Studio 2013+

Before the build, generate-build-number.sh needs to be executed in a Git / Bash shell to generate build information code file (BuildInfo.cs).

## External Sources
Timer icons are from [Modern UI Icons](http://modernuiicons.com/), which are licensed under [CC BY-ND 3.0](https://github.com/Templarian/WindowsIcons/blob/master/WindowsPhone/license.txt).
