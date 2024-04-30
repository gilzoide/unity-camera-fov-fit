using UnityEngine;

namespace Gilzoide.CameraFit
{
    public class CameraFitRenderer : ACameraFit
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
