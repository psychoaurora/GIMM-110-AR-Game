using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public string playerName;
    public Color playerColor;
    public Sprite playerSprite;
    public int totalScore;
    public int boardPosition;
    public int coinsCollected;
    public float minigameTimeLimit = 15f; // Each player can have different time



    public PlayerData(string name, Color color, float timeLimit = 15f)
    {
        playerName = name;
        playerColor = color;
        totalScore = 0;
        boardPosition = 0;
        coinsCollected = 0;
        minigameTimeLimit = timeLimit;
    }

    public void AddScore(int points)
    {
        totalScore += points;
        Debug.Log($"{playerName} gained {points} points! Total: {totalScore}");
    }

    public void AddCoins(int coins)
    {
        coinsCollected += coins;
        Debug.Log($"{playerName} collected {coins} coins! Total collected: {coinsCollected}");
    }
}