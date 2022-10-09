using StaticData;
using UnityEngine;

namespace Logic.Enemy
{
    public class AsterPresenter : MonoBehaviour
    {
        private Vector3 _randomDirection;
        private AutoDestroy autoDestroy;
        private EnemySO _enemySo;

        private void Start()
        {
            autoDestroy = new AutoDestroy(gameObject);
            _enemySo = GetComponent<CurrentSOContainer>().EnemySo;
            _randomDirection = new Vector3( 0, 0 , Random.Range(0, 360));
            transform.Rotate(_randomDirection);
        }

        private void FixedUpdate() => 
            transform.Translate(new Vector3(0, _enemySo.moveSpeed, 0));
    }
}