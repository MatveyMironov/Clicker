using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button _exitButton;

    private void Awake()
    {
        _exitButton.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        Application.Quit();
    }
}
