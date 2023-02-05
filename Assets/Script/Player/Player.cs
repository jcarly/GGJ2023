using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponent<AudioSource> ();
        ScoreManager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.offsetedScore >= 0) {
            float directionY = Input.GetAxisRaw("Horizontal");
            playerDirection = new Vector2(directionY, 0).normalized;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);
    }

       private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bonus")
        {
            audioPlayer.Play();
        }
    }
}
