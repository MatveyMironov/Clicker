using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.UI.Image;

public class ObjectAppearing : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _parentPanel;
    [SerializeField] private GameObject _pointsCountField;

    public void Appearing(Vector3 _location, string _text)
    {
        GameObject _appearingObject = Instantiate(_prefab, _location, Quaternion.identity);
        _appearingObject.transform.SetParent(_parentPanel.transform, false);
        _appearingObject.GetComponent<TMP_Text>().text = _text;
        Destroy(_appearingObject, 1);
    }
}
