# Tweening Components

Powered by **DOTween**. **Tweening Components** is a package that provides a set of preset components to animate UGUI in Unity with scriptable objects.

## Installation

### Dependencies

-   TextMeshPro
-   DOTween

### Set Up DOTween

**In your Unity project, install [DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676).**

> [!IMPORTANT]  
> **Create an Assembly Definition for DOTween.**

<img src="Documentation/Images/DOTweenSetUp.png" height="500" alt="arrow pointing to Create Assembly Definition for DOTween in the set up window."/>

### Installing Tweening Components

Install the package from a git URL...

```console
https://github.com/Tirtstan/Tweening-Components.git
```

<img src="Documentation/Images/AddPackage.png" alt="dropdown in the Unity packages manager for adding a package by git URL."/>

## Usage

1. Add a TweenOnEvent component to you desired object:

<img src="Documentation/Images/AddComponent.png" alt="Adding a TweenOnEvent component to a desired game object."/>

2. Create a Tween profile:

<img src="Documentation/Images/CreateTween.png" alt="Creating a scriptable object tween profile through the project create context menu."/>

3. Edit the Tween profile to your desired liking:

<img src="Documentation/Images/EditProfile.png" alt="inspector view of the created tween profile."/>

4. Edit the TweenOnEvent component with all references and desired configurations:

<img src="Documentation/Images/EditTween.png" alt="inspector view of the previously added TweenOnEvent with its necessary references."/>

**Done!**

## Note

Certain fields on the profiles like target and factor will not affect the tween depending on the chosen mode.
