using UnityEngine;

namespace Gilzoide.CameraFit
{
    public class CameraFovFitCollider : ACameraFovFit
    {
        [SerializeField] protected Collider _collider;

        public override Bounds? GetWorldBounds()
        {
            if (_collider)
            {
                return _collider.bounds;
            }
            else
            {
                return null;
            }
        }
    }
}
