using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    [SerializeField]
    protected GameObject selectedCounter;

    public virtual void Interact(Player player)
    { 
    
    }
    public void SelectCounter()
    {
        selectedCounter.SetActive(true);
    }

    public void CanCelSelected()
    {
        selectedCounter.SetActive(false);
    }


    public void CreateKitchenObject(KitchenObject kitchen)
    {
        kitchObjectController = GameObject.Instantiate(kitchen.prefab, topPoint.transform).GetComponent<KitchObjectController>();
        kitchObjectController.transform.localPosition = Vector3.zero;
    }

}
