using System;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New BulletSO", menuName = "SO/BulletSO")]
    [Serializable]
    public class BulletSO: ScriptableObject
    {
        public GameObject bulletPrefab;
        public float bulletSpawnInterval;
        public float bulletSpeed;
        public float bulletAutoDestroyTime;
    }
}