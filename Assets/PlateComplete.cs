using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateComplete : MonoBehaviour
{
    [Serializable]
    private class KitchenOnjectSO_Model { 
        public KitchenObject kitchenObject;
        public GameObject model;
    }

    [SerializeField]
    private List<KitchenOnjectSO_Model> models;
    public void ShowKitchenObject(KitchenObject kitchenObject) {
        foreach (var item in models)
        {
            if (item.kitchenObject == kitchenObject) { 
                item.model.SetActive(true);
            }
        }
    }
}
