using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    public float moveSpeed = 3;

    private Animator ant;

    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        ant = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //X轴方向输入
        float h = Input.GetAxisRaw("Horizontal");
        //transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        //用h判断动画播放正反
        ant.SetInteger("h", (int)h);
        //if (h != 0)return;
        //Z轴方向输入
        float v = Input.GetAxisRaw("Vertical");
        //transform.Translate(Vector3.forward * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        //v判断动画
        ant.SetInteger("v", (int)v);


        //设置移动方向的速度（当斜方向移动时 移动速度需要开根号）
        if (v == 1 && h ==1)
        {
            double moveZ = 1 / Math.Sqrt(v * v + h * h);
            transform.Translate(Vector3.right * (float)moveZ * moveSpeed * Time.fixedDeltaTime, Space.World);
            transform.Translate(Vector3.forward * v * (float)moveZ * moveSpeed * Time.fixedDeltaTime, Space.World);
        }
        else if (v == -1 && h ==1)
        {
            double moveZ = 1 / Math.Sqrt(v * v + h * h);
            transform.Translate(Vector3.right * (float)moveZ * moveSpeed * Time.fixedDeltaTime, Space.World);
            transform.Translate(Vector3.forward * -(float)moveZ * moveSpeed * Time.fixedDeltaTime, Space.World);
        }
        else if (v == 1 && h == -1)
        {
            double moveZ = 1 / Math.Sqrt(v * v + h * h);
            transform.Translate(Vector3.right * -(float)moveZ * moveSpeed * Time.fixedDeltaTime, Space.World);
            transform.Translate(Vector3.forward *(float)moveZ * moveSpeed * Time.fixedDeltaTime, Space.World);
        }
        else if (v == -1 && h ==-1)
        {
            double moveZ = 1 / Math.Sqrt(v * v + h * h);
            transform.Translate(Vector3.right * -(float)moveZ * moveSpeed * Time.fixedDeltaTime, Space.World);
            transform.Translate(Vector3.forward * -(float)moveZ * moveSpeed * Time.fixedDeltaTime, Space.World);
        }
        else
        {
            transform.Translate(Vector3.forward * v * moveSpeed * Time.fixedDeltaTime, Space.World);
            transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

        }


    }
}
