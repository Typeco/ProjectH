using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    public float speed = 3;
    public Text scoreText;
    public int score = 0;
    public float jumpPower = 150;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        rigid.AddForce(move * speed);

        bool jump = Input.GetButtonDown("Jump");

        bool b = Physics.Raycast(transform.position, Vector3.down, 0.6f);
        if (b && jump)
        {
            rigid.AddForce(jumpPower * Vector3.up);
        }
    }

    public void AddScore(int n)
    {
        score += 1;
        scoreText.text = "分数：" + score;
    }
}
