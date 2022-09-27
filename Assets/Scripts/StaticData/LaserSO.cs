using System;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New LaserSO", menuName = "SO/LaserSO")]
    [Serializable]
    public class LaserSO: ScriptableObject
    {
        public GameObject laserPrefab;
        public float laserKd;
        public int lasersCount;
    }
}