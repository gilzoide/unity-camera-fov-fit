using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Gilzoide.CameraFit
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

        private Vector3 _corner0;
        private Vector3 _corner1;
        private Vector3 _corner2;
        private Vector3 _corner3;
        private Vector3 _corner4;
        private Vector3 _corner5;
        private Vector3 _corner6;
        private Vector3 _corner7;
        private int _cornerIndex;

        public BoundsCornerEnumerator(Bounds bounds)
        {
            Vector3 min = bounds.min;
            Vector3 max = bounds.max;

            _corner0 = new Vector3(min.x, min.y, min.z);
            _corner1 = new Vector3(min.x, min.y, max.z);
            _corner2 = new Vector3(min.x, max.y, min.z);
            _corner3 = new Vector3(min.x, max.y, max.z);
            _corner4 = new Vector3(max.x, min.y, min.z);
            _corner5 = new Vector3(max.x, min.y, max.z);
            _corner6 = new Vector3(max.x, max.y, min.z);
            _corner7 = new Vector3(max.x, max.y, max.z);
            _cornerIndex = 0;
        }

        public unsafe Vector3 Current => ((Vector3*) UnsafeUtility.AddressOf(ref _corner0))[_cornerIndex];

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
