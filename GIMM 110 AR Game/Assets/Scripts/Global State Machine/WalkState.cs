using UnityEngine;

public class WalkState : IPlayerMovementState
{
    private readonly PlayerMovementStateMachine machine;
    private readonly PlayerMovement player;

    public WalkState(PlayerMovementStateMachine machine)
    {
        this.machine = machine;
        this.player = machine.player;
    }

    public void Enter()
    {
        
    }

    public void Update()
    {
        // Reset jumps if grounded
        if (player.isGrounded())
        {
            machine.currentJumps = machine.maxJumps;
        }

        // Get input
        float input = Input.GetAxisRaw("Horizontal");

        // Move the player (2D version)
        Vector2 movement = new Vector2(input * machine.walkSpeed, player.rb.linearVelocity.y);
        player.rb.linearVelocity = movement;

        // Flip sprite based on direction
        if (input < 0)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (input > 0)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }

        // Transition to idle if no input
        if (Mathf.Abs(input) < 0.01f)
        {
            machine.SwitchState(new IdleState(machine));
        }

        // Check for jump
        if (Input.GetButtonDown("Jump") && machine.currentJumps > 0)
        {
            machine.SwitchState(new JumpState(machine));
        }
    }

    public void Exit()
    {
        // Optional: Stop walking animation
        // player.animator.SetBool("isWalking", false);
    }
}