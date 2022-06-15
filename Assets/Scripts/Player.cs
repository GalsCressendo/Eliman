using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vel = 2.4f;
    private Rigidbody2D rb;
    bool isClicked;
    GameManager gameManager;

    public AudioClip flappingClip;
    public AudioClip hitClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            isClicked = true;
            FlappingAudio();
        }
    }

    private void FixedUpdate()
    {
        if (isClicked)
        {
            rb.velocity = Vector2.up * vel;
            isClicked = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.gameOver)
        {
            GameManager.gameOver = true;
            gameManager.GameOver();
            HitAudio();
        }

    }

    private void FlappingAudio()
    {
        audioSource.clip = flappingClip;
        audioSource.Play();
    }

    private void HitAudio()
    {
        audioSource.clip = hitClip;
        audioSource.Play();
    }


}
