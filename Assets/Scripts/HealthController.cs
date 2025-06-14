using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private int damage = 10;

    public Image healthFill; 

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    
    public void TakeDamage()
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHealthUI();

        if (currentHealth == 0)
        {
            Debug.Log(gameObject.name + " defeated!");
        }
    }
  
    private void UpdateHealthUI()
    {
        healthFill.fillAmount = (float)currentHealth / maxHealth;
    }
}