using JetBrains.Annotations;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    GameObject timermanager;
    
    private void Start()
    {
        timermanager = GameObject.Find("TimerManager");
    }

    #region Unity Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MinigameStateMachine.Instance.GetCurrentState();

        if (collision.CompareTag("Player"))
        {
            if (CompareTag("Coin"))
            {
                timermanager.GetComponent<TimerManager>().DeactivateAndActivate(gameObject, 3f);

                Debug.Log("Deactivated the game object");
            }
            ScoreCounter.coinAmount += 1; // Increments the coin amount by 1.
            scenePlayerInfo.Instance.temporaryScore += 1;


        }
        #endregion
    }
}

