using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] private Button _clickerButton;
    [SerializeField] private PointsBank _pointsBank;
    [SerializeField] private ObjectAppearing _objectAppearing;
    [SerializeField] private int _pointsPerClick = 1;

    public int PointsPerClick
    {
        get => _pointsPerClick;
        set
        {
            if (value != 0)
            {
                _pointsPerClick = value;
            }
        }
    }

    private void Awake()
    {
        _clickerButton.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        _objectAppearing.Appearing(_clickerButton.transform.position, $"+{_pointsPerClick}$");
        _pointsBank.AddPoints(_pointsPerClick);
    }
}
