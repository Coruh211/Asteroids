using StaticData;
using UnityEngine;

namespace Logic.Enemy
{
    public class AsterDestroy: MonoBehaviour
    {
        [SerializeField] private EnemySO miniAster;
        [SerializeField] private int spawnedAsterCount;
        
        private void Start()
        {
            GetComponent<EnemyTriggerController>().Destroyed += SpawnMiniAster;
        }

        private void SpawnMiniAster()
        {
            for (int i = 0; i < spawnedAsterCount; i++)
            {
                Instantiate(miniAster.prefab, transform.position, Quaternion.identity, gameObject.transform.parent);
            }
        }
    }
}