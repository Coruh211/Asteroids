using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyTriggerController: MonoBehaviour, ITriggerController
    {
        public Action Destroyed;
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TagsContainer.Weapon))
            {
                Destroy(gameObject);
                Destroyed?.Invoke();
            }
            else if (other.CompareTag(TagsContainer.Player))
            {
                Destroy(gameObject);
            }
        }
    }
}