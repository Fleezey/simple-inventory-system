using System.Collections.Generic;
using UnityEngine;


namespace Game.Inventory
{
    [CreateAssetMenu(menuName = "Game/Inventory/Create new inventory", order = 0)]
    public class Inventory : ScriptableObject
    {
        public List<InventoryItem> items = new List<InventoryItem>();


        public void AddItem(InventoryItem item)
        {
            if (!Contains(item))
            {
                items.Add(item);
            }
        }

        public void RemoveItem(InventoryItem item)
        {
            if (Contains(item))
            {
                items.Remove(item);
            }
        }

        public bool Contains(InventoryItem item)
        {
            return items.Contains(item);
        }
    }
}
