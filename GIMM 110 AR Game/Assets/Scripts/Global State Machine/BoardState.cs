using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardState : IMinigameState
{
    private readonly MinigameStateMachine machine;
    //private playerInfo player;

    public BoardState(MinigameStateMachine machine)
    {
        this.machine = machine; 
    }
    public void Enter()
    {
        Debug.Log("Entering board scene");
        SceneManager.LoadScene("Board");


    }
    public void Update()
    {

    }
    public void Exit()
    {

    }
}
