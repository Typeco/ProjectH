using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform player;

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
        if (player.position.x > -7 && player.position.x < 7 && player.position.z > 4)
        {
            transform.position = offset + player.position;
        }
        // X 在移动范围，Z不在（仅X可以随便移动）
        else if ((player.position.x > -7 && player.position.x < 7) && player.position.z < 4)
        {
            transform.position = new Vector3(offset.x + player.position.x, transform.position.y, transform.position.z);
            //transform.position = offset + player.position;
        }
        // Z 在移动范围，X不在（仅Z 可以随便移动）
        else if ((player.position.x < -7 || player.position.x > 7) && player.position.z > 4)
        {
            //transform.forward = offset + player.position;
            transform.position = new Vector3( transform.position.x, transform.position.y,offset.z + player.position.z);
        }




    }
}
