using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.IsHaveKitch())
        {
            if (!IsHaveKitch())
            {
                TranforKitchObject(this, player);
            }
        }
        else {
            if (IsHaveKitch()) {
                TranforKitchObject(player,this);
            }
        }
    }


}
