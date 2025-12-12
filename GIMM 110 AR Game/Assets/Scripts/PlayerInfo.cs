using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    //This script is the parent class for the characters/players in the game. Holds all of the variables 

    #region variables 

    public int scoreTotal; /*Total score of the player in the overall game.
                            * Score is a combination of minigameScore and the score one receives when;
                            * they pick up a coin in a Minigame (1 coin = 1 point) or,
                            * when they complete the game or minigame for a speed-type score.
                            */ 
    public int minigameScore;
    public float timePerMinigame; /*The amount of time that the player gets per minigame.
                                  * This variable will be sent as a parameter to the timermanager script and then sent to the coroutine. 
                                  * It will be sent in the Enter method in the minigame state class for whatever minigame.
                                  */
    public float coinAdditive = 2; /*This is by how much the coin multiplier will be.
                                  * You pick up 1 coin for 1 point, but then it is * by this variable. 
                                  * I am thinking 1.5x, but I think we would have to round the float to an int since the scoreTotal is an int
                                  SUBJECT TO CHANGE*/

    public float playerEndPlacement;    /*This is for tracking the player's ranking (1st, 2nd, 3rd) in the game. Only counted at the end of the game
                                        */

    public float firstPlacePrize = 25;
    public float secondPlacePrize = 20;
    public float thirdPlacePrize = 15;
    public float consolationPrize = 10; //4th place

    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { }
}
