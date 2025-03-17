using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedCounter;
    //食材原来是写死的， 下来需要变化   根据配置的内容创建
    //[SerializeField]
    //private GameObject kitchenObject; //厨房食材
    [SerializeField]
    private KitchenObject kitchenObject;
    [SerializeField]
    private GameObject topPoint;
    public void Interact() {
        Debug.Log("Clear Counter Interact");
        Instantiate(kitchenObject.prefab, topPoint.transform.position,Quaternion.identity);
    }

    public void SelectCounter() { 
        selectedCounter.SetActive(true);
    }

    public void CanCelSelected() {
        selectedCounter.SetActive(false);
    }
}
