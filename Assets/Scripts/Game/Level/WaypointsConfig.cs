using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Level
{
    [CreateAssetMenu(fileName = "WaypointsConfig", menuName = "SO/WaypointsConfig")]
    public class WaypointsConfig : ScriptableObject
    {
        public List<WayPoint> WayPoints = new List<WayPoint>();
    }
    
    [Serializable]
    public class WayPoint
    {
        public Vector3 position;
        public Vector3 rotation;
    }
}

