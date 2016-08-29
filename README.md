# HoloBoard
HoloLens 3D whiteboard hologram.


# System requirements 
The Windows 10 SDK works best on the **Windows 10 operating system**. This SDK is also supported on Windows 8.1, Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2. Note that not all tools are supported on older operating systems. Visual Studio 2015 also has hardware requirements.

The HoloLens emulator is based on Hyper-V and uses RemoteFx for hardware accelerated graphics. To use the emulator, make sure your PC meets these hardware requirements:
- 64-bit Windows 10 Pro, Enterprise, or Education (The Home edition does not support Hyper-V. Installing the HoloLens Emulator will fail on the Home edition)
- 64-bit CPU
- CPU with 4 cores (or multiple CPU's with a total of 4 cores)
- 8 GB of RAM or more
- In the BIOS, the following features must be supported and enabled:•Hardware-assisted virtualization
- Second Level Address Translation (SLAT)
- Hardware-based Data Execution Prevention (DEP)

- GPU (The emulator might work with an unsupported GPU, but will be significantly slower)
- DirectX 11.0 or later
- WDDM 1.2 driver or later

If your system meets the above requirements, please ensure that the "Hyper-V" feature has been enabled on your system through Control Panel -> Programs -> Programs and Features -> Turn Windows Features on or off -> ensure that "Hyper-V" is selected for the Emulator installation to be successful.


# Prerequisites
A Windows 10 PC configured with the correct [tools installed](https://developer.microsoft.com/en-us/windows/holographic/install_the_tools).

| Download and Install                      | Notes	                                                                                                                                                                                                                                                     |
| ----------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | 
| Visual Studio 2015 Update 3               | If you choose a custom install, ensure that Tools (1.4) and Windows 10 SDK (10.0.10586) is enabled under Universal Windows App Development Tools node. All editions of Visual Studio 2015 Update 3 are supported, including Community.                     |
| HoloLens Emulator (build 10.0.14342.1018)	| The emulator allows you to run apps on Windows Holographic in a virtual machine without a HoloLens. **Your system must support Hyper-V for the Emulator installation to succeed. Please reference the System Requirements section below for the details.** |
| Unity HoloLens Technical Preview          | HoloLens support in Unity is available through a custom version of the Unity Editor and Runtime which is now available to download for free on the [Unity website](http://unity3d.com/partners/windows/hololens).	                                         |

| Unity HoloLens install guide |
| ---------------------------- |
| First, install the [64-bit (Win)](http://beta.unity3d.com/download/f990cb18ca69/UnitySetup64.exe?_ga=1.114506439.1179177976.1467960147) or [32-bit (Win)](http://beta.unity3d.com/download/f990cb18ca69/UnitySetup32.exe?_ga=1.114506439.1179177976.1467960147) Editor Installer. |
| Next install the [UWP Runtime](http://beta.unity3d.com/download/f990cb18ca69/UnitySetup-Metro-Support-for-Editor-5.4.0b24-HTP.exe?_ga=1.114506439.1179177976.1467960147). |


# Getting started
## Get the project
- Clone the repo
- Open the .//HoloBoard//Assets//Scenes//Home.unity

## Export from Unity to Visual Studio
- In Unity select File > Build Settings.
- Select Windows Store in the Platform list and click Switch Platform.
- Set SDK to Universal 10 and Build Type to XAML.
- Check Unity C# Projects.
- Click Add Open Scenes to add the scene.
- Click Build

## Emulate from Visual Studio to Emulator
- Open the HoloBoard Visual Studio Solution.
- Using the top toolbar in Visual Studio, change the target from Debug to **Release** and from ARM to **X86**.
- Click on the arrow next to the Device button, and select **HoloLens Emulator**.
- Click **Debug -> Start Without debugging** or press **Ctrl + F5**.
- After some time the emulator will start with the HoloBoard project.
