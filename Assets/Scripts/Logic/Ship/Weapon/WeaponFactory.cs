using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class WeaponFactory: IWeaponFactory
    {
        public void CreateWeapon(GameObject obj, GameObject parent, GameObject spawnPoint) 
            => Object.Instantiate(obj, spawnPoint.transform.position, parent.transform.rotation);
    }
}