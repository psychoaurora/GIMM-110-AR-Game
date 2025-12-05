using UnityEngine;

[CreateAssetMenu(menuName = "Items/AddTime")]
public class AddTimeItem : ItemEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerInfo>().timePerMinigame += amount;
    }
}

