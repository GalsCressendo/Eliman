using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button startButton;

    private void Start()
    {
        startButton = gameObject.GetComponent<Button>();
        startButton.onClick.AddListener(StartOnClick);
    }

    private void StartOnClick()
    {
        SceneManager.LoadScene("main");
    }
}
