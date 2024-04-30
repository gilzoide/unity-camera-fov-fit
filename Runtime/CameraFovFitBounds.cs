using Unity.Mathematics;
using UnityEngine;

namespace Gilzoide.CameraFit
{
    public class CameraFovFitBounds : ACameraFovFit
    {
        [SerializeField] protected Bounds _bounds;

        public override Bounds? GetWorldBounds()
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
