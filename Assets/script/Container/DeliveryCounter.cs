using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : ClearCounter
{
    public override void Interact(Player player)
    {
        KitchObjectController kitchen =  player.GetKitchObjectController();
        if (kitchen != null && kitchen.TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject)) {
            //上到菜是否正确
            //
            //销毁
            OrderManager.instance.DeliveryRecipe(plateKitchenObject);
            player.OnDestroyKitchen();
        }
    }
}
