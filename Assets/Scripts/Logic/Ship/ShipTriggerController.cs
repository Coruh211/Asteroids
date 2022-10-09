using Logic.Enemy;
using UnityEngine;

namespace Logic.Ship
{
    public class ShipTriggerController: MonoBehaviour, ITriggerController
    {
        [SerializeField] private GameObject shipSprite;
        public void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(TagsContainer.Enemy))
            {
                EventManager.OnEndGame.Invoke();
                shipSprite.SetActive(false);
            }
        }
    }
}