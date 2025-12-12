using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;

    public int scoreTotal;
    public int minigameScore;

    public int coinPointAddition = 1; //Change this value to something like "2" so it adds more points per coin picked up.

    public float timePerMinigame = 15f;

    private void Awake()
    {
        //Making sure that the instance is actually a singleton and will destroy if there is another
        if (Instance != null && Instance != this)
        {
           // Destroy(gameObject);
            return;
        }
        Instance = this;
       // DontDestroyOnLoad(gameObject); //Makes sure it doesn't go away on load
    }
}
