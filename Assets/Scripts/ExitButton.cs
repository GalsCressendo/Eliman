using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    Button exitButton;

    private void Start()
    {
        exitButton = gameObject.GetComponent<Button>();
        exitButton.onClick.AddListener(ExitButtonOnClick);
    }

    private void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
