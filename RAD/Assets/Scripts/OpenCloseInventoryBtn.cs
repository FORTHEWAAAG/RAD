using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInventoryBtn : MonoBehaviour
{
    public void OpenCloseInv()
    {
        if (Inventory.isInventoryOpen == false)
        {
            Inventory.isInventoryOpen = true;
        }
        else
        {
            Inventory.isInventoryOpen = false;
        }

        Debug.Log(Inventory.isInventoryOpen);
    }
}
