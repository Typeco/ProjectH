using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadJvben : MonoBehaviour
{
    List<JvbenList> allPrint = new List<JvbenList>();
    public int[] Size;
    public void Start()
    {
        TextAsset jvben = Resources.Load<TextAsset>("jvben");
        string[]rowlist= jvben.text.Split(new char[] {'\n'});
        for(int i = 1; i < rowlist.Length - 1; i++)
        {
            string[] row = rowlist[i].Split(new char[] { ',' });
            JvbenList word = new JvbenList();
            int.TryParse(row[0], out word.id);
            word.speaker = row[1];
            word.lines = row[2];
            allPrint.Add(word);
        }
        //allPrint[0].id    allPrint[0].speak   allPrint[0].lines
        int linecount = allPrint.Count;  
        for (int c = 0; c < linecount; c++)
            for (int i = 0; i < Size.Length; i++)
                if (Size[i] == allPrint[c].id)
                {
                    print(allPrint[c].speaker +":"+ "\n" + allPrint[c].lines);
                }       
    }
}
