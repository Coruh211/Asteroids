using Infrastructure.AssetManagement;
using StaticData;
using UnityEngine;

namespace Logic.Enemy
{
    public class AsterMove : MonoBehaviour
    {
        [SerializeField] private EnemySO _enemySo;
        
        private Vector3 _randomDirection;

        private void Start()
        {
            _randomDirection = new Vector3( 0, 0 , Random.Range(0, 360));
            transform.Rotate(_randomDirection);
        }

        private void FixedUpdate() => 
            transform.Translate(new Vector3(0, _enemySo.moveSpeed, 0));
    }
}