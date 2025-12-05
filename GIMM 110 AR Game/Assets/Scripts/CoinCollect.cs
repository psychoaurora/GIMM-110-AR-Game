using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    //Remember to add the temp coins

    #region Variables
    //Empty for now but will probably need to add variable to track coins for whole game
    #endregion

    #region Unity Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreCounter.coinAmount += 1; // Increments the coin amount by 1.
        Destroy(gameObject);
        //Will need to add more logic for larger game when we have that
    }
    #endregion
}

