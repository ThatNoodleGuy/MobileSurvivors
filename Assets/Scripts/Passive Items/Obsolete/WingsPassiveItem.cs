using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Deprecated as there is a new Passive system.")]
public class WingsPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        player.MoveSpeed *= 1 + passiveItemData.Multiplier / 100f;
    }
}
