using UnityEngine;

public class IdleState : IPlayerMovementState
{
    private readonly PlayerMovementStateMachine machine;
    private readonly PlayerMovement player;

    public IdleState(PlayerMovementStateMachine machine)
    {
        this.machine = machine;
        this.player = machine.player;
    }

    public void Enter()
    {
        // Reset jumps when entering idle (if grounded)
        if (player.isGrounded())
        {
            machine.currentJumps = machine.maxJumps;
        }

        // Optional: Set animator to idle animation
        // player.animator.SetBool("isWalking", false);
    }

    public void Update()
    {

        if (player.isGrounded())
        {
            machine.currentJumps = machine.maxJumps;
        }

        // Check for horizontal movement input
        float input = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(input) > 0.01f)
        {
            machine.SwitchState(new WalkState(machine)); // ? Fixed: specify which state
        }

        // Check for jump input
        if (Input.GetButtonDown("Jump") && machine.currentJumps > 0)
        {
            machine.SwitchState(new JumpState(machine)); // ? Added: jump from idle
        }
    }

    public void Exit()
    {
        // Cleanup if needed
    }
}