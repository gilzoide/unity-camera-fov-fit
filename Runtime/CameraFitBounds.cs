using UnityEngine;

namespace Gilzoide.CameraFit
{
    public class CameraFitBounds : ACameraFit
    {
        [SerializeField] protected Bounds _bounds;

        public override Bounds? GetWorldBounds()
        {
            return new Bounds(transform.TransformPoint(_bounds.center), transform.TransformVector(_bounds.size));
        }
    }
}
