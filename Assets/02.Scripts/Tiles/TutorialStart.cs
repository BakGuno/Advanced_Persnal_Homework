using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{
    [SerializeField] protected Transform parents;
    private bool istouch = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement _playerMovement) && !istouch)
        {
            istouch = true;
            UIManager.Instance.ShowPopup("TutorialInfoBG",parents);
        }
    }
}
