using UnityEngine;
using System.Collections;

public class scenePlayerInfo : MonoBehaviour
{
    public static scenePlayerInfo Instance;

    [Header("Session Data")]
    public PlayerData currentPlayerData;
    public int temporaryScore = 0;

    [Header("References")]
    public GameObject minigamePlayer; // The generic player controller

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("Destroyed duplicate scenePlayerInfo instance");
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

    /*public void UpdatePlayerVisuals()
    {
        //ApplyPlayerVisuals();
        //Debug.Log("Player visuals updated with updateplayervisuals");

        StartCoroutine(DelayPlayerVisuals());
    }
    IEnumerator DelayPlayerVisuals()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(0.2f);
        ApplyPlayerVisuals();
    }*/

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
                //sprite.color = currentPlayerData.playerColor;
                //Debug.Log($"Set player color to {currentPlayerData.playerName}'s color");

                sprite.sprite = currentPlayerData.playerSprite;
                Debug.Log($"Set player sprite to {currentPlayerData.playerName}'s sprite");
            }
        }
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
            Debug.Log($"Transferring {temporaryScore} points to {currentPlayerData.playerName}");

            // Transfer temporary data to the permanent player component
            currentPlayerData.AddScore(temporaryScore);

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
