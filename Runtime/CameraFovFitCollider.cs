using UnityEngine;

namespace Gilzoide.CameraFit
{
    public class CameraFovFitCollider : ACameraFovFit
    {
        [Tooltip("Collider whose bounds will be used to fit the target Camera's FOV. If null, nothing will happen.")]
        [SerializeField] protected Collider _collider;

        protected override Bounds? GetWorldBounds()
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
