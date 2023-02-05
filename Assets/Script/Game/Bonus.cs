using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Collisionable
{
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Player")
        {
            ScoreManager.score += 10;
            Destroy(gameObject);
        }
    }
}
