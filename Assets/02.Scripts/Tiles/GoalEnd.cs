using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEnd : MonoBehaviour
{
    public Transform parents;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            gameObject.GetComponent<Animator>().SetTrigger("GoalTouch");
            UIManager.Instance.ShowPopup("EndUI",parents);
        }
    }
}
