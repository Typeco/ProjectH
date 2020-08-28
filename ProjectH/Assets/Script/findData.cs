using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class findData : MonoBehaviour
{
    
    [Header("提示范围")]
    public GameObject Conlider1;
    public GameObject Conlider2;

    [Header("进入范围内的提示")]
    public GameObject TipsObeject;

    GameObject[]  Conliders;
    bool NeedTips;
    void Start()
    {
        Conliders = new GameObject[5];
        Conliders[0] = Conlider1;
        Conliders[1] = Conlider2;
    }


    void Update()
    {
        Tips(Conliders);
    }



    void Tips(GameObject[] x)
    {
        needTips();

        if (NeedTips)
        {
            TipsObeject.SetActive(true);
        }
        else
        {
            TipsObeject.SetActive(false);
        }



        void needTips()
        {
            if ((x[0].GetComponent<ColidersCheck>().inColider
            || x[1].GetComponent<ColidersCheck>().inColider)
            &&
            (!x[0].GetComponent<ColidersCheck>().openImg
            && ! x[1].GetComponent<ColidersCheck>().openImg)
            )
            {
                NeedTips = true;
            }
            else NeedTips = false;         
        }
    }


}
