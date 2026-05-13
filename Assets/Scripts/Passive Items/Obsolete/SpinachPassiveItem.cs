using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Deprecated as there is a new Passive system.")]
public class SpinachPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        player.Might *= 1 + passiveItemData.Multiplier / 100f;
    }
}
