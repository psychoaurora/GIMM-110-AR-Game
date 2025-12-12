using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlatformerMinigameState : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public PlatformerMinigameState(MinigameStateMachine machine)
    {
        this.machine = machine;
    }
        
    public void Enter()
    {
        Debug.Log("Entering platformer state");
        SceneManager.LoadScene("PlatformerMinigame");

        
    }

    
    public void Update()
    {

    }
    public void Exit()
    {

    }
}
