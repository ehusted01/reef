# reef #
Reef project for 403

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
    │   │   ├── Config            # Application configuration
    │   │   ├── Content           # Asset content (probably not used)
    │   │   ├── Controllers       # Interface between the View & the Model
    │   │   ├── Models            # Any logic & data in the application
    │   │   ├── Views             # Visuals to present to the user
    │   │   ├── GameHost.cs       # The host of everything shown to the user
    │   │   └── GameObj.cs        # The lowest-level object
    │   └──...
    └──...

### Android-specific ###
// TODO
  .
  ├── reef.project
  │   ├──...
  │   ├── reef.android
  │   └──...
  └──...

### Tests ###
// TODO
