using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalScroller : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public VerticalScroller(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entered Vertical scroller scene");
        SceneManager.LoadScene("VerticalScroller");
    }
    public void Update()
    {

    }
    public void Exit()
    {

    }
}
