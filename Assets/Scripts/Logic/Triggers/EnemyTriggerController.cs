using System;
using Infrastructure.Services;
using Logic.PoolObjects;
using StaticData;
using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyTriggerController: MonoBehaviour, ITriggerController
    {
        [SerializeField] private PoolObjectsNames name;
        private IScoreController _scoreController;
        public Action Destroyed;
        private EnemySO enemySo;

        private void Start()
        {
            _scoreController = AllServices.Container.Single<IScoreController>();
            enemySo = GetComponent<CurrentSOContainer>().EnemySo;
        }
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagsContainer.Weapon))
            {
                _scoreController.AddScore(enemySo.scoreForDestroy);
                DestroyUnit();
                Destroyed?.Invoke();
            }
            else if(other.CompareTag(TagsContainer.Player))
            {
                DestroyUnit();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(TagsContainer.Level))
            {
                DestroyUnit();
            }
        }

        private void DestroyUnit()
        {
            var spawnPool = PoolsContainer.Instance.GetCurrentPool(name);
            spawnPool.ReturnObject(GetComponent<PoolObject>().objectNumber);
        }
    }
}