using Infrastructure.AssetManagement;
using StaticData;
using UniRx;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class BulletMove: MonoBehaviour
    {
        private float _speed;
        private BulletSO _bulletSo;

        private void Start()
        {
            _bulletSo = AssetContainer.BulletSo;
            _speed = _bulletSo.bulletSpeed;
            StartAutoDestroy();
        }
        
        private void FixedUpdate()
        {
            transform.Translate(new Vector3(0,_speed, 0));
        }
        
        private void StartAutoDestroy()
        {
            Observable.Timer(_bulletSo.bulletAutoDestroyTime.sec()).TakeUntilDisable(gameObject)
                .Subscribe(x => Destroy(gameObject));
        }
    }
}