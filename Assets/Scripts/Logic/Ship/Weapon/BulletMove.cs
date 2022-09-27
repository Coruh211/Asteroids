using Infrastructure.AssetManagement;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class BulletMove: MonoBehaviour
    {
        private float _speed;

        private void Start()
        {
            _speed = AssetContainer.BulletSo.bulletSpeed;
        }

        private void Update()
        {
            transform.Translate(new Vector3(0,_speed, 0));
        }
    }
}