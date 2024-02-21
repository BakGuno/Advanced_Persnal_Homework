using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPopup : MonoBehaviour
{
   [SerializeField] protected TextMeshProUGUI _text;
   
   
   protected virtual void Awake()
   {
      
   }

   protected virtual void Start()
   {
      
   }

   public virtual void OnCancle()
   {
      
   }

   public virtual void Hide()
   {
      Destroy(gameObject);
   }

   public virtual void Refresh()
   {
      _text.text = "";
   }
}

