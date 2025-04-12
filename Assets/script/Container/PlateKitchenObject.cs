using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchObjectController
{
    [SerializeField]
    private List<KitchenObject> validKitchenObjectList = new List<KitchenObject>();
    private List<KitchenObject> kitchensList = new List<KitchenObject>();
    [SerializeField]
    private PlateComplete completeKitchenObject;
    public bool AddKitchenObjectSO(KitchenObject kitchen) {
        if (kitchensList.Contains(kitchen)) { 
            return false;
        }
        if (validKitchenObjectList.Contains(kitchen) == false) { 
            return false;
        }
        completeKitchenObject.ShowKitchenObject(kitchen);
        kitchensList.Add(kitchen);
        return true;
    }
}
