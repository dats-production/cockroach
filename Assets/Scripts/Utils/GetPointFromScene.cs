using System;
using UnityEngine;

namespace Utils
{
    public class GetPointFromScene : MonoBehaviour
    {
        [Serializable]
        private struct Point
        {
            public Transform Transform;
            public string Key;
        }

        [SerializeField] private Point[] points;
        
        public Transform GetPoint(string key)
        {
            foreach (var point in points)
                if (key == point.Key)
                    return point.Transform;
            throw new Exception($"No position on scene with key {key} was found!");
        }
    }
}