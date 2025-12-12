using UnityEngine;

[CreateAssetMenu(menuName = "Items/DoubleJump")]
public class DoubleJumpItem : ItemEffect
{
    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovementStateMachine>().maxJumps += amount;
    }
}

