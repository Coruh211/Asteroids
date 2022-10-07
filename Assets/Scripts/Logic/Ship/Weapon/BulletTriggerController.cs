using Logic.Enemy;
using UnityEngine;

namespace Logic.Ship.Weapon
{
    public class BulletTriggerController: MonoBehaviour, ITriggerController
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagsContainer.Enemy))
            {
                Destroy(gameObject);
            }
        }
    }
}