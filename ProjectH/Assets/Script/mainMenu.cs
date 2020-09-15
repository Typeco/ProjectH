using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        // 开始按钮 跳转下一场景

    }
    public void Quit()
    {
        Application.Quit();//退出游戏 unity中无法测试需要游戏生成后才能用
                             //option 待做
    }

}
