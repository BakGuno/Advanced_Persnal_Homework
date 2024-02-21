using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : UIPopup
{
    public ChatSO ChatSo;
    private int index;
    
    protected override void Start()
    {
        Refresh();
        _text.text = ChatSo.chat[0];
        Time.timeScale = 0;
    }
    
    public void OnBtnClick()
    {
        Refresh();
       
        try
        {
            _text.text = ChatSo.chat[index];
        }
        catch (Exception e)
        {
            Hide();
            Time.timeScale = 1;
        }
        index++;
    }

}
