using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform player;

    [Header("玩家X,Z轴范围")]
    public float minX = -11f;
    public float maxX = 9f;
    public float minZ = 0f;



    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = offset + player.position;

        // X Z都在移动范围（可以随便移动）
        if (player.position.x > minX && player.position.x < maxX && player.position.z > minZ)
        {
            transform.position = offset + player.position;
        }
        // X 在移动范围，Z不在（仅X可以随便移动）
        else if ((player.position.x > minX && player.position.x < maxX) && player.position.z < minZ)
        {
            transform.position = new Vector3(offset.x + player.position.x, transform.position.y, transform.position.z);
            //transform.position = offset + player.position;
        }
        // Z 在移动范围，X不在（仅Z 可以随便移动）
        else if ((player.position.x < minX || player.position.x > maxX) && player.position.z > minZ)
        {
            //transform.forward = offset + player.position;
            transform.position = new Vector3( transform.position.x, transform.position.y,offset.z + player.position.z);
        }




    }
}
