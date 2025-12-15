using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopState : IMinigameState
{
    private readonly MinigameStateMachine machine;
    private readonly PlayerMovementStateMachine playerMovement;

    public ShopState(MinigameStateMachine machine)
    {
        this.machine = machine;
    }
    public void Enter()
    {
        Debug.Log("Entering shop");
        SceneManager.LoadScene("Shop");

        //machine.activePlayerInfo = GameManager.Instance.GetActivePlayerInfo();
    }
    public void Update()
    {
        //Game logic here
    }
    public void Exit()
    {
        /*Debug.Log("Exiting shop scene/state");

        if (scenePlayerInfo.addTimeItemBought)
        {
            machine.activePlayerInfo.timePerMinigame += 10;
        }
        else if (scenePlayerInfo.coinMultiplierItemBought)
        {
            machine.activePlayerInfo.coinPointAddition += 1;
        }
        else if (scenePlayerInfo.moveSpeedItemBought)
        {
            playerMovement.walkSpeed += 3;
        }
        else if (scenePlayerInfo.jumpBuffItemBought)
        {
            playerMovement.jumpForce += 2;
        }
        else if (scenePlayerInfo.doubleJumpItemBought)
        {
            playerMovement.maxJumps += 1;
        }*/
    }
}


