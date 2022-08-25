using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region Singleton

    public static PlayerMovement instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 16f;
    private bool isGrounded;
    private bool isFacingRight = true;
    public float currentHighestHeight = 0;
    public TextMeshProUGUI scoreText;
    public GameObject GameOverScreen;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    private void Start()
    {
        currentHighestHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);  
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            if (collision.transform.position.y > currentHighestHeight)
            {
                currentHighestHeight = collision.transform.position.y;
                string score = scoreText.text;
                score = score.Substring(7);
                int scoreNum = int.Parse(score);
                scoreNum = (int) (transform.position.y + 3.5) * 100;
                scoreText.text = "Score: " + scoreNum.ToString();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            print("GAME OVER");
            GameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}