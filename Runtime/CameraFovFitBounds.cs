using Unity.Mathematics;
using UnityEngine;

namespace Gilzoide.CameraFit
{
    [AddComponentMenu("Camera FOV Fit/Bounds Fitter")]
    public class CameraFovFitBounds : ACameraFovFit
    {
        [Tooltip("Bounds used to fit the target Camera's FOV.")]
        [SerializeField] protected Bounds _bounds;

        protected override Bounds? GetWorldBounds()
        {
            if (math.any(_bounds.size))
            {
                Transform t = transform;
                return new Bounds(t.TransformPoint(_bounds.center), (float3) t.lossyScale * _bounds.size);
            }
            else
            {
                return null;
            }
        }
    }
}
