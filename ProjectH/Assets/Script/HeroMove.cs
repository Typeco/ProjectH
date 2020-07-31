using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    public float moveSpeed = 3;

    private Animator ant;
    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        ant = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);


        if (h == 0)
        {
            ant.speed = 0;
        }
        else if(h > 0)
        {
            ant.speed = 1;
        }
        else if (h < 0)
        {
            ant.speed = 1;
        }


        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);

        
        if (v != 0)
        {
            ant.speed = 1;
        }

    }
}
