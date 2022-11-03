using System;

namespace Configs
{
    [Serializable]
    public struct CockroachConfig
    {
        public float baseSpeed;
        public float accelerationSpeed;
        public float accelerationTime;
        public float safeDistance;
        public float chasingAcceleration;
    }
}