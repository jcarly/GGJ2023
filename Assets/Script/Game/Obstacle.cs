using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public AudioSource audioPlayer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource> ();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            audioPlayer.Play();
            Destroy(this.gameObject);
        }

        else if(collision.tag == "Player")
        {
            audioPlayer.Play();
            Destroy(player.gameObject);
        }
    }
}

