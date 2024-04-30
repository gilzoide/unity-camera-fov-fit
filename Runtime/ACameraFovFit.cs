using Gilzoide.CameraFit.Internal;
using UnityEngine;

namespace Gilzoide.CameraFit
{
    [ExecuteAlways]
    public abstract class ACameraFovFit : MonoBehaviour
    {
        [SerializeField] protected Camera _targetCamera;
        [SerializeField] protected bool _applyOnStart = true;
        [SerializeField] protected bool _applyOnUpdate = false;
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
