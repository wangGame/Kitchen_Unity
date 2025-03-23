using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ClearCounter
{
    [SerializeField]
    private CuttingRecipeListSao cuttingRecipeList;
    [SerializeField]
    private int cuttingCount;

    public override void InteractOperate(Player player)
    {
        if (GetKitchObjectController() != null) {
            //´æÔÚÊ³²Ä
            CuttingRecipe output =  cuttingRecipeList.cuttingRecipe(kitchObjectController.GetKitchenObject());
            if (output != null) {
                cuttingCount++;
                if (cuttingCount >= output.cuttingCountMax)
                {
                    OnDestroyKitchen();
                    CreateKitchenObject(output.output);
                }
            }
        }
    }
}
