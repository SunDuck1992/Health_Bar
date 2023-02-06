using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _speed;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Player _player;

    private float _imageFillAmount;
    private float _maxFillAmount = 1;
    private float _minFillAmount = 0;

    private void Start()
    {
        _imageFillAmount = _image.fillAmount;
    }

    private void Update()
    {
        if (_image.fillAmount != _imageFillAmount)
        {
            _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, _imageFillAmount, _speed * Time.deltaTime);
            _image.color = _gradient.Evaluate(_image.fillAmount);
        }
    }

    public void SetValue(float value)
    {
        if (_imageFillAmount > _maxFillAmount)
        {
            _imageFillAmount = _maxFillAmount;
        }
        else if (_imageFillAmount < _minFillAmount)
        {
            _imageFillAmount = _minFillAmount;
        }

        _imageFillAmount += value;
        _player.SetPlayerHp(value);
    }
}
