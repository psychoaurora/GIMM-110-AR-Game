using UnityEngine;

public class JumpState : IPlayerMovementState
{
    private readonly PlayerMovementStateMachine machine;
    private readonly PlayerMovement player;

    public JumpState(PlayerMovementStateMachine machine)
    {
        this.machine = machine;
        this.player = machine.player;
    }

    public void Enter()
    {
        // Apply jump force (2D version)
        player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, machine.jumpForce);

        // Decrease available jumps
        machine.currentJumps--;

        Debug.Log($"Jumped! Jumps remaining: {machine.currentJumps}");
    }

    public void Update()
    {
        // Allow air control
        float input = Input.GetAxisRaw("Horizontal");
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

        // Allow double jump
        if (Input.GetButtonDown("Jump") && machine.currentJumps > 0)
        {
            machine.SwitchState(new JumpState(machine));
        }

        // Check if we've landed
        if (player.isGrounded() && player.rb.linearVelocity.y <= 0.01f)
        {
            // Reset jumps when we land
            machine.currentJumps = machine.maxJumps;
            Debug.Log($"Landed! Jumps reset to: {machine.currentJumps}");

            // Transition based on input
            if (Mathf.Abs(input) > 0.01f)
            {
                machine.SwitchState(new WalkState(machine));
            }
            else
            {
                machine.SwitchState(new IdleState(machine));
            }
        }
    }

    public void Exit()
    {
        // Cleanup if needed
    }
}