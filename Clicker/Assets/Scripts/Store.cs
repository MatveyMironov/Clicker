using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Store : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button _multiplyUpgrade;
    [SerializeField] private UnityEngine.UI.Button _passiveUpgrade;
    [SerializeField] private PointsBank _pointsBank;
    [SerializeField] private PassiveModifier _passiveModifyer;
    [SerializeField] private ObjectAppearing _objectAppearing;
    [SerializeField] private GameObject _passiveUpgradeIcon;
    [SerializeField] private Click _click;
    [SerializeField] private int _multiplyCost = 5;
    [SerializeField] private int _passiveCost = 5;

    private void Awake()
    {
        _multiplyUpgrade.GetComponentInChildren<TMP_Text>().text = $"Buy Upgrade\r\n(X2$ per click)\r\nfor {_multiplyCost}$";
        _passiveUpgrade.GetComponentInChildren<TMP_Text>().text = $"Buy Upgrade\r\n({_passiveModifyer.PassiveUpgradePoints + 1} per second)\r\nfor {_passiveCost}$";
        _multiplyUpgrade.onClick.AddListener(MultiplyUpgrade);
        _passiveUpgrade.onClick.AddListener(PassiveUpgrade);
    }

    public void MultiplyUpgrade()
    {
        if (_pointsBank.Points >= _multiplyCost)
        {
            _objectAppearing.Appearing(_multiplyUpgrade.transform.position, $"-{_multiplyCost}$");
            _pointsBank.SubtractPoints(_multiplyCost);
            _click.PointsPerClick = _click.PointsPerClick * 2;
            _multiplyCost = _multiplyCost * 2;
            UnityEngine.Debug.Log($"You bought an upgrade! Now you get {_click.PointsPerClick} for each click");
            _multiplyUpgrade.GetComponentInChildren<TMP_Text>().text = $"Buy Upgrade\r\n(X2 $ per click)\r\nfor {_multiplyCost}$";
        }
        else UnityEngine.Debug.Log("You don't have enough points!");
    }

    public void PassiveUpgrade()
    {
        if (_pointsBank.Points >= _passiveCost)
        {
            _passiveUpgradeIcon.SetActive(true);
            _objectAppearing.Appearing(_passiveUpgrade.transform.position, $"-{_passiveCost}$");
            _pointsBank.SubtractPoints(_passiveCost);
            _passiveModifyer.PassiveUpgradePoints++;
            _passiveCost = _passiveCost * 2;
            UnityEngine.Debug.Log($"You bought an upgrade! Now you get {_passiveModifyer.PassiveUpgradePoints} each second");
            _passiveUpgrade.GetComponentInChildren<TMP_Text>().text = $"Buy Upgrade\r\n({_passiveModifyer.PassiveUpgradePoints + 1}$ per second)\r\nfor {_passiveCost}$";
        }
        else UnityEngine.Debug.Log("You don't have enough points!");
    }
}
