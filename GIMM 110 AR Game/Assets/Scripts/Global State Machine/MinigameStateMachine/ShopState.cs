using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopState : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public ShopState(MinigameStateMachine machine)
    {
        this.machine = machine;
    }
    public void Enter()
    {
        Debug.Log("Entering shop");
        SceneManager.LoadScene("Shop");

        //Will need to a timer here
    }
    public void Update()
    {
        //Game logic here
    }
    public void Exit()
    {
        Debug.Log("Exiting shop scene/state");
    }
}
