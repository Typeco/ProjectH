using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ColidersCheck : MonoBehaviour
{
    public bool inColider;
    public bool openImg;
    [Header("设置需要打开的Img Object")]
    public GameObject ImgObject;
    

    void Update()
    {
        View();
        isOpen();
    }

    void OnTriggerEnter( )
    {
        //进入检测器范围
        inColider = true;
    }
  
    void OnTriggerExit()
    {
        //进入检测器范围
        inColider = false;
    }


    void View()
    {
        openImg = ImgObject.activeSelf;
        if (inColider == true && Input.GetKeyDown(KeyCode.E)) openImg = !openImg;
        else if (Input.GetKeyDown(KeyCode.E)) openImg = false;

    }


    void isOpen()
    {
        if (openImg == true) ImgObject.SetActive(true);
        else ImgObject.SetActive(false);       
    }







}
