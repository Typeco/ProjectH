using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class TalkMessage
{   
    //声明csv的表头
    public int id;
    public string talk;
}


public class UIWenZi : MonoBehaviour
{
    [Header("设置load文件")]
    public TextAsset Loadtxt;

    [Header("启动时休眠时间(s)")]
    public float sleepTime=0;  

    [Header("每句话的等待时间(s)")]
    public float waitSentence;
    [Header("打字机每个字间隔速度(s)")]
    public float typespeed=0.1f;

    [Header("输出Text")]
    public Text text;

    [Header("总句子数量")]
    public int[] size;

    
    //判断是否是正在打字状态
    bool textFinished;

    //将我们需要的id和文字实例化新list
    List<TalkMessage> needSpeak = new List<TalkMessage>();

   
   
   void OnEnable()
   {
       //在启用时直接读取csv文件
       Loadcsv();
       //将输入中的状态改为T
       textFinished = true;
       //UI启动时设置为空白
       text.text = "";

   }


    void Update()
    {
        //判断启动时等待的时间
        if (Time.time<=sleepTime)return;

        //按下空格键而且处于输入结束的状态时 调用输入
        if (Input.GetKeyDown(KeyCode.Space) && textFinished == true)
        {
            StartCoroutine(Waiwaiwai());
        }
      
    }

    


    private void Loadcsv()
    {

        //引用输入的csv文件
        TextAsset talk = Loadtxt;
        //将每行 切割并输入到rowlist的数组
        string[]rowlist= talk.text.Split(new char[] {'\n'});
        //将每行用,切割 并根据表头创建新dict
        for (int i = 1; i < rowlist.Length - 1; i++)
        {
            string[] row = rowlist[i].Split(new char[] { ',' });
            TalkMessage saying = new TalkMessage();
            int.TryParse(row[0], out saying.id);
            saying.talk = row[1];
            needSpeak.Add(saying);
        }
    }



    
    IEnumerator Waiwaiwai()
    {   
        //执行时需要将输入已完成的状态改为F
        textFinished = false;

        //遍历需要输入的每一行（size中输入的ID号）
        for (int i = 0; i < size.Length; i++)
        {
            var pt = needSpeak.Find(p => p.id == size[i]);
            

            //需要将每次循环前的text重置空白
            text.text = "";

            //遍历根据打字机速度 输入每个字
            for (int o = 0; o < pt.talk.Length; o++)
            {
                text.text += pt.talk[o];
                yield return new WaitForSeconds(typespeed);
            }

            //输入完一行后的等待时间
            yield return new WaitForSeconds(waitSentence);
        }
        //输入完成后需要将输入完成的状态改为T
        textFinished = true;

        //最终将text控件状态禁用
        this.gameObject.SetActive(false);
    }




}
