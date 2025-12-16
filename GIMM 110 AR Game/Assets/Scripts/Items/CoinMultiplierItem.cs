using UnityEngine;

[CreateAssetMenu(menuName = "Items/CoinMultiplier")]
public class CoinMultiplierItem : ItemEffect
{
    public int amount;

    public override void Apply(GameObject target)
    {
        //target.GetComponent<PlayerInfo>().coinPointAddition += amount;
        
        //scenePlayerInfo.coinMultiplierItemBought = true;
    }
}

