using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardState : IMinigameState
{
    private readonly MinigameStateMachine machine;
    private bool returningFromMinigame = false;

    public BoardState(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entering Board State");

        // Load board scene if not already there
        if (SceneManager.GetActiveScene().name != "Board")
        {
            SceneManager.LoadScene("Board");
        }

        // Stop any minigame timer
        machine.StopMinigameTimer();

        // If returning from a minigame, advance to next player
        if (returningFromMinigame)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SwitchToNextPlayer(); // Match your GameManager method name
            }
            returningFromMinigame = false;
        }

        // Display current player info
        LogCurrentPlayerInfo();
    }

    private void LogCurrentPlayerInfo()
    {
        if (GameManager.Instance != null)
        {
            PlayerData currentPlayer = GameManager.Instance.GetActivePlayerData();
            if (currentPlayer != null)
            {
                Debug.Log($"=== {currentPlayer.playerName}'s Turn ===");
                Debug.Log($"Total Score: {currentPlayer.totalScore}");
                Debug.Log($"Coins Collected: {currentPlayer.coinsCollected}");
            }
        }
    }

    public void Update()
    {
        // Board game logic here
        // (Card drawing, movement, shop, etc.)

        // TEMPORARY: Press Y to skip to next player (REMOVE LATER)
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Manually advancing to next player");
            GameManager.Instance.SwitchToNextPlayer();
            LogCurrentPlayerInfo();
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Board State");
        returningFromMinigame = true;
    }
}