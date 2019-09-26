using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [System.NonSerialized]
    public int CategoryIndex = 0;
    public int ItemIndex = 0;
    public List<Category> AllCategories = new List<Category>();
    public List<GameObject> AllCategoryButtons = new List<GameObject>();
    public GameObject ItemContainer;
    public GameObject RecipeContainer;

    public GameObject ItemPrefab; // A prefab to be instantiated in the Item Container
    public GameObject RecipeElementPrefab; // A prefab to be instantiated in the Recipe Container

    public Sprite SelectedCategorySprite;
    public Sprite DeselectedCategorySprite;

    public Item SelectedItem;
    public Category SelectedCategory;

    private void Awake()
    {
        AllCategories[0].InstantiateItemPrefabsInTheContainer();
        SelectedCategory = AllCategories[0];
        SelectItem(0);
    }


    public void CraftItem(Item item, Player player)
    {
        TextAsset itemRecipes = Resources.Load<TextAsset>("ItemRecipes");
        JsonData itemRecipesJson = JsonMapper.ToObject(itemRecipes.text);
        bool canCraft = false;
        int counter = 0; // Counter that checks if the player has enough of each resource needed to craft an item
        for (int i = 0; i < itemRecipesJson["Recipes"].Count; i++)
        {
            if (itemRecipesJson["Recipes"][i]["Name"].ToString() == item.Name)
            {
                for (int j = 0; j < itemRecipesJson["Recipes"][i]["RequieredResources"].Count; j++)
                {
                    JsonData ItemInfo = itemRecipesJson["Recipes"][i]["RequieredResources"][j];
                    foreach (Resource resource in player.AllResources)
                    {
                        Resource.ResourceType resourceType = (Resource.ResourceType)System.Enum.Parse(typeof(Resource.ResourceType), ItemInfo["ResourceType"].ToString());
                        if (resource.Type == resourceType)
                        {
                            int amountNeeded = int.Parse(ItemInfo["Amount"].ToString());
                            if (resource.Amount >= amountNeeded)
                            {
                                counter++;
                            }
                        }
                    }
                    if (counter == itemRecipesJson["Recipes"][i]["RequieredResources"].Count)
                    {
                        canCraft = true;
                    }
                }
            }
        }
        Debug.Log(canCraft);
    }

    public void SelectingShopCategory(string _direction)
    {
        int _categoriesCount = AllCategoryButtons.Count;
        foreach (GameObject button in AllCategoryButtons)
        {
            button.GetComponent<Image>().sprite = DeselectedCategorySprite;
        }
        ClearItemContainer();
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
            MoveCategoryButtonsUp();
        } else if (_direction == "Up")
        {
            if (CategoryIndex == 0)
            {
                CategoryIndex = _categoriesCount - 1;
            } else
            {
                CategoryIndex--;
            }
            MoveCategoryButtonsDown();
        }
        AllCategoryButtons[CategoryIndex].GetComponent<Image>().sprite = SelectedCategorySprite;
        AllCategories[CategoryIndex].InstantiateItemPrefabsInTheContainer();
        SelectedCategory = AllCategories[CategoryIndex];
        SelectItem(0);
    }

    public void SelectingShopItem(string _direction)
    {
        if (_direction == "Right")
        {
            if (SelectedItem == null)
            {
                SelectItem(0);
            } else
            {
                if (ItemIndex < SelectedCategory.InstantiatedItems.Count - 1)
                {
                    ItemIndex++;
                    SelectItem(ItemIndex);
                }
            }
        } else if (_direction == "Left")
        {
            if (ItemIndex > 0)
            {
                ItemIndex--;
                SelectItem(ItemIndex);
            }
        }
    }

    private void SelectItem(int _index)
    {
        SelectedItem = SelectedCategory.CategoryItems[_index];
        foreach (GameObject obj in SelectedCategory.InstantiatedItems)
        {
            obj.transform.GetChild(0).gameObject.SetActive(false);
        }
        SelectedCategory.InstantiatedItems[_index].transform.GetChild(0).gameObject.SetActive(true);
        ClearRecipeContainer();
        FillInRecipeContainer();
    }

    private void DeselectCategory()
    {
        foreach (GameObject obj in SelectedCategory.InstantiatedItems)
        {
            obj.transform.GetChild(0).gameObject.SetActive(false);
        }
        SelectedCategory = null;
    }

    public void FillInRecipeContainer()
    {
        TextAsset itemRecipes = Resources.Load<TextAsset>("ItemRecipes");
        JsonData itemRecipesJson = JsonMapper.ToObject(itemRecipes.text);
        for (int i = 0; i < itemRecipesJson["Recipes"].Count; i++)
        {
            if (SelectedItem.Name == itemRecipesJson["Recipes"][i]["Name"].ToString())
            {
                for (int j = 0; j < itemRecipesJson["Recipes"][i]["RequieredResources"].Count; j++)
                {
                    JsonData ItemInfo = itemRecipesJson["Recipes"][i]["RequieredResources"][j];
                    GameObject recipeElement = Instantiate(RecipeElementPrefab, RecipeContainer.transform);
                    recipeElement.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Resources Icons/" + ItemInfo["ResourceIcon"].ToString());

                    /*Debug.Log(itemRecipesJson["Recipes"][i]["RequieredResources"][j]["ResourceType"].ToString());
                    int amountNeeded;
                    amountNeeded = int.Parse(itemRecipesJson["Recipes"][i]["RequieredResources"][j]["Amount"].ToString());
                    Debug.Log(amountNeeded);*/
                }
            }
            
        }
    }

    public void MoveCategoryButtonsUp()
    {
        List<float> AllPositions = new List<float>();
        foreach (GameObject button in AllCategoryButtons)
        {
            AllPositions.Add(button.GetComponent<RectTransform>().localPosition.y);
        }
        for (int i = 0; i < AllCategoryButtons.Count; i++)
        {
            int positionIndex = i;
            if (i == 0)
            {
                positionIndex = AllCategoryButtons.Count;
            }
            Vector3 _newPosition = new Vector3(AllCategoryButtons[i].transform.localPosition.x, AllPositions[positionIndex - 1], AllCategoryButtons[i].transform.localPosition.z);
            AllCategoryButtons[i].transform.localPosition = _newPosition;
        }
    }
    public void MoveCategoryButtonsDown()
    {
        List<float> AllPositions = new List<float>();
        foreach (GameObject button in AllCategoryButtons)
        {
            AllPositions.Add(button.GetComponent<RectTransform>().localPosition.y);
        }
        for (int i = 0; i < AllCategoryButtons.Count; i++)
        {
            int positionIndex = i;
            if (i == AllCategoryButtons.Count - 1)
            {
                positionIndex = -1;
            }
            Vector3 _newPosition = new Vector3(AllCategoryButtons[i].transform.localPosition.x, AllPositions[positionIndex + 1], AllCategoryButtons[i].transform.localPosition.z);
            AllCategoryButtons[i].transform.localPosition = _newPosition;
        }
    }

    public void ClearItemContainer()
    {
        for (int i = 0; i < ItemContainer.transform.childCount; i++)
        {
            Destroy(ItemContainer.transform.GetChild(i).gameObject);
            ItemIndex = 0;
            SelectedCategory.InstantiatedItems.Clear();
        }
    }

    public void ClearRecipeContainer()
    {
        for (int i = 0;  i < RecipeContainer.transform.childCount; i++)
        {
            Destroy(RecipeContainer.transform.GetChild(i).gameObject);
        }
    }
}
