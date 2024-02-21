using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    public int life = 3;
    [SerializeField] private TextMeshProUGUI _lifeText;
    [SerializeField] private List<Image> healthImages;
    
    private int health;
    public event Action OnDie;
    public event Action OnTakeDamage;

    public bool IsDead => health == 0;

    private void Start()
    {
        health = maxHealth;
        UIUpdate();
        OnTakeDamage += UIUpdate;
    }

    public void TakeDamage(int damage)
    {
        if(health ==0) return;
        health = Mathf.Max(health - damage, 0);
        OnTakeDamage?.Invoke();
        
        if(health==0)
            OnDie?.Invoke();
    }
   

    private void UIUpdate()
    { 
        _lifeText.text = life.ToString();
        switch (health)
        {
            case 2:
                healthImages[2].enabled = false;
                break;
            case 1:
                healthImages[1].enabled = false;
                break;
            case 0:
                healthImages[0].enabled = false;
                break;
        }
    }

    public void Reset()
    {
        health = maxHealth;
        foreach (var VARIABLE in healthImages)
        {
            VARIABLE.enabled = true;
        }
        UIUpdate();
    }
}