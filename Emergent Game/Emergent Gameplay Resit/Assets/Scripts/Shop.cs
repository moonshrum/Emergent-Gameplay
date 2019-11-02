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
    public TextMeshProUGUI ItemDescription;

    public GameObject ItemPrefab; // A prefab to be instantiated in the Item Container
    public GameObject RecipeElementPrefab; // A prefab to be instantiated in the Recipe Container
    //public GameObject ItemDescriptionPrefab;

    public Sprite SelectedCategorySprite;
    public Sprite DeselectedCategorySprite;

    [System.NonSerialized]
    public Item SelectedItem;
    [System.NonSerialized]
    public Category SelectedCategory;

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
            CraftItem(SelectedItem, Player);
        }
    }
    public void CraftItem(Item item, Player player)
    {
        TextAsset itemRecipes = Resources.Load<TextAsset>("Item Recipes");
        JsonData itemRecipesJson = JsonMapper.ToObject(itemRecipes.text);
        int counter = 0; // Counter that checks if the player has enough of each resource needed to craft an item
        List<KeyValuePair<Resource.ResourceType, int>> tempList = new List<KeyValuePair<Resource.ResourceType, int>>();
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
                                tempList.Add(new KeyValuePair<Resource.ResourceType, int>(resourceType, amountNeeded));
                                break; // Not sure
                            }
                        }
                    }
                    if (counter == itemRecipesJson["Recipes"][i]["RequieredResources"].Count + itemRecipesJson["Recipes"][i]["RequiredItems"].Count)
                    {
                        if (!player.Inventory.GetComponent<Inventory>().IsInventoryFull())
                        {
                            InvSlotContent inventorySlotContent = new InvSlotContent(item);
                            player.Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent, tempList);
                            player.AllItems.Add(item);
                            ChallengesManager.Instance.CheckForChallenge(item.Type, Player);
                        }
                    }
                }
                for (int k = 0; k < itemRecipesJson["Recipes"][i]["RequieredItems"].Count; k++)
                {
                    JsonData ItemInfo = itemRecipesJson["Recipes"][i]["RequieredItems"][k];
                    foreach (Item _item in player.AllItems)
                    {
                        Resource.ResourceType resourceType = (Resource.ResourceType)System.Enum.Parse(typeof(Resource.ResourceType), ItemInfo["ResourceType"].ToString());
                        Item.ItemType itemType = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), ItemInfo["ItemType"].ToString());
                        if (_item.Type == itemType)
                        {
                            counter++;
                            break; // Not sure
                        }
                    }
                    if (counter == itemRecipesJson["Recipes"][i]["RequieredResources"].Count + itemRecipesJson["Recipes"][i]["RequiredItems"].Count)
                    {
                        if (!player.Inventory.GetComponent<Inventory>().IsInventoryFull())
                        {
                            InvSlotContent inventorySlotContent = new InvSlotContent(item);
                            player.Inventory.GetComponent<Inventory>().AddItem(inventorySlotContent, tempList);
                            player.AllItems.Add(item);
                            ChallengesManager.Instance.CheckForChallenge(item.Type, Player);
                        }
                    }
                }
            }
        }
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
                    GameObject recipeElement = Instantiate(RecipeElementPrefab, RecipeContainer);
                    recipeElement.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + ItemInfo["ResourceIcon"].ToString());
                    recipeElement.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemRecipesJson["Recipes"][i]["RequieredResources"][j]["Amount"].ToString();

                    /*Debug.Log(itemRecipesJson["Recipes"][i]["RequieredResources"][j]["ResourceType"].ToString());
                    int amountNeeded;
                    amountNeeded = int.Parse(itemRecipesJson["Recipes"][i]["RequieredResources"][j]["Amount"].ToString());
                    Debug.Log(amountNeeded);*/
                }
                for (int k = 0; k < itemRecipesJson["Recipes"][i]["RequieredItems"].Count; k++)
                {
                    JsonData ItemInfo = itemRecipesJson["Recipes"][i]["RequieredItems"][k];
                    GameObject recipeElement = Instantiate(RecipeElementPrefab, RecipeContainer);
                    recipeElement.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + ItemInfo["ItemIcon"].ToString());
                    recipeElement.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemRecipesJson["Recipes"][i]["RequieredItems"][k]["Amount"].ToString();
                    recipeElement.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = SelectedItem.Description;
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
