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

            float2 scale = default;
            foreach (Vector3 corner in bounds.EnumerateCorners())
            {
                scale = math.max(scale, camera.GetScaleFactor(corner));
            }
            if (camera.orthographic)
            {
                camera.orthographicSize *= math.max(scale.x, scale.y);
            }
            else
            {
                camera.fieldOfView *= math.max(scale.x, scale.y);
            }
        }

        private static float2 GetScaleFactor(this Camera camera, Vector3 worldPoint)
        {
            float2 viewportPoint = (Vector2) camera.WorldToViewportPoint(worldPoint);
            return math.abs(viewportPoint - new float2(0.5f)) * 2;
        }
    }
}
