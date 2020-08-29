using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{ 
    [Header("碰撞盒返回值")]
    public bool InConllider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collider)
    {
        
        switch (collider.tag)
        {
            case ("TipsConllider"):
                InConllider = true;
                break;
            case ("ImgConllider"):
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
                break;
            default:
                break;
        }
    }


}
