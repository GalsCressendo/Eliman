using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuRandomBG : MonoBehaviour
{

    public List<GameObject> randomBackgrounds;

    // Start is called before the first frame update
    void Start()
    {
        int randomInt = Random.Range(0, randomBackgrounds.Count);
        Instantiate(randomBackgrounds[randomInt], new Vector3(0,0,0), Quaternion.identity);
        Destroy(gameObject);
    }
}
