# reef #
Reef project for 403

How many hours do you think you’ve wasted by procrastinating on your phone? Reef is here to help! With Reef, the goal is not to prevent you from using certain apps in the moment, but to instead reward good habits that are developed over time. Reef offers rewards for meeting goals to encourage better habits over the long-term. As you meet goals, you can add fish and corals to your little aquatic environment. The bigger the goal, the cooler the creature! By gamifying good habits, Reef aims to keep you on track so that you can improve your habits and gain cute friends along the way

## Installation Requirements ##

### macOS ###
- git: https://git-scm.com/book/en/v2/Getting-Started-Installing-Git
- Visual Studio for macOS: https://visualstudio.microsoft.com/vs/mac
- Monogame Extension: Visual Studio -> Extensions -> search for Monogame

### PC ###
- git: https://git-scm.com/book/en/v2/Getting-Started-Installing-Git
- https://visualstudio.microsoft.com/downloads/
- Monogame Extension: Visual Studio -> Extensions -> search for Monogame

## Project Structure ##

### Top Level ###
    .
    ├── reef.assets         # Assets for our application
    ├── reef.project        # Reef application 
    │   ├── reef.android    # Android-specific logic
    │   ├── reef.shared     # Application logic
    │   └── reef.tests      # Automated tests 
    └── README.md

### Shared App Logic ###
    .
    ├── reef.project
    │   ├──...
    │   ├── reef.shared
    │   │   ├── Config           # Application configuration
    │   │   ├── Content          # Asset content (probably not used)
    │   │   ├── Controllers      # Interface between the View & the Model
    │   │   ├── Models           # Any logic & data in the application
    │   │   ├── Views            # Visuals to present to the user
    │   │   ├── GameHost.cs      # The host of everything shown to the user
    │   │   └── GameObj.cs       # The lowest-level object
    │   └──...
    └──...

### Android-Specific ###
    .
    ├── reef.project
    │   ├──...
    │   ├── reef.android
    |   |   ├── Content           # The content of the appplication build
    |   |   ├── Models            # Android-specific logic
    |   |   ├── Properties        # Android build files
    |   |   ├── Resources         # The Resrouces for the app (spirtes, fonts)
    |   |   ├── Activity1.cs      # The starting point of the app - the activity
    |   |   └── Game1.cs          # The starting point of our MonoGame application
    │   └──...
    └──...

### Tests ###
    .
    ├── reef.project
    │   ├──...
    │   └── reef.testing
    |       └── UnitTest1.cs      # Our first suite of tests
    └──...     
