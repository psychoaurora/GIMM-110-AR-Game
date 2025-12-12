using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardState : IMinigameState
{
    private readonly MinigameStateMachine machine;
    private bool returningFromMinigame = false;

    public BoardState(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entering Board State");

        // Load board scene if not already there
        if (SceneManager.GetActiveScene().name != "Board")
        {
            SceneManager.LoadScene("Board");
        }

        

        // Stop any minigame timer

        //machine.StopMinigameTimer();

        // If returning from a minigame, advance to next player
        if (returningFromMinigame)
        {
            if (ActivePlayerManager.Instance != null)
            {
                ActivePlayerManager.Instance.SwitchToNextPlayer();
            }
            returningFromMinigame = false;
        }

        // Wait a frame for scene to fully load, then start turn
        // (In practice, you'd use SceneManager.sceneLoaded event)
        WaitAndStartTurn();
    }

    private async void WaitAndStartTurn()
    {
        await System.Threading.Tasks.Task.Delay(100); // Wait 0.1 seconds

        // Find the BoardTurnManager in the scene and start the turn
        BoardTurnManager turnManager = GameObject.FindAnyObjectByType<BoardTurnManager>();
        if (turnManager != null)
        {
            turnManager.StartPlayerTurn();
        }
        else
        {
            Debug.LogError("BoardTurnManager not found in Board scene!");
        }
    }

    public void Update()
    {
        // BoardTurnManager handles all the turn logic

        if (Input.GetKeyDown(KeyCode.Y))
        {
            ActivePlayerManager.Instance.SwitchToNextPlayer();
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Board State");
        returningFromMinigame = true;
    }
}