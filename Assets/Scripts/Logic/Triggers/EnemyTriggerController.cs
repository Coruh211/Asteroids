using System;
using Infrastructure.Services;
using StaticData;
using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyTriggerController: MonoBehaviour, ITriggerController
    {
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
        
        private void DestroyUnit()
        {
            Destroy(gameObject);
        }
    }
}