using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class WeaponFactory
    {
        public void CreateWeapon(GameObject obj, GameObject parent, GameObject spawnPoint) 
            => Object.Instantiate(obj, spawnPoint.transform.position, parent.transform.rotation);
    }
}