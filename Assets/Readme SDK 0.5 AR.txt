Setup ManoMotion SDK Lite 0.5 with AR Foundations

*AR Foundation Versions. The scene is set up to be used with AR Foundation versions 2.
If you wish to use AR Foundations versions 3, you need to remove the Tracked Pose Driver script and add the AR Pose Driver to the AR Camera.

*AR Foundations supports a minimum requerment of API level of 24 for Android.

To try out the capabilities and features of ManoMotion technology together with AR Foundations, navigate to ManoMotionAR Foundation Folder, Scenes and open the ManoMotion ARFoundation scene file. 

Switch the Unity project to the Android or iOs plattform.
Add the Scene to the build and build and run.
All of the necessary components for the ManoMotion Library to operate are already placed and set in the scene.

Common Issues & Solutions:
1)When importing the ManoMotion package, the prefabs appear to be missing.
    (Solution) Set your unity project to a version greater to 2018.3 
2)The application does not work and I am receiving a message of BundleIdentifier Missmatch.
    (Solution) Make sure that there are no spaces or additional characters in your license key(Check step 2) field or Bundle Identifier(Check step 4). 
3)The application does not work and I am receiving a message of Internet Required.
    (Solution) Make sure that the internet speed of your phone is adequate to communicate with our service. This issue is faced when there is either 
        a) No internet connection available in the device. 
        b) A very slow connection available in the device.

You can get more help, ideas and feedback by joining our development Discord server at https://discord.gg/5JYn9g 