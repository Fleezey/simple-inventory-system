using System.Collections.Generic;
using UnityEngine;


namespace Game.Inventory
{
    public class Recipe : ScriptableObject
    {
        [SerializeField]
        private List<InventoryItem> requiredItems = new List<InventoryItem>();
        [SerializeField]
        private InventoryItem outputItem;


        public InventoryItem OutputItem => outputItem;


        public static Recipe CreateParameterizedInstance(List<InventoryItem> inputItems, InventoryItem outputItem)
        {
            var data = CreateInstance<Recipe>();
            data.requiredItems = new List<InventoryItem>(inputItems);
            data.outputItem = outputItem;
            return data;
        }
    }
}
