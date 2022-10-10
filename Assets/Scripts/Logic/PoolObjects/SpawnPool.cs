using System;
using System.Collections.Generic;
using StaticData;
using UnityEngine;

namespace Logic.PoolObjects
{
    public class SpawnPool: MonoBehaviour
    {
        public PoolObjectsNames poolObjectsName;
        [SerializeField] private EnemySO poolObjectSO;
        [SerializeField] private int poolObjectsCount;

        private List<GameObject> objects = new List<GameObject>();

        private void Start()
        {
            Initialize();
        }

        public void ActivateObject(Vector3 position)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (!objects[i].activeSelf)
                {
                    objects[i].transform.position = position;
                    objects[i].SetActive(true);
                    return;
                }
            }
        }

        public void ReturnObject(int number) => 
            objects[number].SetActive(false);

        public void DeactivateAllObjects()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].SetActive(false);
            }
        }
        
        private void Initialize()
        {
            for (int i = 0; i < poolObjectsCount; i++)
            {
                    var gameObject = Instantiate(poolObjectSO.prefab, transform.position, Quaternion.identity, transform);
                    objects.Add(gameObject);
                    gameObject.GetComponent<PoolObject>().objectNumber = i;
                    gameObject.SetActive(false);
            }
        }
    }
}