using UnityEngine;
using UnityEngine.Splines;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] allPlayers; // Assign all 4 player prefabs/GameObjects
    public int activePlayerIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Make all players persistent and disable the inactive ones
        foreach (GameObject player in allPlayers)
        {
            if (player != null)
            {
                DontDestroyOnLoad(player);
            }
        }

        // Only activate the first player initially
        SetActivePlayer(activePlayerIndex);
    }

    public void SetActivePlayer(int index)
    {
        if (index < 0 || index >= allPlayers.Length)
        {
            Debug.LogError($"Invalid player index: {index}");
            return;
        }

        activePlayerIndex = index;

        // Disable all players
        for (int i = 0; i < allPlayers.Length; i++)
        {
            if (allPlayers[i] != null)
            {
                allPlayers[i].SetActive(i == activePlayerIndex);
            }
        }

        Debug.Log($"Player {activePlayerIndex + 1} is now active");
    }

    public GameObject GetActivePlayer()
    {
        if (activePlayerIndex >= 0 && activePlayerIndex < allPlayers.Length)
        {
            return allPlayers[activePlayerIndex];
        }
        return null;
    }
    public PlayerData GetActivePlayerData()
    {
        GameObject activePlayer = GetActivePlayer();
        if (activePlayer != null)
        {
            return activePlayer.GetComponent<PlayerData>();
        }
        return null;
    }

    public void SwitchToNextPlayer()
    {
        activePlayerIndex = (activePlayerIndex + 1) % allPlayers.Length;
        UpdateActivePlayer();

        PlayerData currentPlayer = GetActivePlayerData();
        if (currentPlayer != null)
        {
            Debug.Log($"Now it's {currentPlayer.playerName}'s turn");
        }
    }

    /*public void SwitchToPreviousPlayer()
    {
        int prevIndex = (activePlayerIndex - 1 + allPlayers.Length) % allPlayers.Length;
        SetActivePlayer(prevIndex);
    }*/
    private void UpdateActivePlayer()
    {
        // Show only the active player, hide others
        for (int i = 0; i < allPlayers.Length; i++)
        {
            if (allPlayers[i] != null)
            {
                allPlayers[i].SetActive(i == activePlayerIndex);
            }
        }
    }

    public SplineAnimate GetSplineAnimate()
    {
        GameObject activePlayer = GetActivePlayer();
        if (activePlayer != null)
        {
            return activePlayer.GetComponent<SplineAnimate>();
        }
        return null;

    }

}