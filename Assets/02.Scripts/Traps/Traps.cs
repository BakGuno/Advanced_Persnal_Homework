using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trpas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*4,ForceMode2D.Impulse);
            health.TakeDamage(1);
        }
    }
}
