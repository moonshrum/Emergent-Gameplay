using UnityEngine;

public class Bridge : MonoBehaviour
{
    [System.NonSerialized]
    public GameObject RiverPieceToSnapTo;
    [System.NonSerialized]
    public Sprite SpriteToUSe;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "River Piece")
        {
            RiverPieceToSnapTo = col.gameObject;
        }
    }
}
