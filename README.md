# Camera FOV Fit
[![openupm](https://img.shields.io/npm/v/com.gilzoide.camera-fov-fit?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.gilzoide.camera-fov-fit/)

Automatically adjust cameras' Field Of View (FOV) to 3D objects's bounds in Unity.


## Features
- FOV fitter scripts automatically adjust a camera's FOV to fit the object's bounds.
  Only the FOV is adjusted, so that it's transform is maintained.
- Supports both Perspective and Orthogonal cameras.
- [BoundsFovFitter](Runtime/BoundsFovFitter.cs): fits the target camera's FOV to the specified bounds.
- [ColliderFovFitter](Runtime/ColliderFovFitter.cs): fits the target camera's FOV to the specified collider's bounds.
- [RendererFovFitter](Runtime/RendererFovFitter.cs): fits the target camera's FOV to the specified renderer's bounds.
- Configuration for adjusting the FOV automatically in Start, every frame in Update, or none: just call `RefreshFov` manually whenever necessary.
- [Camera.FitFovToBounds](Runtime/FovFitMath.cs) extension method for fitting a camera's FOV to the specified bounds without using the provided components.


## How to install
Either:
- Use the [openupm registry](https://openupm.com/) and install this package using the [openupm-cli](https://github.com/openupm/openupm-cli):
  ```
  openupm add com.gilzoide.camera-fov-fit
  ```
- Install using the [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html) with the following URL:
  ```
  https://github.com/gilzoide/unity-camera-fov-fit.git#1.0.0
  ```
- Clone this repository or download a snapshot of it directly inside your project's `Assets` or `Packages` folder.
