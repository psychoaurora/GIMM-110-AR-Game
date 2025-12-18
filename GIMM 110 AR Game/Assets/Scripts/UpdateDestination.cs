using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDestination : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerData activePlayer = GameManager.Instance.GetActivePlayerData();
        text.text = "Destination: " + activePlayer.boardPosition;
    }
}
