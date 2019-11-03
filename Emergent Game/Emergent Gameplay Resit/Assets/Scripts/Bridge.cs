using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject RiverPieceToSnapTo;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "River Piece")
        {
            RiverPieceToSnapTo = col.gameObject;
        }
    }
}
