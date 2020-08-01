using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    public float moveSpeed = 3;

    private Animator ant;

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

        ant.SetInteger("h", (int)h);

        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.forward * v * moveSpeed * Time.deltaTime, Space.World);

        ant.SetInteger("v", (int)v);

    }
}
