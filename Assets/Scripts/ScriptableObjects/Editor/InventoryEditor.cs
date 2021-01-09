using UnityEngine;
using UnityEditor;


namespace Game.Inventory
{
    [CustomEditor(typeof(Inventory), editorForChildClasses: true)]
    public class InventoryEditor : Editor
    {
        public InventoryItem item;


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying)
            {
                GUILayout.Space(20f);
                GUILayout.Label("Inventory Management");

                RenderInventoryAssetPicker();

                if (item != null)
                {
                    GUILayout.Space(5f);
                    RenderInventoryManagementButtons();
                }
            }
        }

        private void RenderInventoryAssetPicker()
        {
            item = EditorGUILayout.ObjectField(item, typeof(InventoryItem), true) as InventoryItem;
        }

        private void RenderInventoryManagementButtons()
        {
            Inventory inventory = target as Inventory;

            if (!inventory.Contains(item))
            {
                if (GUILayout.Button("Add item"))
                {
                    inventory.AddItem(item);
                    item = null;
                }
            }
            else
            {
                if (GUILayout.Button("Remove item"))
                {
                    inventory.RemoveItem(item);
                    item = null;
                }
            }
        }
    }
}
