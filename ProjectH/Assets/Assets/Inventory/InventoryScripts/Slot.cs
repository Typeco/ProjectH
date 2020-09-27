using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;

    public GameObject itemInSlot;

    public GameObject CheckMake;
    public string slotInfo;

    public void ItemOnClicked()
    {
        

        InventoryManager.UpdateCheckMake(this.transform.position);
        InventoryManager.UpdateItemInfo(slotInfo);

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
