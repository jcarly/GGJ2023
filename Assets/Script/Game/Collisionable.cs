using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionable : MonoBehaviour
{
    public AudioClip collisionSound;
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
