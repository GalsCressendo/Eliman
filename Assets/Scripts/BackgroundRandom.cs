using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRandom : MonoBehaviour
{
    public List<GameObject> backgrounds;
    public float scrollspeed = 2f;
    

    private void Start()
    {
        int randomInt = Random.Range(0, backgrounds.Count);
        GameObject randomBg = backgrounds[randomInt];
        GameObject bg = Instantiate(randomBg, new Vector3(0, 0, 0), Quaternion.identity);
        bg.name = "Background";

        AddLoopScript(bg);
        
        Destroy(this.gameObject);
    }

    private void AddLoopScript(GameObject bg)
    {
        GameObject ground = bg.transform.Find("Ground").gameObject;
        ground.AddComponent<Looping>();
        ground.GetComponent<Looping>().scrollSpeed = scrollspeed;
    }
}
