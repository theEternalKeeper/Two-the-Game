using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 10;

    public float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
