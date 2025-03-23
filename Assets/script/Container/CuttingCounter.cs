using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : ClearCounter
{
    [SerializeField]
    private CuttingRecipeListSao cuttingRecipeList;
    private int cuttingCount;
    [SerializeField]
    private ProgressBarUI progressBarUI;
    [SerializeField]
    private CuttingCounterAnimation cuttingCounterAnimation;

    public override void InteractOperate(Player player)
    {
        if (GetKitchObjectController() != null) {
            //´æÔÚÊ³²Ä
            CuttingRecipe output =  cuttingRecipeList.cuttingRecipe(kitchObjectController.GetKitchenObject());
            if (output != null) {

                Cut();
                progressBarUI.UpdateProgress((float)(cuttingCount)/output.cuttingCountMax);

                if (cuttingCount >= output.cuttingCountMax)
                {
                    OnDestroyKitchen();
                    CreateKitchenObject(output.output);
                }
            }
        }
    }

    public void Cut() {
        cuttingCount++;
        cuttingCounterAnimation.PlayCut();
    }
}
