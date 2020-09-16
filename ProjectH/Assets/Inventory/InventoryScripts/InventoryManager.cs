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
    public bool onInfo;
    public GameObject checkMake;

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
        

        if (instance.itemInfromation.text == itemDescription)
        {
            instance.onInfo = true;
        }
        else
        {
            instance.onInfo = false;
        }

        if (instance.onInfo)
        {
            instance.itemInfromation.text = "";
        }
        else
        {
            instance.itemInfromation.text = itemDescription;
        }

        instance.checkMake.SetActive(!instance.onInfo);

    }


    public static void UpdateCheckMake(Vector3 makePosition)
    {
        instance.checkMake.transform.position = makePosition;
        //instance.checkMake.SetActive(true);
    }



}
