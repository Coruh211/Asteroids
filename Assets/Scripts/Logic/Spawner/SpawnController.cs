using System;
using Logic.Enemy;
using Logic.PoolObjects;
using StaticData;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Logic.Spawner
{
    public class SpawnController
    {
        private readonly GameObject[] _spawnPoints;
        private readonly SpawnerSO _spawnerSo;
        private IDisposable dispose;
        

        public SpawnController(GameObject[] spawnPoints)
        {
            _spawnPoints = spawnPoints;
            _spawnerSo = AssetContainer.SpawnerSO;
            EventManager.OnStartGame.Subscribe(SpawnEnemy);
            EventManager.OnEndGame.Subscribe(StopSpawn);
        }
        
        private void SpawnEnemy()
        {
            dispose = Observable.Interval(_spawnerSo.spawnInterval.sec())
                .Subscribe(x =>
                {
                    var randomEnemy = Random.Range(0, _spawnerSo.enemySos.Count);
                    var randomPoint = Random.Range(0, _spawnPoints.Length);

                    var spawnPool = PoolsContainer.Instance.GetRandomPool(randomEnemy);
                    spawnPool.ActivateObject(_spawnPoints[randomPoint].transform.position);
                });
        }

        private void StopSpawn()
        {
            dispose?.Dispose();
            
            PoolsContainer.Instance.ReturnAllPools();
        }
            
    }
}