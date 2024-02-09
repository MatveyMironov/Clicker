using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class PointsBank : MonoBehaviour
{
    [SerializeField] private int _points;
    [SerializeField] private TextMeshProUGUI _pointsCountField;
    [SerializeField] private PassiveModifier _passiveModifier;
    [SerializeField] private GameObject _clickerPanel;
    [SerializeField] private GameObject _narrativePanel;
    [SerializeField] private Click _click;
    private int _passiveLastLevel;

    public int Points => _points;

    public void AddPoints(int _addValue)
    {
        _points = _points + _addValue;
        UnityEngine.Debug.Log($"+{_addValue}$");
        _pointsCountField.text = $"You have: {_points}$";
        if (_points >= 100) Narrative();
    }

    public void SubtractPoints(int _subtractValue)
    {
        _points = _points - _subtractValue;
        UnityEngine.Debug.Log($"-{_subtractValue}$");
        _pointsCountField.text = _points.ToString() + "$";
    }

    private void Narrative()
    {
        _clickerPanel.SetActive(false);
        _narrativePanel.SetActive(true);
        //SubtractPoints(100);
        _passiveLastLevel = _passiveModifier.PassiveUpgradePoints;
        _passiveModifier.PassiveUpgradePoints = 0;
    }
}
