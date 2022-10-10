using StaticData;
using UnityEngine;

namespace Logic.PoolObjects
{
    public class PoolsContainer : Singleton<PoolsContainer>
    {
        [SerializeField] private SpawnPool[] pools;

        public SpawnPool GetCurrentPool(PoolObjectsNames name)
        {
            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].poolObjectsName == name)
                {
                    return pools[i];
                }
            }

            return null;
        }

        
        public SpawnPool GetRandomPool(int number) => 
            pools[number];
        
        public void ReturnAllPools()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].DeactivateAllObjects();
            }
        }
    }
}