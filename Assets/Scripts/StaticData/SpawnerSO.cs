using System;
using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New SpawnerSO", menuName = "SO/SpawnerSO")]
    [Serializable]
    public class SpawnerSO: ScriptableObject
    {
        public List<EnemySO> enemySos;
        public float spawnInterval;
    }
}