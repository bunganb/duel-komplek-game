using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum Turn { Player1, Player2 }
    public Turn currentTurn = Turn.Player1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Destroy(gameObject);
        }
    }
  
    private void Start()
    {
        StartTurn();
    }
    
    private void StartTurn()
    {
        Debug.Log("Turn Started: " + currentTurn);
    }
    
    public void EndTurn()
    {
        currentTurn = (currentTurn == Turn.Player1) ? Turn.Player2 : Turn.Player1;
        StartTurn();
    }
}
