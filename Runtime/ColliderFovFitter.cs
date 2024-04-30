using UnityEngine;

namespace Gilzoide.CameraFit
{
    [AddComponentMenu("Camera FOV Fit/Collider FOV Fitter")]
    public class ColliderFovFitter : AFovFitter
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
