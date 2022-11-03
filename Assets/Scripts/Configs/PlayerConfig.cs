using System;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public struct PlayerConfig
    {
        public float triggetDistance;
        // [SerializeField] private float triggetDistance;
        // public float TriggetDistance => Mathf.Pow(triggetDistance, 2);
    }
}