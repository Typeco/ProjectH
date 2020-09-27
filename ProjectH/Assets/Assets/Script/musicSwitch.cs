using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicSwitch : MonoBehaviour
{
    public bool musicOn = true;
    public void Switch()
    {
        musicOn = !musicOn;

        if (!musicOn)
        {
            this.GetComponent<Image>().color = Color.red;
            this.GetComponentInChildren<Text>().text = "Off";
        }
        else
        {
            this.GetComponent<Image>().color = Color.white;
            this.GetComponentInChildren<Text>().text = "On";
        }
    }
}
