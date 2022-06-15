using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 2f;
    private bool alreadyPassed;
    private GameObject playerObj;
    private GameManager gameManager;
    public AudioSource audioSource;


    private void Awake()
    {
        playerObj = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        foreach (Transform obs in gameObject.transform)
        {
            obs.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }

        if (GameManager.gameOver)
        {
            speed = 0;
        }

        if (PlayerPassed() && !alreadyPassed)
        {
            gameManager.AddScore();
            alreadyPassed = true;
            PlayCoinAudio();
        }

    }

    private bool PlayerPassed()
    {
        GameObject childPipe = gameObject.transform.GetChild(0).gameObject;
        if(playerObj.transform.position.x > childPipe.transform.position.x)
        {
            return true;
        }

        return false;
    }

    private void PlayCoinAudio()
    {
        audioSource.Play();
    }
}
