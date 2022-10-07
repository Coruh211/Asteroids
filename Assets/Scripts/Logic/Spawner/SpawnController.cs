using Infrastructure.AssetManagement;
using StaticData;
using UniRx;
using UnityEngine;

namespace Logic.Spawner
{
    public class SpawnController
    {
        private readonly GameObject[] _spawnPoints;
        private readonly SpawnerSO _spawnerSo;
        private bool _canSpawn = true; 

        public SpawnController(GameObject[] spawnPoints, GameObject player)
        {
            _spawnPoints = spawnPoints;
            _spawnerSo = AssetContainer.SpawnerSO;
            EventManager.OnStartGame.Subscribe(SpawnEnemy);
            EventManager.OnEndGame.Subscribe(StopSpawn);
        }

        private void SpawnEnemy()
        {
            if (!_canSpawn)
                return;
            
            var randomEnemy = Random.Range(0, _spawnerSo.enemySos.Count);
            var randomPoint = Random.Range(0, _spawnPoints.Length);
            
            Object.Instantiate(_spawnerSo.enemySos[randomEnemy].prefab, _spawnPoints[randomPoint].transform.position,
                Quaternion.identity, _spawnPoints[randomPoint].transform);
            
            
            Observable.Timer(_spawnerSo.spawnInterval.sec())
                .Subscribe(x => SpawnEnemy());
        }

        private void StopSpawn() =>
            _canSpawn = false;
    }
}