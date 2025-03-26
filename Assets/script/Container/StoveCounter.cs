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
    [SerializeField]
    private StoveCounterAnimation stoveCounterAnimation;
    [SerializeField]
    private ProgressBarUI progressBarUI;

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
        stoveCounterAnimation.ShowStoveEffect();
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
                stoveCounterAnimation.HideStoveEffecct();
                progressBarUI.gameObject.SetActive(false);
                break;
            case StoveState.Frying:
                progressBarUI.gameObject.SetActive(true);
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer/ fryingReceipe.fryingTime);
                if (fryingTimer >= fryingReceipe.fryingTime) {
                    OnDestroyKitchen();
                    CreateKitchenObject(fryingReceipe.output);
                    stoveState= StoveState.Burning;

                    FryingReceipe frying =  fryingRecipeList.GetFryingRecipe(GetKitchObjectController().GetKitchenObject());
                    if (frying != null) {
                        StartBurning(frying);
                       
                    }
                }
                break;
            case StoveState.Burning:
                progressBarUI.gameObject.SetActive(true);
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer / fryingReceipe.fryingTime);
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
        stoveCounterAnimation.ShowStoveEffect();
    }
}
