using UnityEngine;
using System;
using RPG.Itens;

//namespace RPG.Systems
//{
    [Serializable]
    public class ItemStack
    {
        public Item item;
        public int quantity;

        public ItemStack(Item item, int quant = 1) {
            this.quantity = quant;
            this.item = item;
        }
    }

    public class InventorySystem : MonoBehaviour {

        [SerializeField]
        private ItemStack[] itens;
        public delegate void ItemHandler (Item item);

        /// <summary>
        /// Return the id of the first empty slot in the inventory. -1 in case of full inventory.
        /// </summary>
        /// <returns>The slot id</returns>
        private int FirstEmpty()
        {
            for (int i = 0; i < itens.Length; i++) {
            if (itens [i].item == null)
                    return i;
            }

            return -1;
        }

        private ItemStack Find(Item item) 
        {
            return Array.Find(itens, (it) => {
            return it.item != null && it.item.itemName == item.itemName;
            });
        }

        private void DestroyItem(int id) {
            ItemStack itemStack = itens[id];
            if (itemStack == null)
                return;
            itens[id] = null;
            Destroy(itemStack.item.gameObject);
        }

        /// <summary>
        /// Get one ItemStack by id.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public ItemStack Get(int id)
        {
            if (id < 0 || id > itens.Length)
                return null;

            return itens [id];
        }

        /// <summary>
        /// Gets all ItemStack.
        /// </summary>
        /// <returns>An array of itens</returns>
        public ItemStack[] GetAll()
        {
            return itens;
        }

        /// <summary>
        /// Add the specified ItemStack to the inventory. Returns false if cannot add the item 
        /// (inventory full and/or no stack of the specified item. If the item is not stackable the parameter quantity is ignored.
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <param name="quantity">Quantity of itens to add.</param>
        /// <returns><c>true</c> if the item added to inventory; otherwise, <c>false</c>.</returns>
        public bool Add(Item item, int quantity)
        {
            if (item.isStackable)
            {
                ItemStack i = Find(item);
                if (i != null)
                {
                    i.quantity += quantity;
                    print(this);
                    return true;
                }
            }


            int slot = FirstEmpty();
            if (slot == -1)
            {
                return false;
            }

            itens[slot] = new ItemStack(item);
            print(this);
            return true;
        }

        /// <summary>
        /// Determines if the inventory has a empty slot.
        /// </summary>
        /// <returns><c>true</c> if the inventory has empty slot; otherwise, <c>false</c>.</returns>
        public bool HasEmptySlot() 
        {
            return FirstEmpty() != -1;
        }

        /// <summary>
        /// Remove the quantity of itens from the specified id. If the item is not stackable the parameter quantity is ignored.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="quantity">Quantity.</param>
        public void Remove(int id, int quantity)
        {
            if (id < 0 || id > itens.Length)
                return;

            ItemStack i = itens[id];
            if (i == null)
                return;

            if (i.item.isStackable)
            {
                i.quantity -= quantity;
                if (i.quantity <= 0)
                {
                    DestroyItem(id);
                }
            }
            else
            {
                DestroyItem(id);
            }
        }

        /// <summary>
        /// Removes all itens of the specified id.
        /// </summary>
        /// <param name="id">The id of the item.</param>
        public void RemoveAll(int id) 
        {
            if (itens[id] == null)
            {
                return;
            }
            DestroyItem(id);
        }

        /// <summary>
        /// Expands the inventory by the quantity.
        /// </summary>
        /// <param name="quantity">Quantity.</param>
        public void Expand(int quantity)
        {
            System.Array.Resize (ref itens, itens.Length + quantity);
        }

        public void UseItem(int id, GameObject otherObj=null)
        {
            if (id < 0 || id > itens.Length)
                return;
            ItemStack i = itens [id];
            if (i == null)
                return;

            i.item.Use (otherObj ?? gameObject);
            i.quantity--;
            if (i.quantity == 0)
                DestroyItem(id);
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in itens)
            {
                if (item.item != null) {
                    str += string.Format ("{0}({1})\n", item.item, item.quantity);
                }
            }
            return str;
        }
    }

//}