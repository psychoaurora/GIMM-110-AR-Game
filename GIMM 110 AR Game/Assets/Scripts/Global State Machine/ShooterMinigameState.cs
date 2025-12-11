using UnityEngine;
using UnityEngine.SceneManagement;

public class ShooterMinigameState : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public ShooterMinigameState(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entering shooter state");
        SceneManager.LoadScene("ShooterMinigame");
    }
    public void Update()
    {

    }
    public void Exit()
    {
        Debug.Log("Exited shooter scene");
    }
}
