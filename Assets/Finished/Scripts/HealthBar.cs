using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private IntValue _health;
    [SerializeField] private float _scaleFactor;
    private Image _image;
    private int _oldValue;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _oldValue = _health.Value;

    }

    private void Update()
    {
        if (_oldValue != _health.Value)
        {
            _image.rectTransform.sizeDelta = new Vector2(
                _health.Value * _scaleFactor,
                _image.rectTransform.sizeDelta.y
            );
        }
    }
}
