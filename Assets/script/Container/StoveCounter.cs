using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StoveCounter : ClearCounter
{
    [SerializeField]
    private FryingRecipeListSO fryingRecipeList;
    private float fryingTimer;
    private FryingReceipe fryingReceipe;
    private StoveState stoveState;

    public enum StoveState {
        Idle,
        Frying,
        Burning
    }

    private void Awake()
    {
        stoveState = StoveState.Idle;
    }

    public override void Interact(Player player)
    {
        KitchObjectController kitchObjectController = player.GetKitchObjectController();
        if (kitchObjectController != null)
        {
            KitchenObject kitchen = kitchObjectController.GetKitchenObject();
            FryingReceipe fryingReceipe = fryingRecipeList.GetFryingRecipe(kitchen);
            if (fryingReceipe != null)
            {
                base.Interact(player);
                StartFrying(fryingReceipe);
            }
        }
        else { 
            base.Interact(player);
        }
    }

    public void StartFrying(FryingReceipe frying) { 
        fryingTimer = 0;
        this.fryingReceipe = frying;
        stoveState = StoveState.Frying;
    }

    public override void InteractOperate(Player player)
    {
        base.InteractOperate(player);
    }

    private void Update()
    {
        if (kitchObjectController == null) {
            stoveState = StoveState.Idle;
        }
        switch (stoveState) {
            case StoveState.Idle:
                break;
            case StoveState.Frying:
                fryingTimer += Time.deltaTime;
                if (fryingTimer >= fryingReceipe.fryingTime) {
                    OnDestroyKitchen();
                    CreateKitchenObject(fryingReceipe.output);
                    stoveState= StoveState.Burning;

                    FryingReceipe frying =  fryingRecipeList.GetFryingRecipe(GetKitchObjectController().GetKitchenObject());
                    StartBurning(frying);
                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                if (fryingTimer >= fryingReceipe.fryingTime) {
                    OnDestroyKitchen();
                    CreateKitchenObject(fryingReceipe.output);
                    stoveState = StoveState.Idle;
                }
                break;
        }
    }

    public void StartBurning(FryingReceipe frying) {
        fryingTimer = 0;
        this.fryingReceipe = frying;
       
        
    }
}
