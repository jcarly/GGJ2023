using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public AudioSource audioPlayer;
    public float hp = 10;
    private float initialY;
    public float degenerationSpeed = 0.01f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponent<AudioSource> ();
        initialY = transform.localPosition.y;
        ScoreManager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.score - 6 >= 0) {
            float directionY = Input.GetAxisRaw("Horizontal");
            playerDirection = new Vector2(directionY, 0).normalized;
            hp -= Time.deltaTime * degenerationSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, initialY - (hp / 3), transform.localPosition.z);
        }
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
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.tag == "Bonus")
        {
            hp++;
            Destroy(collision.gameObject);
        }
    }
}
