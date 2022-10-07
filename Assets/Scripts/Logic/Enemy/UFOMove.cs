using System;
using Infrastructure.AssetManagement;
using StaticData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Logic.Enemy
{
    public class UFOMove: MonoBehaviour
    {
        [SerializeField] private EnemySO _enemySo;
        
        private GameObject _player;
        
        private void Start()
        {
            _player = GameObject.FindWithTag(TagsContainer.Player);
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