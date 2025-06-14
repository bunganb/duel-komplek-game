using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform throwPoint;
    public Rigidbody2D projectilePrefab;

    public float maxThrowForce = 200f;
    public float forcePerSecond = 85f;

    private float currentForce = 0f;
    private bool isHolding = false;
    

    private void Update()
    {
        if (GameManager.Instance.currentTurn == GameManager.Turn.Player1 && gameObject.CompareTag("Player1"))
        {
            HandleThrow();
        }
        else if (GameManager.Instance.currentTurn == GameManager.Turn.Player2 && gameObject.CompareTag("Player2"))
        {
            HandleThrow();
        }
    }

    private void HandleThrow()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHolding = true;
            currentForce = 0f;
        }
        if (Input.GetKey(KeyCode.Space) && isHolding)
        {
            currentForce += forcePerSecond * Time.deltaTime;
            if (currentForce > maxThrowForce) currentForce = maxThrowForce;
        }
        if (Input.GetKeyUp(KeyCode.Space) && isHolding)
        {
            isHolding = false;
            ThrowProjectile();
        }
    }
    
    private void ThrowProjectile()
    {
        Rigidbody2D projectile = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);
        ProjectTile projectTile = projectile.GetComponent<ProjectTile>();

        if (projectTile != null)
        {
            projectTile.SetOwner(gameObject);
        }
        float direction = gameObject.CompareTag("Player1") ? 1 : -1;

        // Arah awal lebih ke atas
        Vector2 directionVector = new Vector2(1 * direction, 1.2f);
        directionVector.Normalize();

        float forceMultiplier = 0.7f;

        projectile.gravityScale = 2.5f;
        projectile.AddForce(directionVector * currentForce * forceMultiplier, ForceMode2D.Impulse);

        GameManager.Instance.EndTurn();
    }
}
