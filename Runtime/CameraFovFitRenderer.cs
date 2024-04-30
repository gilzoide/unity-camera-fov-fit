using UnityEngine;

namespace Gilzoide.CameraFit
{
    public class CameraFovFitRenderer : ACameraFovFit
    {
        [Tooltip("Renderer whose bounds will be used to fit the target Camera's FOV. If null, nothing will happen.")]
        [SerializeField] protected Renderer _renderer;

        public override Bounds? GetWorldBounds()
        {
            if (_renderer)
            {
                return _renderer.bounds;
            }
            else
            {
                return null;
            }
        }
    }
}
