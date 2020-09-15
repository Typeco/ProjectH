using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//声明csv的表头
public class UiTextCsv
{   
    public int id;
    public string UiText;
}
public class UiTextControl : MonoBehaviour
{
    [Header("load文件")]
    public TextAsset Loadtxt;
    [Header("Id")]
    public int IdInCsv;

    Text Text;
    List<UiTextCsv> TextInUnity = new List<UiTextCsv>();

    void OnEnable()
    {
        Text = this.GetComponent<Text>();
        //在启用时直接读取csv文件
        Loadcsv();            
    }
    void Start()
    {
        //通过读取的csv文件设置UI的文字
        SetUiText();
    }

    void Loadcsv()
    {
        //引用输入的csv文件
        TextAsset TextInCsv = Loadtxt;
        //将每行 切割并输入到rowlist的数组
        string[] AllRow = TextInCsv.text.Split(new char[] { '\n' });
        //将每行用","切割 并根据表头创建新dict
        for (int i = 1; i < AllRow.Length - 1; i++)
        {
            string[] row = AllRow[i].Split(new char[] { ',' });
            UiTextCsv LoadUiText = new UiTextCsv();
            int.TryParse(row[0], out LoadUiText.id);
            LoadUiText.UiText = row[1];
            TextInUnity.Add(LoadUiText);
        }
    }

    void SetUiText()
    {
        //通过Lambda 表达式查找id号
        var FindText = TextInUnity.Find(x => x.id == IdInCsv);
        Text.text = FindText.UiText;
    }

}
