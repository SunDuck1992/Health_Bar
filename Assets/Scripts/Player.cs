using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private float _maxHp;

    private float _percentMultiplier = 100;

    public void SetPlayerHp(float value)
    {
        if (_hp <= 0)
        {
            Died();
        }
        else
        {
            _hp += value * _percentMultiplier;

            if (_hp > _maxHp)
            {
                _hp = _maxHp;
            }
        }
    }

    private void Died()
    {
        Debug.Log("Вы умерли!");
    }
}
