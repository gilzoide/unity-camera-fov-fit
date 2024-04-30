# Camera FOV Fit
Automatically adjust cameras' Field Of View (FOV) to 3D objects's bounds in Unity.


## Features
- FOV fitter scripts automatically adjust a camera's FOV to fit the object's bounds.
  Only the FOV is adjusted, so that it's transform is maintained.
- Supports both Perspective and Orthogonal cameras.
- [CameraFovFitBounds](Runtime/CameraFovFitBounds.cs): fits the target camera's FOV to the specified bounds.
- [CameraFovFitCollider](Runtime/CameraFovFitCollider.cs): fits the target camera's FOV to the specified collider's bounds.
- [CameraFovFitRenderer](Runtime/CameraFovFitRenderer.cs): fits the target camera's FOV to the specified renderer's bounds.
- Configuration for adjusting the FOV automatically in Start, every frame in Update, or none: just call `RefreshFov` manually whenever necessary.
- [Camera.FitFovToBounds](Runtime/FovFitMath.cs) extension method for fitting a camera's FOV to the specified bounds without using the provided components.


## How to install
Either:
- Install using the [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html) with the following URL:
  ```
  https://github.com/gilzoide/unity-camera-fov-fit.git#1.0.0-preview1
  ```
- Clone this repository or download a snapshot of it directly inside your project's `Assets` or `Packages` folder.
