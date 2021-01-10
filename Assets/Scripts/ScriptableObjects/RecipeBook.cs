using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace Game.Inventory
{
    public class RecipeBook : ScriptableObject
    {
        private Dictionary<string, Recipe> recipes = new Dictionary<string, Recipe>();


        public InventoryItem GetItem(InventoryItem[] items)
        {
            string recipeKey = GetRecipeKey(items);

            if (recipes.TryGetValue(recipeKey, out Recipe recipe))
            {
                return recipe.OutputItem;
            }

            return null;
        }

        public static string GetRecipeKey(params InventoryItem[] items)
        {
            List<string> itemIds = new List<string>();
            foreach (var item in items)
            {
                itemIds.Add(item.GetInstanceID().ToString());
            }

            itemIds.Sort();
            string recipeKey = itemIds.Aggregate((itemKey, itemId) => itemKey + "~" + itemId);

            return itemIds.ToString();
        }
        
    }
}
