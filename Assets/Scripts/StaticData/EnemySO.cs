using System;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New EnemySO", menuName = "SO/EnemySO")]
    [Serializable]
    public class EnemySO: ScriptableObject
    {
        public PoolObjectsNames Name;
        public GameObject prefab;
        public float moveSpeed;
        public int scoreForDestroy;
    }
}

