using UnityEngine;

namespace Gilzoide.CameraFit
{
    public class CameraFovFitRenderer : ACameraFovFit
    {
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
