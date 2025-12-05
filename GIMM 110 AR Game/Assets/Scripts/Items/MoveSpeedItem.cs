using UnityEngine;

[CreateAssetMenu(menuName = "Items/MoveSpeedBuff")]
public class MoveSpeedItem : ItemEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Movement2D>().moveSpeed += amount;
        target.GetComponent<Movement2D>().airMoveSpeed += amount;
    }
}
