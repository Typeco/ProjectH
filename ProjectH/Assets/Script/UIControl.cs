using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [Header("UI Object")]
    public GameObject TipsObj;
    public GameObject ImgObj;

    [Header("ColliderControl")]
    public GameObject Player;



    bool NeedImg;
    private void Update()
    {
        TipsControl();
        //ImgControl();

    }

    //Tips范围检测
    void TipsControl()
    {
        NeedImg = ImgObj.activeSelf;
        if (Player.GetComponent<ColliderControl>().InConllider && Input.GetKeyDown(KeyCode.E))
        {
            ImgObj.SetActive(!NeedImg);
        }
        else if (!Player.GetComponent<ColliderControl>().InConllider && Input.GetKeyDown(KeyCode.E))
        {
            ImgObj.SetActive(false);
        }

        if (Player.GetComponent<ColliderControl>().InConllider && NeedImg == false)
        {
            TipsObj.SetActive(true);
        }
        else
        {
            TipsObj.SetActive(false);
        }


    }



}
