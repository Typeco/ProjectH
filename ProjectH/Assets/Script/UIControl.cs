using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [Header("UI Object")]
    public GameObject TipsObj;
    public GameObject ImgObj;
    
    [Header("进度条")]
    public GameObject Slider;
    public float needHoldTime = 2;

    [Header("墙壁")]
    public GameObject Wall;


    //调用
    GameObject Player;
    bool NeedImg;    
    Slider slider;
    Text text;
    Animator ant;
    float Hold = 0;

    //
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        slider = Slider.GetComponent<Slider>();
        text = Slider.GetComponentInChildren<Text>();
        ant = slider.GetComponent<Animator>();
    }


    private void Update()
    {
        //ImgControl();
        SliderControl();

    }

    //Tips范围检测
    void ImgControl()
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

    void SliderControl()
    {
        if (Player.GetComponent<ColliderControl>().InSliderConllider && Wall)
        {
            TipsObj.SetActive(true);
            Slider.SetActive(true);            
        }
        else
        {
            Slider.SetActive(false);
            return;
        }
            

        if (Input.GetKey(KeyCode.E))
        {
            Hold += Time.deltaTime;
            if (Hold >= needHoldTime) Hold = needHoldTime;
        }
        else if (Hold < needHoldTime) Hold = 0;

        slider.value = Hold / needHoldTime;
        //text.text = "长按E";
        text.text = ((int)(slider.value * 100)).ToString() + "%";
        if (slider.value == 1)
        {
            ant.SetBool("isDone", true);
            TipsObj.SetActive(false);

            if (Wall.transform.localScale.y >= 0)
            {
                Wall.transform.localScale -= new Vector3(0.1f, 0.1f);
            }
            else
                Destroy(Wall);         
        }





    }



}
