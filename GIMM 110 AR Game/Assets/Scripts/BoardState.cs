using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardState : IMinigameState
{
    private readonly MinigameStateMachine machine;
    private PlayerInfo[] Players = new PlayerInfo[4]; //add input options to change to different number of players (buttons?) *Optional additon
    private bool takingTurns;

    public BoardState(MinigameStateMachine machine) 
    {
        this.machine = machine;
    }
    public void Enter() {
        if (SceneManager.GetActiveScene().name != "Board")
            SceneManager.LoadScene("Board");

        //Populates the player list
        PlayerInfo currentPlayer = new PlayerInfo();
        PlayerInfo Green = new GreenPlayer();
        PlayerInfo Blue = new BluePlayer();
        PlayerInfo Red = new RedPlayer();
        PlayerInfo Yellow = new YellowPlayer();

        Players[0] = Green;
        Players[1] = Blue;
        Players[2] = Red;
        Players[3] = Yellow;

        takingTurns = false;
    }

    public void Update() {

        //Turn order
        if(!takingTurns) {
            takingTurns = true;
            for(int i = 0; i < 4; i++) {
                if(currentPlayer = null) {
                    currentPlayer = Players[i];
                    currentPlayer.SetActive(true);
                }
                //if the current player has not lost their turn
                if(!locked) {
                    //Players[i] will take their turn then iterate through this loop again until all 4 players have taken their turn
                    Turn(Players[i]);
                }
            }
            takingTurns = false;
            currentPlayer.setActive(false);
            currentPlayer = null;
        }
    }

    private void Turn(PlayerInfo player) {
        //if player wants to enter the shop
        ShopButton.SetActive(true);
        //  enter the shop state/screen and stay until the player exits
        //  must be done BEFORE moving the player
        ShopButton.SetActive(false);
        //player pulls a card and shows it to the camera
        //player moves via SplineGen.cs


        //if player lands on a special tile
        if(SplineGen.currenttile == Gingerbreadman || candycane || gumdrop || peanut || lolpop || icecream) {
            //play a minigame or play a special animation on the board
        }
        //if player lands on the winning tile
        if(SplineGen.currenttile == wintilenumber) {
            //win condition and end game
        }
        //if player gambles (figure out how this is possible)
            {
                cardPulled = Gambler.GetComponent<Tracker>().GambleResult;
                //call the correct part of SplineGen and move the player
            }
        //(Option to play a minigame or pass for a boosted reward?)

    }

    public void Exit() {}
}
