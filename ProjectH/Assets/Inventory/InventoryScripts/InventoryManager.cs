using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    // public Slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInfromation;

    public List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
        
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfromation.text = "";
    }

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }

    public static void UpdateItemInfo(string itemDescription)
    {

        instance.itemInfromation.text = itemDescription;
    }

    /*
    public static void CreateNewitem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);

        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
       
    }
    */




}
