using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedCounter;
    //ʳ��ԭ����д���ģ� ������Ҫ�仯   �������õ����ݴ���
    //[SerializeField]
    //private GameObject kitchenObject; //����ʳ��
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
