using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float invincibleTime;
    public Animator Animator { get; private set; }
    public Health health { get; private set; }

    public Transform parents;

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        health = GetComponent<Health>();
    }

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        health.OnDie += OnDie;
        health.OnTakeDamage += OnDamage;
    }

    private void OnDamage()
    {
        Debug.Log("TakeDamage");
        Animator.SetBool("Hit",true);
        health.enabled = false;
        Invoke(nameof(reset),invincibleTime);
    }

    void reset()
    {
        Animator.SetBool("Hit", false);
        health.enabled = true;
    }

    void OnDie()
    {
        Animator.SetBool("Die",true);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        if (health.life > 0)
        {
            Invoke(nameof(Restart),2f);    
            health.life--;
        }
        else Invoke(nameof(Gameover),1f);
    }

    void Restart()
    {
        health.Reset();
        Animator.SetBool("Die",false);
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        if (GameManager.Instance.checkPoint != null)
        {
            transform.position = GameManager.Instance.checkPoint.position;
        }
        else transform.position = GameManager.Instance.startPos;
    }

    void Gameover()
    {
        UIManager.Instance.ShowPopup("DeadPopUp",parents);
    }
}
