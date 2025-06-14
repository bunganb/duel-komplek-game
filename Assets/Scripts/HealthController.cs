using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 10;
    [SerializeField] private int currentHealth;
    private int damage = 10;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage()
    {
        currentHealth -= damage;
        if (currentHealth == 0)
        {
            currentHealth = 0;
            Debug.Log(gameObject.name + " defeated!");
        }
    }
}
