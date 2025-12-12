using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickerMinigame : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public ClickerMinigame(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered clicker minigame");
        SceneManager.LoadScene("ClickerMinigame");
    }
    public void Update()
    {

    }
    public void Exit()
    {

    }
}
