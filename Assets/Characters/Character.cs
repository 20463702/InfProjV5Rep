using System;
using Items.Inventory;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Weaponry;

namespace Characters
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody;
        [SerializeField] protected Transform respawn;
        [field: NonSerialized] protected float Speed = 4f;
        public AbstractWeapon Weapon;

        public float health;
        public InventorySystem Inventory { get; protected set; }
        protected float MaxHealth;
        protected void Start()
        {
            Inventory = gameObject.GetComponentInChildren<InventorySystem>();
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.gravityScale = 0;
            Rigidbody.freezeRotation = true;
            MaxHealth = health;
        }

        protected void Update()
        {
            Weapon.UpdateDeltaTime();
        }

        #region Character Movement

        protected virtual void Movement() { }

        /// <param name="valH">Horizontal Value</param>
        /// <param name="valV">Vertical Value</param>
        protected void Move(float valH, float valV) =>
            Rigidbody.velocity = new Vector2(valH * Speed, valV * Speed);
        
#endregion Character Movement

        protected virtual void Attack()
        {
            if (Weapon.DeltaTimeBetweenAttacks > 0)
            {
                Weapon.UpdateDeltaTime();
                return;
            }
        }

        public void TakeDamage(AbstractWeapon w)
        {
            health -= w.Damage;
            if (health <= 0f)
                Die();
            Debug.Log(health);
        } 
        void Die()
        {
            transform.position = respawn.position;  
            health = MaxHealth;
        }
    }
}
