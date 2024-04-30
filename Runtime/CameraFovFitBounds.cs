using Unity.Mathematics;
using UnityEngine;

namespace Gilzoide.CameraFit
{
    public class CameraFovFitBounds : ACameraFovFit
    {
        [SerializeField] protected Bounds _bounds;

        public override Bounds? GetWorldBounds()
        {
            Transform t = transform;
            return new Bounds(t.TransformPoint(_bounds.center), (float3) t.lossyScale * _bounds.size);
        }
    }
}
