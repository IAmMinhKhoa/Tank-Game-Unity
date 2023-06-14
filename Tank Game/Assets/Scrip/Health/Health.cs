using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    public int currentHealth;
    public event Action<int, int> OnHealthChanged ;
    public event Action<int> OnDamageTaken,OnAddHealt;
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        OnDamageTaken?.Invoke(damage);
        if (currentHealth <= 0)
        {
            Sound_Manager.instance.PlaySound(SoundType.Explosion);
            Effect_Manager.instance.SpawnVFX("Particle Destroy", transform.position, Quaternion.identity);
           
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        OnAddHealt?.Invoke(healAmount);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    




}
