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
    //��ǰ��̨���еĶ���
    private KitchObjectController kitchObjectController;
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
            Debug.Log("�Ѿ�����ʳ��" + gameObject);
        }

    }

    public void SelectCounter() {
        selectedCounter.SetActive(true);
    }

    public void CanCelSelected() {
        selectedCounter.SetActive(false);
    }

    public KitchObjectController GetKitchObjectController() { 
        return kitchObjectController;
    }

    public void TransferKitchenObject(ClearCounter sourceCounter,ClearCounter targetCounter)
    {
        if (sourceCounter.GetKitchObjectController() == null)
        {
            Debug.Log("source no kitchen"+sourceCounter);
            return;
        }
        if(targetCounter.GetKitchObjectController() != null)
        {
            Debug.Log("Target has kitchen already!"+targetCounter);
            return;
        }
        KitchObjectController controller = sourceCounter.GetKitchObjectController();
        targetCounter.AddKitchenObjectController(controller);
        sourceCounter.SetKitchObjectController(null);
    }

    public void AddKitchenObjectController(KitchObjectController kitchObjectController) {
        kitchObjectController.transform.SetParent(topPoint.transform);
        kitchObjectController.transform.localPosition = Vector3.zero ;
        SetKitchObjectController(kitchObjectController);
    }

    public void SetKitchObjectController(KitchObjectController kitch) { 
        this.kitchObjectController = kitch;
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
