using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;
    bool isDead = false;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText.text = "0";
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && !isDead)
        {
            rb.velocity = Vector2.up * flapForce;
        }

        // Optional: rotate bird based on velocity
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * 5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            isDead = true;
            rb.velocity = Vector2.zero;
            gameManager.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log("Score: " + score);
        }
    }
}
