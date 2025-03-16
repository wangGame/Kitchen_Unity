using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedCounter;
    [SerializeField]
    private GameObject kitchenObject; //³ø·¿Ê³²Ä
    [SerializeField]
    private GameObject topPoint;
    public void Interact() {
        Debug.Log("Clear Counter Interact");
        Instantiate(kitchenObject,topPoint.transform.position,Quaternion.identity);
    }

    public void SelectCounter() { 
        selectedCounter.SetActive(true);
    }

    public void CanCelSelected() {
        selectedCounter.SetActive(false);
    }
}
