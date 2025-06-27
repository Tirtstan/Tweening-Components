# Tweening Components

Powered by **DOTween**. **Tweening Components** is a package that provides a set of preset scriptable objects to animate UGUI in Unity.

## Installation

```console
https://github.com/Tirtstan/Tweening-Components.git
```

### Dependencies

-   TextMeshPro
-   DOTween

### 1. Set Up DOTween

**In your Unity project, install [DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676).**

> [!IMPORTANT]  
> **Create an Assembly Definition for DOTween.**

<img src="Documentation/Images/DOTweenSetUp.png" height="500" alt="arrow pointing to Create Assembly Definition for DOTween in the set up window."/>

### 2. Installing Tweening Components

In the Package Manager, `Click the Plus Button > Install the package from a git URL...` and paste the following in:

```console
https://github.com/Tirtstan/Tweening-Components.git
```

<img src="Documentation/Images/AddPackage.png" alt="dropdown in the Unity packages manager for adding a package by git URL."/>

## Usage

### 1. Add a `TweenOnEvent` component to you desired object:

<img src="Documentation/Images/AddComponent.png" alt="Adding a TweenOnEvent component to a desired game object."/>

### 2. Create a `TweenProfile`:

In your Project tab, `Right Click > Create > Tweening`.

<img src="Documentation/Images/CreateTween.png" alt="Creating a scriptable object tween profile through the project create context menu."/>

### 3. Edit the `TweenProfile` to your desired liking:

<img src="Documentation/Images/EditProfile.png" alt="inspector view of the created tween profile."/>

### 4. Edit the `TweenOnEvent` component with all references and desired configurations:

<img src="Documentation/Images/EditTween.png" alt="inspector view of the previously added TweenOnEvent with its necessary references."/>

**Done!**

## Samples

Don't forget to check out the `Samples` folder for more extensive examples!
