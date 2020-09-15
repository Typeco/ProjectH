using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class ChangAnE : MonoBehaviour
{
    [Header("需要长按时间")]
    public float needHoldTime = 2;
    [Header("进度条")]
    public Slider slider;
    [Header("显示文字")]
    public Text text;



    public bool LoadOver;
    private Animator ant;
    float Hold = 0;



    void Start()
    {
        ant = slider.GetComponent<Animator>();      
    }
    private void Update()
    {
        HoldE();
        Load();
    }



    void HoldE()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Hold += Time.deltaTime;
            if (Hold >= needHoldTime) Hold = needHoldTime;
        }
        else if (Hold < needHoldTime) Hold = 0;
    }

    void Load()
    {        
        slider.value = Hold/needHoldTime;
        //text.text = "长按E";
        text.text = ((int)(slider.value*100)).ToString()+"%";
        if (slider.value == 1)
        {
            ant.SetBool("isDone", true);
            LoadOver = true;
        }
            
    }




}
