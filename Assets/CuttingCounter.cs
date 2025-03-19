using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ClearCounter
{
    [SerializeField] KitchenObject kitchenObject;
    public override void InteractOperate(Player player)
    {
        if (GetKitchObjectController() != null) {
            //´æÔÚÊ³²Ä
            OnDestroyKitchen();
            CreateKitchenObject(kitchenObject);
        }
    }
}
