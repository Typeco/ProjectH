using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;

    public GameObject itemInSlot;


    public string slotInfo;

    bool onInfo;

    public void ItemOnClicked()
    {
        onInfo = !onInfo;
        print("xxx");
        if (onInfo)
        {
            InventoryManager.UpdateItemInfo(slotInfo);
            
        }
        else
        {
            InventoryManager.UpdateItemInfo("");
        }
    }

    public void SetupSlot (Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.itemImage;
        slotInfo = item.itemInfo;

    }

}
