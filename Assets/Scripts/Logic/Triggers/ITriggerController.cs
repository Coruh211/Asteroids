using UnityEngine;

namespace Logic.Enemy
{
    public interface ITriggerController
    {
        public void OnTriggerEnter(Collider other);
    }
}