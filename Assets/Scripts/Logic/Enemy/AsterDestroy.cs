using Logic.PoolObjects;
using StaticData;
using UnityEngine;

namespace Logic.Enemy
{
    public class AsterDestroy: MonoBehaviour
    {
        [SerializeField] private PoolObjectsNames _poolObjectsName;
        [SerializeField] private int spawnedAsterCount;

        private void Start()
        {
            GetComponent<EnemyTriggerController>().Destroyed += SpawnMiniAster;
        }

        private void SpawnMiniAster()
        {
            for (int i = 0; i < spawnedAsterCount; i++)
            {
                PoolsContainer.Instance.GetCurrentPool(_poolObjectsName).ActivateObject(transform.position);
            }
        }
    }
}