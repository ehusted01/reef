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

## Deploying the emulator ##
- In Visual Studio, Make sure you have `reef.android` selected as your startup project.
- In your Android Emulator or Android Mobile, `Settings -> Usage Stats -> Enable Usage Stats for reef.android` 
- TODO: Also maybe need for IO?
- `Build -> Build without Debugging`

## Testing ##
Our test suite relies in the xUnit testing framework. https://xunit.net/

### Running Tests ###
- Open the test panel: `Visual Studio -> View -> Tests`
- Then, click the `Run Tests` icon.

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
    │   │   ├── Utils            # Useful logic independent of the app
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
    │   │   ├── Content           # The content of the appplication build
    │   │   ├── Models            # Android-specific logic
    │   │   ├── Properties        # Android build files
    │   │   ├── Resources         # The Resrouces for the app (spirtes, fonts)
    │   │   ├── ReefActivity.cs   # The starting point of the app - the activity
    │   │   └── AndroidHost.cs    # The starting point of our MonoGame application
    │   └──...
    └──...

### Tests ###
    .
    ├── reef.project
    │   ├──...
    │   └── reef.testing
    |       └── BasicTests.cs    # Our first suite of tests
    └──...     

## Building Raw Sprite Files ##
Our Monogame Content Builder is a CLI: `https://docs.monogame.net/articles/tools/mgcb.html`.
- Make sure the editor is installed. From the terminal: `dotnet tool install -g dotnet-mgcb-editor`
- Content is rebuilt at runtime. You can inspect the build tool: `reef/reef.project/reef.android/Content`

### Adding a new SpriteFile
- Add the texture to `reef/reef.project/reef.android/Content/Content.mgcb`
- Build the solution OR run the build script in Content.mgcb
- Add _a link_ to the built `.xmb` file to Content with `add -> existing file` 
- Find the file in `/Content/bin/Android/Content`, and _Add a link_ to the file
- In the `properties` view of your `.xmb` file, set the `Build Action` to `AndroidAsset`
- In the `properties` view of your `.xmb` file, set the `Copy to Output Directory` to `Copy if newer`