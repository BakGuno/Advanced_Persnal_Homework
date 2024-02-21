using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            gameObject.GetComponent<Animator>().SetTrigger("FlagTouch");
            GameManager.Instance.checkPoint = transform;
        }
    }
}
