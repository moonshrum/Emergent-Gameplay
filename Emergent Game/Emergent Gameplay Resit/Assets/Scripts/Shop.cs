using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public Player Player;
    [System.NonSerialized]
    public int CategoryIndex = 0;
    public int ItemIndex = 0;
    public List<Category> AllCategories = new List<Category>();
    public List<GameObject> AllCategoryButtons = new List<GameObject>();
    public Transform ItemContainer;
    public Transform RecipeContainer;
    public Transform BackgroundContainer;
    public Image BuyButton;
    public TextMeshProUGUI ItemDescription;

    public GameObject ItemPrefab; // A prefab to be instantiated in the Item Container
    public GameObject RecipeElementPrefab; // A prefab to be instantiated in the Recipe Container
    //public GameObject ItemDescriptionPrefab;

    [Header("Sprites to be used for toggling")]
    public Sprite CategoryButtonSelected;
    public Sprite CategoryButtonDeselected;
    public Sprite BuyButtonSelected;
    public Sprite BuyButtonDeSelected;

    [System.NonSerialized]
    public Item SelectedItem;
    [System.NonSerialized]
    public Category SelectedCategory;
    private List<KeyValuePair<Resource.ResourceType, int>> _tempList = new List<KeyValuePair<Resource.ResourceType, int>>(); // List that hold data for resources needed for crating amount

    private void Awake()
    {
        AllCategories[0].InstantiateItemPrefabsInTheContainer();
        SelectedCategory = AllCategories[0];
        SelectItem(0);
        gameObject.layer = 9;
    }

    // Comment out before pushing
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B) && Player.IsShopOpen)
        {
            if (CanCraftItem())
                CraftItem();
        }
    }
    public void ToggleShop()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        ToggleBuyButton();
    }
    public bool CanCraftItem()
    {
        _tempList.Clear();
        TextAsset itemRecipes = Resources.Load<TextAsset>("Item Recipes");
        JsonData itemRecipesJson = JsonMapper.ToObject(itemRecipes.text);
        int counter = 0; // Counter that checks if the player has enough of each resource needed to craft an item
        for (int i = 0; i < itemRecipesJson["Recipes"].Count; i++)
        {
            if (itemRecipesJson["Recipes"][i]["Name"].ToString() == SelectedItem.Name)
            {
                for (int j = 0; j < itemRecipesJson["Recipes"][i]["RequieredResources"].Count; j++)
                {
                    JsonData ItemInfo = itemRecipesJson["Recipes"][i]["RequieredResources"][j];
                    foreach (Resource resource in Player.AllResources)
                    {
                        Resource.ResourceType resourceType = (Resource.ResourceType)System.Enum.Parse(typeof(Resource.ResourceType), ItemInfo["ResourceType"].ToString());
                        if (resource.Type == resourceType)
                        {
                            int amountNeeded = int.Parse(ItemInfo["Amount"].ToString());
                            if (resource.Amount >= amountNeeded)
                            {
                                counter++;
                                _tempList.Add(new KeyValuePair<Resource.ResourceType, int>(resourceType, amountNeeded));
                                break; // Not sure
                            }
                        }
                    }
                }
                for (int k = 0; k < itemRecipesJson["Recipes"][i]["RequieredItems"].Count; k++)
                {
                    JsonData ItemInfo = itemRecipesJson["Recipes"][i]["RequieredItems"][k];
                    foreach (Item _item in Player.AllItems)
                    {
                        Resource.ResourceType resourceType = (Resource.ResourceType)System.Enum.Parse(typeof(Resource.ResourceType), ItemInfo["ResourceType"].ToString());
                        Item.ItemType itemType = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), ItemInfo["ItemType"].ToString());
                        if (_item.Type == itemType)
                        {
                            counter++;
                            break; // Not sure
                        }
                    }
                }
                /*Debug.Log(itemRecipesJson["Recipes"][i]["RequieredResources"].Count);
                Debug.Log(itemRecipesJson["Recipes"][i]["RequieredItems"].Count);*/
                /*int o = 0;
                for (int k = 0; k < itemRecipesJson["Recipes"][i]["RequieredItems"].Count; k++)
                {
                    o++;
                }
                if (counter == itemRecipesJson["Recipes"][i]["RequieredResources"].Count + o)
                {
                    if (!Player.Inventory.GetComponent<Inventory>().IsInventoryFull())
                    {
                        return true;
                    }
                }*/

                if (counter == itemRecipesJson["Recipes"][i]["RequieredResources"].Count + itemRecipesJson["Recipes"][i]["RequieredItems"].Count)
                {
                    if (!Player.Inventory.GetComponent<Inventory>().IsInventoryFull())
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public void CraftItem()
    {
        InvSlotContent inventorySlotContent = new InvSlotContent(SelectedItem);
        Player.Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent, _tempList);
        Player.AllItems.Add(SelectedItem);
        ChallengesManager.Instance.CheckForChallenge(SelectedItem.Type, Player);
    }
    public void SelectingShopCategory(string _direction)
    {
        int _categoriesCount = AllCategoryButtons.Count;
        foreach (GameObject button in AllCategoryButtons)
        {
            button.GetComponent<Image>().sprite = CategoryButtonDeselected;
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
        AllCategoryButtons[CategoryIndex].GetComponent<Image>().sprite = CategoryButtonSelected;
        AllCategories[CategoryIndex].InstantiateItemPrefabsInTheContainer();
        SelectedCategory = AllCategories[CategoryIndex];
        SelectItem(0);
        if(CanCraftItem())
        {
            ToggleBuyButton();
        }
    }
    public void ToggleBuyButton()
    {
        // Check if selected item can be crafted and toggling BuyButtton
        /*if (CanCraftItem())
        {
            BuyButton =
        }*/
        BuyButton.sprite = CanCraftItem() ? BuyButtonSelected : BuyButtonDeSelected;
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
                } else if (ItemIndex == SelectedCategory.InstantiatedItems.Count - 1)
                {
                    ItemIndex = 0;
                    SelectItem(ItemIndex);
                }
            }
        } else if (_direction == "Left")
        {
            if (ItemIndex == 0)
            {
                ItemIndex = (SelectedCategory.InstantiatedItems.Count - 1);
                SelectItem(ItemIndex);
            } else if (ItemIndex > 0)
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
        FillInCraftInformation();
    }
    private void FillInCraftInformation()
    {
        ClearRecipeContainer();
        FillInRecipeContainer();
        FillInItemDescription();
    }
    private void DeselectCategory()
    {
        foreach (GameObject obj in SelectedCategory.InstantiatedItems)
        {
            obj.transform.GetChild(0).gameObject.SetActive(false);
        }
        SelectedCategory = null;
    }
    private void FillInItemDescription()
    {
        ItemDescription.text = SelectedItem.Description;
    }
    public void FillInRecipeContainer()
    {
        TextAsset itemRecipes = Resources.Load<TextAsset>("Item Recipes");
        JsonData itemRecipesJson = JsonMapper.ToObject(itemRecipes.text);
        for (int i = 0; i < itemRecipesJson["Recipes"].Count; i++)
        {
            if (SelectedItem.Name == itemRecipesJson["Recipes"][i]["Name"].ToString())
            {
                for (int j = 0; j < itemRecipesJson["Recipes"][i]["RequieredResources"].Count; j++)
                {
                    JsonData ItemInfo = itemRecipesJson["Recipes"][i]["RequieredResources"][j];
                    Transform recipeElement = Instantiate(RecipeElementPrefab, RecipeContainer).transform;
                    recipeElement.Find("Recipe Element Icon").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + ItemInfo["ResourceIcon"].ToString());
                    recipeElement.Find("Recipe Element Amount").gameObject.SetActive(true);
                    foreach (Resource resource in Player.AllResources)
                    {
                        Resource.ResourceType resourceType = (Resource.ResourceType)System.Enum.Parse(typeof(Resource.ResourceType), ItemInfo["ResourceType"].ToString());
                        if (resource.Type == resourceType)
                        {
                            recipeElement.Find("Recipe Element Amount").GetComponent<TextMeshProUGUI>().text = resource.Amount.ToString();
                            break; // Not sure
                        }
                    }

                    recipeElement.Find("Recipe Element Amount").GetComponent<TextMeshProUGUI>().text += " / " + itemRecipesJson["Recipes"][i]["RequieredResources"][j]["Amount"].ToString();

                    /*Debug.Log(itemRecipesJson["Recipes"][i]["RequieredResources"][j]["ResourceType"].ToString());
                    int amountNeeded;
                    amountNeeded = int.Parse(itemRecipesJson["Recipes"][i]["RequieredResources"][j]["Amount"].ToString());
                    Debug.Log(amountNeeded);*/
                }
                for (int k = 0; k < itemRecipesJson["Recipes"][i]["RequieredItems"].Count; k++)
                {
                    JsonData ItemInfo = itemRecipesJson["Recipes"][i]["RequieredItems"][k];
                    GameObject recipeElement = Instantiate(RecipeElementPrefab, RecipeContainer);
                    recipeElement.transform.Find("Recipe Element Icon").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + ItemInfo["ItemIcon"].ToString());
                    /*recipeElement.transform.Find("Recipe Element Amount Needed").GetComponent<TextMeshProUGUI>().text = itemRecipesJson["Recipes"][i]["RequieredItems"][k]["Amount"].ToString();*/
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
        for (int i = 0; i < ItemContainer.childCount; i++)
        {
            Destroy(ItemContainer.GetChild(i).gameObject);
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
