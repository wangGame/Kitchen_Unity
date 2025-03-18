using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Ŷ�����
/// </summary>
public class ClearCounter : BaseCounter
{

    public override void Interact(Player player) {
        if (player.GetKitchObjectController() == null) {
            if (GetKitchObjectController() != null) {
                TransferKitchenObject(this,player);
            }
            return;
        }
        if (GetKitchObjectController() != null) { 
            return;
        }
        TransferKitchenObject(player, this);
    }

     
}
