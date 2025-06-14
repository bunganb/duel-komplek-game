using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    private GameObject owner;
    private bool hasHit = false;

    public void SetOwner(GameObject _owner)
    {
        owner = _owner;
    }
  
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (hasHit) return;

        if (other.gameObject == owner) return;
  
        if (other.CompareTag("Player1") ||
            other.CompareTag("Player2"))
        {
            HealthController health = other.GetComponent<HealthController>();
            if (health != null)
            {
                health.TakeDamage();
                Debug.Log("Kena player: " + other.gameObject.name);
                hasHit = true;
                Destroy(gameObject);
            }
        }
        else
        {
            StartCoroutine(DestroyAfterDelay(1f)); 
        }
    }
  
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
