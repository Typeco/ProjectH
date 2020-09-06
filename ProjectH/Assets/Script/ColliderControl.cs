using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{ 
    [Header("碰撞盒返回值")]
    public bool InConllider;
    public bool InSliderConllider;


    private void OnTriggerEnter(Collider collider)
    {
        
        switch (collider.tag)
        {
            case ("TipsConllider"):
                InConllider = true;
                break;
            case ("ImgConllider"):
                InSliderConllider = true;
                break;
            default:
                break;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        switch (collider.tag)
        {
            case ("TipsConllider"):
                InConllider = false;
                break;
            case ("ImgConllider"):
                InSliderConllider = false;
                break;
            default:
                break;
        }
    }


}
