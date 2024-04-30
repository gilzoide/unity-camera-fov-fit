using System;
using Unity.Mathematics;
using UnityEngine;

namespace Gilzoide.CameraFit.Internal
{
    public static class FovFitMath
    {
        public static void FitFov(this Camera camera, Bounds bounds)
        {
            if (camera == null)
            {
                throw new ArgumentNullException(nameof(camera));
            }

            float2 maxFitFovScaleFactor = float2.zero;
            foreach (Vector3 corner in bounds.EnumerateCorners())
            {
                float2 fitFovScaleFactor = camera.FitFovScaleFactorForPoint(corner);
                maxFitFovScaleFactor = math.max(maxFitFovScaleFactor, fitFovScaleFactor);
            }

            float finalFovScaleFactor = math.max(maxFitFovScaleFactor.x, maxFitFovScaleFactor.y);
            if (camera.orthographic)
            {
                camera.orthographicSize *= finalFovScaleFactor;
            }
            else
            {
                camera.fieldOfView *= finalFovScaleFactor;
            }
        }

        private static float2 FitFovScaleFactorForPoint(this Camera camera, Vector3 worldPoint)
        {
            float2 viewportPoint = (Vector2) camera.WorldToViewportPoint(worldPoint);
            return math.abs(viewportPoint - new float2(0.5f)) * 2;
        }
    }
}
