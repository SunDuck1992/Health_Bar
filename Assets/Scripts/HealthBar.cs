using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Character _character;

    private Coroutine _coroutine;
    private float _speed = 0.2f;

    private void OnEnable()
    {
        _character.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= OnHealthChanged;
    }

    private IEnumerator ChangeSlider(float targetHealth)
    {
        targetHealth /= _character.Health;

        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnHealthChanged(float health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeSlider(_character.CurrentHealth));
    }
}
