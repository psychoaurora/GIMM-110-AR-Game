using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;

    public int scoreTotal;
    public int minigameScore;
    public int coinPointAddition = 1;
    public float timePerMinigame = 15f;

    private void Awake()
    {
        // Update the singleton to point to the currently active player
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
