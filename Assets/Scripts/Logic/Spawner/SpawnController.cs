using System;
using Logic.Enemy;
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
        private readonly GameObject _spawnContainer;
        private readonly SpawnerSO _spawnerSo;
        private IDisposable dispose;
        

        public SpawnController(GameObject[] spawnPoints, GameObject spawnContainer)
        {
            _spawnContainer = spawnContainer;
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

                    Object.Instantiate(_spawnerSo.enemySos[randomEnemy].prefab,
                        _spawnPoints[randomPoint].transform.position,
                        Quaternion.identity, _spawnContainer.transform);
                });
        }

        private void StopSpawn()
        {
            dispose?.Dispose();
            
            var objects = GameObject.FindGameObjectsWithTag(TagsContainer.Enemy);
            
            for (int i = 0; i < objects.Length; i++)
            {
                Object.Destroy(objects[i].gameObject);
            }
        }
            
    }
}