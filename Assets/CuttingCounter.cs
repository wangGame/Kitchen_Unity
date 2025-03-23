using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ClearCounter
{
    [SerializeField]
    private CuttingRecipeListSao CuttingRecipeList;

    public override void InteractOperate(Player player)
    {
        if (GetKitchObjectController() != null) {
            //´æÔÚÊ³²Ä
            KitchenObject output =  CuttingRecipeList.getOutput(kitchObjectController.GetKitchenObject());
            if (output != null) {
                OnDestroyKitchen();
                CreateKitchenObject(output);
            }
        }
    }
}
