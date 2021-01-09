using UnityEngine;


namespace Game.Inventory
{
    [CreateAssetMenu(menuName = "Game/Inventory/Create new inventory item", order = 1)]
    public class InventoryItem : ScriptableObject
    {
        [SerializeField]
        private string itemName;
        [SerializeField]
        private string itemDescription;
        [SerializeField]
        private GameObject itemPrefab;


        public string Name => itemName;
        public string Description => itemDescription;
        public GameObject Prefab => itemPrefab;
    }
}
