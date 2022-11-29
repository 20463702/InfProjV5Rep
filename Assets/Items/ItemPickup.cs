using Items.Inventory;
using Items.ItemData;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ItemPickup : MonoBehaviour
    {
        public InventoryItemData itemData;

        private BoxCollider2D _boxCollider;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            _boxCollider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D c)
        {
            var inventory = c.transform.GetComponent<InventoryContainer>();
            if (!inventory) return;

            if (inventory.InvSys.AddToInventory(itemData))
                Destroy(gameObject);
        }
    }
}
