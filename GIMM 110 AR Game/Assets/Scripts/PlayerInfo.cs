using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;

    public int scoreTotal;
    public int minigameScore;
    public int coinPointAddition = 1;
    public float timePerMinigame = 15f;

}
