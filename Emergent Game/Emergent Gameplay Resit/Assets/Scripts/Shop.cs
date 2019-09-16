using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Item> AllItems = new List<Item>();

    private void Start()
    {
        TextAsset itemRecipes = Resources.Load<TextAsset>("ItemRecipes");
        JsonData itemRecipesJson = JsonMapper.ToObject(itemRecipes.text);
        for (int i = 0; i < itemRecipesJson["Recipes"].Count; i++)
        {
            for (int j = 0; j < itemRecipesJson["Recipes"][i]["Recipe"].Count; j++)
            {
                for (int k = 0; k < itemRecipesJson["Recipes"][i]["Recipe"][j].Count; k++)
                {
                    Debug.Log(itemRecipesJson["Recipes"][i]["Recipe"][j]["RequieredResource1"].ToString());
                }
            }
        }
    }


    public bool PurchaseItem(Item item)
    {
        TextAsset itemRecipes = Resources.Load<TextAsset>("ItemRecipes");
        JsonData itemRecipesJson = JsonMapper.ToObject(itemRecipes.text);
        for (int i = 0; i < itemRecipesJson["Recipes"].Count; i++)
        {
            if (itemRecipesJson["Recipes"][i]["Name"].ToString() == item.Name)
            {
                for (int j = 0; j < itemRecipesJson["Recipes"][i]["Recipe"].Count; j++)
                {
                    Debug.Log(itemRecipesJson["Recipes"][i]["Recipe"][j].ToString());
                }
            }
        }
        

        return false;
    }
}
