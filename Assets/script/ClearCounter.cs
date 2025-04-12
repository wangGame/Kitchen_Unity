using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 放东西的
/// </summary>
public class ClearCounter : BaseCounter
{

    public override void Interact(Player player) {
        //if (player.GetKitchObjectController() == null) {
        //    if (GetKitchObjectController() != null)
        //    {
        //        TransferKitchenObject(this, player);
        //    }
        //    return;
        //}
        //if (GetKitchObjectController() != null) { 
        //    return;
        //}
        //TransferKitchenObject(player, this);

        {
            //手上为null
            if (player.GetKitchObjectController() == null)
            {
                if (GetKitchObjectController() != null)
                {
                    TransferKitchenObject(this, player);
                }
                return;
            }
            if (GetKitchObjectController() != null)
            {
                if (player.GetKitchObjectController().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject
                        .AddKitchenObjectSO(GetKitchObjectController().GetKitchenObject()))
                    {
                        OnDestroyKitchen();

                    }
                }
                else {
                    if (GetKitchObjectController().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plate)) {
                        if (plate
                            .AddKitchenObjectSO(player.GetKitchObjectController().GetKitchenObject()))
                        {
                            player.OnDestroyKitchen();

                        }
                    }
                }
                return;
            }
            TransferKitchenObject(player, this);
        }
    }

     
}
