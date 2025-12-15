using UnityEngine;

public class scenePlayerInfo : MonoBehaviour
{
    /*public static int minigameCoins;

    public static bool addTimeItemBought = false;
    public static bool coinMultiplierItemBought = false;
    public static bool moveSpeedItemBought = false;
    public static bool jumpBuffItemBought = false;
    public static bool doubleJumpItemBought = false;*/

    public static scenePlayerInfo Instance;

    [Header("Session Data")]
    public PlayerData currentPlayerData;
    public int temporaryScore = 0;
    public int coinsCollected = 0;

    [Header("References")]
    public GameObject minigamePlayer; // The generic player controller

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Get current player's data
        if (GameManager.Instance != null)
        {
            currentPlayerData = GameManager.Instance.GetActivePlayerData();
            Debug.Log($"Minigame session started for {currentPlayerData.playerName}");

            // Apply player's color to minigame player
            ApplyPlayerVisuals();
        }
    }

    private void ApplyPlayerVisuals()
    {
        if (minigamePlayer == null)
        {
            minigamePlayer = GameObject.FindGameObjectWithTag("Player");
        }

        if (minigamePlayer != null && currentPlayerData != null)
        {
            SpriteRenderer sprite = minigamePlayer.GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.color = currentPlayerData.playerColor;
                Debug.Log($"Set player color to {currentPlayerData.playerName}'s color");
            }
        }
    }

    public void AddCoin()
    {
        if (GameManager.Instance == null) return;

        coinsCollected++;
        //temporaryScore += GameManager.Instance.coinPointValue;

        Debug.Log($"{currentPlayerData.playerName} collected coin! Temp score: {temporaryScore}");
    }

    public void AddPoints(int points)
    {
        temporaryScore += points;
        Debug.Log($"Points added! Temp score: {temporaryScore}");
    }

    public void EndMinigame() //
    {
        if (currentPlayerData != null)
        {
            Debug.Log($"Transferring {temporaryScore} points and {coinsCollected} coins to {currentPlayerData.playerName}");

            // Transfer temporary data to the permanent player component
            currentPlayerData.AddScore(temporaryScore);
            currentPlayerData.AddCoins(coinsCollected);
        }
        else
        {
            Debug.LogError("No active player data to transfer to!");
        }

        // Return to board
        if (MinigameStateMachine.Instance != null)
        {
            MinigameStateMachine.Instance.SwitchState(
                new BoardState(MinigameStateMachine.Instance));
        }
    }

    public float GetTimeLimit()
    {
        return currentPlayerData != null ? currentPlayerData.minigameTimeLimit : 15f;
    }
}
