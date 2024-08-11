using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gilzoide.CameraFit.Internal
{
    public static class BoundsExtensions
    {
        public static BoundsCornerEnumerable EnumerateCorners(this Bounds bounds)
        {
            return new BoundsCornerEnumerable(bounds);
        }
    }

    public struct BoundsCornerEnumerable : IEnumerable<Vector3>
    {
        public Bounds Bounds { get; private set; }

        public BoundsCornerEnumerable(Bounds bounds)
        {
            Bounds = bounds;
        }

        public BoundsCornerEnumerator GetEnumerator()
        {
            return new BoundsCornerEnumerator(Bounds);
        }

        IEnumerator<Vector3> IEnumerable<Vector3>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public struct BoundsCornerEnumerator : IEnumerator<Vector3>
    {
        public const int CornerCount = 8;

        private Vector3 _min;
        private Vector3 _max;

        private int _cornerIndex;

        public BoundsCornerEnumerator(Bounds bounds)
        {
            _min = bounds.min;
            _max = bounds.max;
            _cornerIndex = 0;
        }

        public Vector3 Current
        {
            get
            {
                switch (_cornerIndex)
                {
                    case 0: return new Vector3(_min.x, _min.y, _min.z);
                    case 1: return new Vector3(_min.x, _min.y, _max.z);
                    case 2: return new Vector3(_min.x, _max.y, _min.z);
                    case 3: return new Vector3(_min.x, _max.y, _max.z);
                    case 4: return new Vector3(_max.x, _min.y, _min.z);
                    case 5: return new Vector3(_max.x, _min.y, _max.z);
                    case 6: return new Vector3(_max.x, _max.y, _min.z);
                    case 7: return new Vector3(_max.x, _max.y, _max.z);
                    default: return Vector3.zero;
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_cornerIndex < CornerCount)
            {
                _cornerIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _cornerIndex = 0;
        }
    }
}
