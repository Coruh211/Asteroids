using Logic.PoolObjects;
using StaticData;
using UnityEngine;

namespace Logic.Enemy
{
    public class AsterPresenter : MonoBehaviour
    {
        [SerializeField] private PoolObjectsNames name;
        
        private Vector3 _randomDirection;
        private EnemySO _enemySo;
        private int _number;
        
        private void Start()
        {
            _number = GetComponent<PoolObject>().objectNumber;
            _enemySo = GetComponent<CurrentSOContainer>().EnemySo;
            _randomDirection = new Vector3( 0, 0 , Random.Range(0, 360));
            transform.Rotate(_randomDirection);
        }

        private void FixedUpdate() => 
            transform.Translate(new Vector3(0, _enemySo.moveSpeed, 0));
    }
}