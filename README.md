# reef #
Reef project for 403

How many hours do you think you’ve wasted by procrastinating on your phone? Reef is here to help! With Reef, the goal is not to prevent you from using certain apps in the moment, but to instead reward good habits that are developed over time. Reef offers rewards for meeting goals to encourage better habits over the long-term. As you meet goals, you can add fish and corals to your little aquatic environment. The bigger the goal, the cooler the creature! By gamifying good habits, Reef aims to keep you on track so that you can improve your habits and gain cute friends along the way

## Installation Requirements ##
Copy the repo from https://github.com:WednesdayWolf/reef.git

### macOS ###
- git: https://git-scm.com/book/en/v2/Getting-Started-Installing-Git
- Visual Studio for macOS: https://visualstudio.microsoft.com/vs/mac
- Monogame Extension: Visual Studio -> Extensions -> search for Monogame

### PC ###
- git: https://git-scm.com/book/en/v2/Getting-Started-Installing-Git
- https://visualstudio.microsoft.com/downloads/
- Monogame Extension: Visual Studio -> Extensions -> search for Monogame

### Setting up your Emulator ###
- Follow this guide for getting an Android Emulator working on your machine: https://visualstudio.microsoft.com/vs/msft-android-emulator/
- If that doesn't work, [troubleshoot through this link](https://lmgtfy.app/?q=I+am+a+CSE+major+how+do+I+install+an+android+emulator)

## Building & Running ## 

### Deploying to an Emulator ###
- Make sure you have an Android Emulator properly set up on your machine
- In Visual Studio, Make sure you have `reef.android` selected as your startup project
- In your Android Emulator or Android Mobile, make sure that Usage data access is enabled
    - `Settings -> search for Usage data access -> Enable Usage data access for reef.android` 
    -  `settings-> Apps & notification -> Special app access -> Usage access -> reef.android (Enable)`
- To run the app: `Run -> Start Without Debugging`
- To run with breakpoints: `Run -> Start With Debugging`

### Building a Release Version ###
- Follow this guide: https://docs.microsoft.com/en-us/xamarin/android/deploy-test/release-prep/
- In the build menu, select `reef.android -> Release`
- Then select `Build -> Build all`

### Using Reef ###
- Load up Reef
- To add fish, lower the amount of time you spend on apps between sessions
- To remove fish, increase the amount of time you spend on apps between sessions

## Testing ##
Our test suite relies in the xUnit testing framework. https://xunit.net/

### Running Tests ###
- Open the test panel: `Visual Studio -> View -> Tests`
- Then, click the `Run Tests` icon.

### Adding Tests ###
- Our testing suite is xUnit, found at `reef/reef.project/reef.tests` 
- We add a test by finding the appropriate class for our test, and then adding to that class, or by creating a new class if none are available.
- Tests are run with the built-in Visual Studio test runner.

## Reporting Bugs ##
- Make a report following these guidelines: https://developer.mozilla.org/en-US/docs/Mozilla/QA/Bug_writing_guidelines
- Include a screenshot and a brief description of the actions you took and why it didn't work the way you intended.
- Add it to our issue tracker: https://github.com/WednesdayWolf/reef/issues

## Operational Use Cases ##
- User can gain a fish from having less app usage between sessions
- User can lose a fish from having more app usage between sessions

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

### Adding a new SpriteFile ###
- Add the texture to `reef/reef.project/reef.android/Content/Content.mgcb`
- Build the solution OR run the build script in Content.mgcb
- Add _a link_ to the built `.xmb` file to Content with `add -> existing file` 
- Find the file in `/Content/bin/Android/Content`, and _Add a link_ to the file
- In the `properties` view of your `.xmb` file, set the `Build Action` to `AndroidAsset`
- In the `properties` view of your `.xmb` file, set the `Copy to Output Directory` to `Copy if newer`
