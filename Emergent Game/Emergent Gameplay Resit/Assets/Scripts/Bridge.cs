using UnityEngine;

public class Bridge : MonoBehaviour
{
    //[System.NonSerialized]
    public GameObject RiverPieceToSnapTo;

    public void PlaceBridge(GameObject prefab, Sprite sprite, Item _item, string _name, string _iconName)
    {
        print("aaaa");
        GameObject bridgeOnTheRiver = Instantiate(prefab, RiverPieceToSnapTo.transform.position, Quaternion.identity);
        //bridgeOnTheRiver.transform.parent = RiverPieceToSnapTo.transform;
        bridgeOnTheRiver.GetComponent<SpriteRenderer>().sprite = sprite;
        RiverPieceToSnapTo.transform.GetChild(0).gameObject.SetActive(false);
        ItemDrop _itemDrop = bridgeOnTheRiver.AddComponent<ItemDrop>();
        //ItemDrop _itemDrop = Instantiate(itemDrop, RiverPieceToSnapTo.transform.position, Quaternion.identity).GetComponent<ItemDrop>();
        _itemDrop.Type = _item.Type;
        _itemDrop.GetComponent<ItemDrop>().Item = _item;
        _itemDrop.GetComponent<ItemDrop>().Name = _name;
        _itemDrop.GetComponent<ItemDrop>().IconName = _iconName;
        //_itemDrop.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + content.IconName);

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "River Piece")
        {
            RiverPieceToSnapTo = col.transform.parent.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "River Piece")
        {
            RiverPieceToSnapTo = null;
        }
    }
}
