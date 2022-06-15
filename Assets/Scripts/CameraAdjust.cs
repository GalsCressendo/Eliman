using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = spriteRenderer.bounds.size.x / spriteRenderer.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = spriteRenderer.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = spriteRenderer.bounds.size.y / 2 * differenceInSize;
        }
    }
}
