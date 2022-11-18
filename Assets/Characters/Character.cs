using System;
using Items.Inventory;
using UnityEngine;
using Weaponry;

namespace Characters
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody;
        [field: NonSerialized]
        protected float Speed = 4f;
        public float Health { get; private set; }
        public InventorySystem Inventory { get; protected set; }

        protected void Start()
        {
            Inventory = gameObject.GetComponentInChildren<InventorySystem>();
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.gravityScale = 0;
            Rigidbody.freezeRotation = true;
        }
        
#region Character Movement

        protected virtual void Movement() { }

        /// <param name="valH">Horizontal Value</param>
        /// <param name="valV">Vertical Value</param>
        protected void Move(float valH, float valV) =>
            Rigidbody.velocity = new Vector2(valH * Speed, valV * Speed);
        
#endregion Character Movement

        public void TakeDamage(AbstractWeapon w) =>
            Health -= w.Damage;
    }
}
