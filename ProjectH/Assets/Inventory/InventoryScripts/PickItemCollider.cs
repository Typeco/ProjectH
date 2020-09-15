using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemCollider : MonoBehaviour
{
    [Header("设置物体和背包")]
    public Item thisItem;
    public Inventory playerInventory;

    [Header("提示文字")]
    public GameObject tipText;


    bool pickedThisItem;
    bool playInCollider;

    private void OnTriggerEnter(Collider other)
    {
        playInCollider = true;
        if (!pickedThisItem)
        {
            tipText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playInCollider = false;
        tipText.SetActive(false);
    }

    private void Update()
    {
        if (playInCollider && Input.GetKeyDown(KeyCode.E) && !pickedThisItem)
        {           
            //playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewitem(thisItem);
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
            pickedThisItem = true;
            tipText.SetActive(false);
            InventoryManager.RefreshItem();
        }

        

    }


}
