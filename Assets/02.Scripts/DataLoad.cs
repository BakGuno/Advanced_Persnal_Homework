using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad : MonoBehaviour
{
    public class Data_get
    {
        //json파일이랑 이름 맞춰야됨.
       public string version;
       public string key;
       public string info;
    }//저장용 클래스를 따로 파일로 만들어주는게 관리하기 좋음. 딱히 스태틱으로 할 필요도 없음.

    public Data_get DataGet;
    private void Start()
    {
        StartCoroutine(WWW_Get());
    }

    IEnumerator WWW_Get()
    {
        string url = "https://wou6c330.mycafe24.com/test.php";
        
        WWWForm form = new WWWForm();
        form.AddField("send","box");
        form.AddField("version","box2");
        WWW www = new WWW(url, form);

        yield return www;//서버에서 내려받을때까지 기다림.
        
        Debug.Log(www.text);
        // DataGet = JsonUtility.FromJson<Data_get>(www.text);
        // print(DataGet.version); //Debug.Log가 정석이지만 내용은 똑같음.
        yield break;
    }
}
