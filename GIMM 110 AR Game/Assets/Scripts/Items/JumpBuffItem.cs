using UnityEngine;

[CreateAssetMenu(menuName = "Items/JumpForceBuff")]
public class JumpBuffItem : ItemEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        //target.GetComponent<PlayerMovementStateMachine>().jumpForce += amount;

        //scenePlayerInfo.jumpBuffItemBought = true;
    }
}
