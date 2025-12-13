using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleRoomPlatformer : IMinigameState
{
    private readonly MinigameStateMachine machine;

    public SingleRoomPlatformer(MinigameStateMachine machine)
    {
        this.machine = machine;
    }

    public void Enter()
    {
        Debug.Log("Entering Single Room Platformer");
        SceneManager.LoadScene("SingleRoomPlatformer");

        

    }

    public void Update()
    {

    }

    public void Exit()
    {
        
    }
}
