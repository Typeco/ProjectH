using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testbutton : MonoBehaviour
{

    public Item thisItem;
    public Inventory playerInventory;
    private void OnGUI()
    {
        if (GUILayout.Button("Text"))
        {
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == thisItem)
                {
                    playerInventory.itemList[i]=null;
                    InventoryManager.RefreshItem();
                }
            }
            
        }
    }
}
