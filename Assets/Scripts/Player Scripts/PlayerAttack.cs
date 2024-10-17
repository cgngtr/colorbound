using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerStats _playerStats;
    private ColorState _colorState;

    private void Awake()
    {
        _playerStats = GetComponent<PlayerStats>();
        _colorState = GetComponent<ColorState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Red state check
        if (collision.CompareTag("Enemy") && _colorState.GetCurrentState() == ColorState.Red)
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.ApplyDamage(_playerStats.GetAttackDamage());
                Debug.Log("Damage applied : " + _playerStats.GetAttackDamage());
            }
        }
    }
}
