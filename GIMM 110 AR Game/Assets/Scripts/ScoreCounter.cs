using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour
{
    #region Variables
    TextMeshProUGUI text;
    #endregion

    #region Unity Methods
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>(); // Gets the text component of the object this script is attached to.
    }

    void Update()
    {
        PlayerData activePlayer = GameManager.Instance.GetActivePlayerData();
        text.text = "Score for " + activePlayer.playerName + "=" + activePlayer.totalScore; // Updates the text to display the current coin amount.
    }
    #endregion
}
