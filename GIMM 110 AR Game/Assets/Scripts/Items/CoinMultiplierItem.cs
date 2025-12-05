using UnityEngine;

[CreateAssetMenu(menuName = "Items/CoinMultiplier")]
public class CoinMultiplierItem : ItemEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerInfo>().coinMultiplier += amount;
    }
}

