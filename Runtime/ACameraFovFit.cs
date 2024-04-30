using Gilzoide.CameraFit.Internal;
using UnityEngine;

namespace Gilzoide.CameraFit
{
    [ExecuteAlways]
    public abstract class ACameraFovFit : MonoBehaviour
    {
        [Tooltip("Target Camera that will have the FOV adjusted. If null, nothing will happen.")]
        [SerializeField] protected Camera _targetCamera;

        [Tooltip("If true, the FOV will be fit in this object's Start message.")]
        [SerializeField] protected bool _applyOnStart = true;

        [Tooltip("If true, the FOV will be fit in this object's Update message.")]
        [SerializeField] protected bool _applyOnUpdate = false;

        [Tooltip("Margins to add to the bounds when fitting the FOV, in world units.")]
        [SerializeField] protected Vector2 _margins;

        public abstract Bounds? GetWorldBounds();

        protected void Start()
        {
            if (_applyOnStart)
            {
                RefreshFov();
            }
        }

        protected void Update()
        {
            if (!_applyOnUpdate && Application.isPlaying)
            {
                // disable refresh on Play mode to avoid no-op Updates
                enabled = false;
                return;
            }

            RefreshFov();
        }

        public void RefreshFov()
        {
            if (_targetCamera && GetWorldBounds() is Bounds bounds)
            {

                bounds.Expand(_margins);
                _targetCamera.FitFov(bounds);
            }
        }

#if UNITY_EDITOR
        protected virtual void OnDrawGizmosSelected()
        {
            if (GetWorldBounds() is Bounds bounds)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireCube(bounds.center, bounds.size);
            }
        }

        protected virtual void OnValidate()
        {
            RefreshFov();
        }
#endif
    }
}
