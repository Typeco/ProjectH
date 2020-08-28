using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangAnE : MonoBehaviour
{
    [Header("需要长按时间")]
    public float needHoldTime = 2;
    [Header("已经长按")]
    public float Hold = 0;
    [Header("进度条")]
    public Slider slider;
    [Header("显示文字")]
    public Text text;



    private Animator ant;


    void Start()
    {
        //ant = GetComponent<Animator>();
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
            //slider.gameObject.SetActive(false);
            //text.text = "Done！";
            ant.SetBool("isDone", true);
        }
            
    }




}
