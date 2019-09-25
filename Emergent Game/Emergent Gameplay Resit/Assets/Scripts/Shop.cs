using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [System.NonSerialized]
    public int CategoryIndex = 0;
    public List<Category> AllCategories = new List<Category>();
    public List<GameObject> AllCategoryButtons = new List<GameObject>();
    public List<GameObject> AllItemContainers = new List<GameObject>();

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

    public void ChangeShopCategory(string _direction)
    {
        int _categoriesCount = AllCategoryButtons.Count;
        foreach (GameObject button in AllCategoryButtons)
        {
            button.GetComponent<Image>().sprite = DeselectedCategorySprite;
        }
        foreach (GameObject container in AllItemContainers)
        {
            container.SetActive(false);
        }
        if (_direction == "Down")
        {
            if (CategoryIndex < _categoriesCount - 1)
            {
                CategoryIndex++;
            }
            else if (CategoryIndex == _categoriesCount - 1)
            {
                CategoryIndex = 0;
            }
        } else if (_direction == "Up")
        {
            if (CategoryIndex == 0)
            {
                CategoryIndex = _categoriesCount - 1;
            } else
            {
                CategoryIndex--;
            }
        }
        AllCategoryButtons[CategoryIndex].GetComponent<Image>().sprite = SelectedCategorySprite;
        AllItemContainers[CategoryIndex].SetActive(true);
    }
}
