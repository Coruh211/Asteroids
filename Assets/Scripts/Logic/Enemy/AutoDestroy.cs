using UniRx;
using UnityEngine;

namespace Logic.Enemy
{
    public class AutoDestroy
    {
        private float timeDestroy = 20f;
        private GameObject targetObject;

        public AutoDestroy(GameObject gameObject)
        {
            targetObject = gameObject;
            StartTimer();
        }

        private void StartTimer()
        {
            Observable.Timer(timeDestroy.sec()).TakeUntilDisable(targetObject)
                .Subscribe(x => GameObject.Destroy(targetObject));
        }
    }
}