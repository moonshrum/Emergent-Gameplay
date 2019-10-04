using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvSlot : MonoBehaviour
{
    //public int Index;
    public bool IsOccupied;
    public InvSlotContent InvSlotContent;
    public GameObject Object;

    public void ResetInvSlot()
    {
        //Index = 0;
        IsOccupied = false;
        InvSlotContent = null;
        Destroy(Object);
    }
}
