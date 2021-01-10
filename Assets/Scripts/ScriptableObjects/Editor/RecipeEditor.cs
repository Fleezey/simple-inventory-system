using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

namespace Game.Inventory
{
    public class RecipeEditor : EditorWindow
    {
        private int itemCount = 0;
        private List<InventoryItem> items = new List<InventoryItem>();
        private InventoryItem outputItem;


        private void OnGUI()
        {
            DrawRequiredItems();
            DrawOutputItem();

            EditorGUILayout.Space(5f);

            if (GUILayout.Button("Add recipe")) {
                var newItem = Recipe.CreateParameterizedInstance(items, outputItem);

                AssetDatabase.CreateAsset(newItem, "Assets/Scripts/ScriptableObjects/Recipes/test.asset");
                AssetDatabase.SaveAssets();

                RecipeBook.GetRecipeKey(items.ToArray());

                ClearItemFields();
            }
        }

        private void DrawRequiredItems()
        {
            GUILayout.Label("Required items");
            itemCount = EditorGUILayout.IntField("Item count", itemCount);

            if (itemCount != items.Count)
            {
                List<InventoryItem> newItems = new List<InventoryItem>(items);

                int countDelta = itemCount - newItems.Count;

                if (countDelta < 0)
                {
                    // Remove
                    while (newItems.Count != itemCount)
                    {
                        newItems.RemoveAt(newItems.Count - 1);
                    }
                }
                else if (countDelta > 0)
                {
                    // Add
                    while (newItems.Count != itemCount)
                    {
                        newItems.Add(null);
                    }
                }

                items = newItems;
            }

            if (itemCount != 0)
            {
                EditorGUILayout.Space(5f);
            }

            for (int i = 0; i < itemCount; i++)
            {
                items[i] = EditorGUILayout.ObjectField(items[i], typeof(InventoryItem), true) as InventoryItem;
            }
        }

        private void DrawOutputItem()
        {
            GUILayout.Label("Crafted item");
            outputItem = EditorGUILayout.ObjectField(outputItem, typeof(InventoryItem), true) as InventoryItem;
        }

        private void ClearItemFields()
        {
            itemCount = 0;
            items.Clear();
            outputItem = null;
        }


        [MenuItem("Window/Recipe Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<RecipeEditor>("Recipe Editor");
        }
    }
}
