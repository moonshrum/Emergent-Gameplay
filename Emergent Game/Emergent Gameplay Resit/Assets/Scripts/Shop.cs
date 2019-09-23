using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<Category> AllCategories = new List<Category>();
    public List<GameObject> AllCategoryButtons = new List<GameObject>();

    public GameObject ItemPrefab; // A prefab to be instantiated in the Item Container

    public Sprite SelectedCategorySprite;
    public Sprite DeselectedCategorySprite;
    private void Start()
    {
        TextAsset itemRecipes = Resources.Load<TextAsset>("ItemRecipes");
        JsonData itemRecipesJson = JsonMapper.ToObject(itemRecipes.text);
        for (int i = 0; i < itemRecipesJson["Recipes"].Count; i++)
        {
            for (int j = 0; j < itemRecipesJson["Recipes"][i]["RequieredResources"].Count; j++)
            {
                //Debug.Log(itemRecipesJson["Recipes"][i]["RequieredResources"][j]["ResourceType"].ToString());
                int number;
                number = int.Parse(itemRecipesJson["Recipes"][i]["RequieredResources"][j]["Amount"].ToString());
                //Debug.Log(number);
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
                    //Debug.Log(itemRecipesJson["Recipes"][i]["Recipe"][j].ToString());
                }
            }
        }
        return false;
    }

    public void SelectCategory(Object category)
    {
        GameObject _category = (GameObject)category;
        foreach (GameObject button in AllCategoryButtons)
        {
            button.GetComponent<Image>().sprite = DeselectedCategorySprite;
        }
        _category.GetComponentInChildren<Image>().sprite = SelectedCategorySprite;
    }
}
