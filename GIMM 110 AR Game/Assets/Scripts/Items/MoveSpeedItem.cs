using UnityEngine;

[CreateAssetMenu(menuName = "Items/MoveSpeedBuff")]
public class MoveSpeedItem : ItemEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerMovementStateMachine>().walkSpeed += amount;
      
    }
}
