using UnityEngine;

public class BoardPlayer : MonoBehaviour
{
    public int playerIndex; // 0=Green, 1=Blue, 2=Red, 3=Yellow
    public SpriteRenderer spriteRenderer;
    public PlayerData playerData;

    private void Start()
    {
        // Get this player's data from GameManager
        if (GameManager.Instance != null)
        {
            //playerData = GameManager.Instance.GetActivePlayer();
            //UpdateVisuals();
        }
    }

    public void SetPlayerIndex(int index)
    {
        playerIndex = index;

        if (GameManager.Instance != null)
        {
            /*playerData = playerIndex switch
            {
                0 => GameManager.Instance.greenPlayer,
                1 => GameManager.Instance.bluePlayer,
                2 => GameManager.Instance.redPlayer,
                3 => GameManager.Instance.yellowPlayer,
                _ => GameManager.Instance.greenPlayer
            };*/
            
            UpdateVisuals();
        }
    }

    private void UpdateVisuals()
    {
        if (spriteRenderer != null && playerData != null)
        {
            spriteRenderer.color = playerData.playerColor;
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public bool IsMyTurn()
    {
        return GameManager.Instance != null &&
               GameManager.Instance.activePlayerIndex == playerIndex;
    }
}
