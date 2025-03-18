using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : KitchenObjectHolder
{
    [SerializeField]
    private GameObject selectedCounter;
    [SerializeField]
    private KitchenObject kitchenObject;
    [SerializeField]private ClearCounter targetCounter;
    [SerializeField] private bool isDebug;

    public void Interact() {
        if (kitchObjectController == null)
        {
            Debug.Log("Clear Counter Interact");
            kitchObjectController = GameObject.Instantiate(kitchenObject.prefab, topPoint.transform).GetComponent<KitchObjectController>();
            kitchObjectController.transform.localPosition = Vector3.zero;
        }
        else
        {
            TransferKitchenObject(this,Player.instance);
        }
    }

    public void SelectCounter() {
        selectedCounter.SetActive(true);
    }

    public void CanCelSelected() {
        selectedCounter.SetActive(false);
    }

    private void Update()
    {
        if (isDebug) {
            if (Input.GetMouseButtonDown(0))
            {
                TransferKitchenObject(this, targetCounter);
            }
        }
    }
}
