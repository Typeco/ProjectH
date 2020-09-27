using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [Header("进度条")]
    public GameObject SoundSlider;
    public GameObject SoundEffectSlider;
    //public float needHoldTime = 2;


    [Header("设置页面")]
    public GameObject Setting;

    [Header("音量值")]
    public float SoundVolume;
    public float EffectVolume;
    
    //调用
    Slider sound,effect;
    Text soundvalue,effectvalue;
    //float Hold = 0;

    bool SetOpen = false;

    private void Start()
    {
        sound = SoundSlider.GetComponent<Slider>();
        effect = SoundEffectSlider.GetComponent<Slider>();

        soundvalue = SoundSlider.GetComponentInChildren<Text>();
        effectvalue = SoundEffectSlider.GetComponentInChildren<Text>();
    }


    private void Update()
    {
        OpenSetting();
        SetSounds();
    }

/*
    void SliderControl()
    {            
        if (Input.GetKey(KeyCode.E))
        {
            Hold += Time.deltaTime;
            if (Hold >= needHoldTime) Hold = needHoldTime;
        }
        else if (Hold < needHoldTime) Hold = 0;

        slider.value = Hold / needHoldTime;
        //text.text = "长按E";
        text.text = ((int)(slider.value * 100)).ToString() + "%";
    }
*/


    void OpenSetting()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetOpen = !SetOpen;
            Setting.SetActive(SetOpen);
        }
    }

    void SetSounds()
    {
        soundvalue.text = sound.value.ToString();
        effectvalue.text = effect.value.ToString();

        SoundVolume = sound.value/100;
        EffectVolume = effect.value/100;
    }

}
