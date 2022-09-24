using System;
using Infrastructure.Services;
using Services.Input;
using UnityEngine;

namespace Logic.Ship
{
    public class ShipMove: MonoBehaviour
    {
        [SerializeField] private float forcePower;

        private Rigidbody rigidbody;
        
        public void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            GeneralInputSystem.Instance.OnHoldTap += MoveShip;
        }

        private void MoveShip()
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(Vector3.up * forcePower);
        }
    }
}