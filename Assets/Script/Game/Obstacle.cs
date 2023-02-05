using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Collisionable
{
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}

