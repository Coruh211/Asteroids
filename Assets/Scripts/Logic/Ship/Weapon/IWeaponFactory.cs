using Infrastructure.Services;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public interface IWeaponFactory: IService
    {
        public void CreateWeapon(GameObject obj, GameObject parent, GameObject spawnPoint);
    }
}