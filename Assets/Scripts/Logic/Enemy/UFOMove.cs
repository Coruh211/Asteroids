using StaticData;
using UnityEngine;


namespace Logic.Enemy
{
    public class UFOMove: MonoBehaviour
    {
        private EnemySO _enemySo;
        private GameObject _player;
        
        private void Start()
        {
            _player = GameObject.FindWithTag(TagsContainer.Player);
            _enemySo = GetComponent<CurrentSOContainer>().EnemySo;
        }

        private void FixedUpdate()
        {
            if(_player == null)
                return;
            
            transform.position =
                Vector2.MoveTowards(transform.position, _player.transform.position, _enemySo.moveSpeed);
        }
    }
}