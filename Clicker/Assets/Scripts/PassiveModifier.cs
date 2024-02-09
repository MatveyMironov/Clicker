using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveModifier : MonoBehaviour
{
    [SerializeField] private PointsBank _pointsBank;
    [SerializeField] private int _passiveUpgradeDelay = 5;
    [SerializeField] private ObjectAppearing _objectAppearing;
    [SerializeField] private GameObject _passiveUpgradeIcon;
    private int _passiveUpgradePoints = 0;

    public int PassiveUpgradePoints 
    {
        get => _passiveUpgradePoints;
        set => _passiveUpgradePoints = value;
    }

    IEnumerator Couratine()
    {
        WaitForSeconds _delay = new WaitForSeconds(_passiveUpgradeDelay);
        while (true)
        {
            if (_passiveUpgradePoints > 0)
            {
                _pointsBank.AddPoints(_passiveUpgradePoints);
                _objectAppearing.Appearing(_passiveUpgradeIcon.transform.position, $"+{_passiveUpgradePoints}$");
            }
            yield return _delay;
        }
    }

    private void Awake()
    {
        StartCoroutine(Couratine());
    }
}
