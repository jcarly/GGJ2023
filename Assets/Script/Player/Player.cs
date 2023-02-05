using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public AudioSource audioPlayer;
    public int hp = 10;
    private float initialY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponent<AudioSource> ();
        initialY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionY, 0).normalized;
        transform.localPosition = new Vector3(transform.localPosition.x, initialY - (hp / 5), transform.localPosition.z);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Collisionable collisionable) && collisionable.collisionSound) {
            audioPlayer.PlayOneShot(collisionable.collisionSound);
        }
        if (collision.tag == "Obstacle")
        {
            hp--;
        }
        if (collision.tag == "Bonus")
        {
            ScoreManager.score += 10;
            Destroy(collision.gameObject);
        }
    }
}
