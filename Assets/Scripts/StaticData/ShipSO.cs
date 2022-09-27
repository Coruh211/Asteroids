using System;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New ShipSO", menuName = "SO/ShipSO")]
    [Serializable]
    public class ShipSO: ScriptableObject
    {
        public GameObject shipPrefab;
        public float moveSpeed;
        public float maxMoveSpeed;
        public float rotateSpeed;
    }
}