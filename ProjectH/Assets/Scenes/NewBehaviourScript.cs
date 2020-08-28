using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool q1;
    public bool p1;
}
void OnEnterStay()//保持在感应器之内
{
    q1 = ture;
}
void OnEnterExit()//离开感应器
{
    q1 = false;
} 
    void Update()//当人物保持在感应器内并按下控制键
    {
    if (q1 == ture && Input.GetKeyDown(KeyCode.E)) p1 = ture;
    }

