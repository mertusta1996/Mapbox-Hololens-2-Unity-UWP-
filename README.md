# Mapbox-Hololens-2-Unity-UWP-
This repo is a successful example of Mapbox API is working in Microsoft Hololens-2 glasses with Unity UWP.

## Changes
- Deleted sq3lite.dll and some parts of codes working with sq3lite.dll.(sq3lite part is so problematic for Hololens-2)

- Reworked all .dll files in Mapbox/Plugins folder.

- Some namespaces and libraries deleted from codes and changed with compatible ones with UWP.

- Changed some parts of codes for build errors.

## Usage
 
1 - You could set the Map Position in the Real World.




https://user-images.githubusercontent.com/70747383/178017830-f1260e35-0b17-419c-9c44-bac63e3a8b79.mp4




2 - You could Increase/Decrease Map Size.



https://user-images.githubusercontent.com/70747383/178016779-8065a052-6dc4-4aca-8332-2ac8f6b33414.mp4


3 - You could travel in the Map.



https://user-images.githubusercontent.com/70747383/178017046-1f92ed81-6b80-439a-a55c-5f3eabe8e52d.mp4


4 - You could Zoom In/Zoom Out in the Map.



https://user-images.githubusercontent.com/70747383/178017146-b5927b74-d102-4d01-96d1-ad3f3dfce229.mp4




## Setup
1 - Download the repo.


2 - Here is the main Unity scene for this app I've added. (Assets\Mapbox Hololens2\Scene\Hololens2 Scene.unity)

  <img src="UserManual\SceneSS.PNG" width="800px" height="auto">


3 - Configure the Mapbox token value from this section.

  <img src="UserManual\Setup1SS.PNG" width="300px" height="auto">
  
4 - Create an account from Mapbox web page and add your free Mapbox token to here. (for creating Mapbox token => mapbox.com/studio/accounts/tokens/)

  <img src="UserManual\Setup2SS.PNG" width="500px" height="auto">
  
5- Open the Build Settings , add the main scene and configure the settings like this image.

  <img src="UserManual\BuildSettingsSS.PNG" width="500px" height="auto">
  
6- After building the app, deploy it to the Hololens-2 from the .sln file. (Open the .sln file with Visual Studio and deploy it as a package or deployment with Master, ARM settings.)

 <img src="UserManual\BuildSS1.PNG" width="500px" height="auto">

## Author

-   Mert Usta - [GitHub](https://github.com/mertusta1996)
-   Tugay Karapınar
