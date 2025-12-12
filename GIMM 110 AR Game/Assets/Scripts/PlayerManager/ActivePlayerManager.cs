using UnityEngine;

public class ActivePlayerManager : MonoBehaviour
{
    public static ActivePlayerManager Instance;

    public GameObject[] allPlayers; // Assign all 4 player prefabs/GameObjects
    public int activePlayerIndex = 0; // Which player is currently active (0-3)

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
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

    public PlayerInfo GetActivePlayerInfo()
    {
        GameObject activePlayer = GetActivePlayer();
        if (activePlayer != null)
        {
            return activePlayer.GetComponent<PlayerInfo>();
        }
        return null;
    }

    public GameObject GetActivePlayer()
    {
        if (activePlayerIndex >= 0 && activePlayerIndex < allPlayers.Length)
        {
            return allPlayers[activePlayerIndex];
        }
        return null;
    }

    public void SwitchToNextPlayer()
    {
        int nextIndex = (activePlayerIndex + 1) % allPlayers.Length;
        SetActivePlayer(nextIndex);
        Debug.Log("Switched to next player");
    }

    public void SwitchToPreviousPlayer()
    {
        int prevIndex = (activePlayerIndex - 1 + allPlayers.Length) % allPlayers.Length;
        SetActivePlayer(prevIndex);
    }
}