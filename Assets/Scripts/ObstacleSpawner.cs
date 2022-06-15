using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacleVariant;
    public float queueTime = 1f;
    public float startTime = 3f;
    private float passedTime = 0;
    public float destroyTime = 5f;

    public bool gameStart;
    private GameObject obs;
    public float height;


    private void Start()
    {
        int randomIndex = Random.Range(0, obstacleVariant.Count);
        obs = obstacleVariant[randomIndex];
    }

    private void Update()
    {
        if(passedTime > startTime && !GameManager.gameOver)
        {
            gameStart = true;
        }

        if (gameStart)
        {
            if (passedTime > queueTime)
            {
                GameObject spawned = Instantiate(obs);
                spawned.transform.SetParent(gameObject.transform, false);
                spawned.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0.25f);

                passedTime = 0;
                StartCoroutine(DestroyObstacle(spawned));
            }
        }

        if (GameManager.gameOver)
        {
            gameStart = false;
            StopAllCoroutines();
        }



        passedTime += Time.deltaTime;
    }

    private IEnumerator DestroyObstacle(GameObject spawned)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(spawned);
    }
}
