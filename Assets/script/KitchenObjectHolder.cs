using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ʳ�ĵĳ�����
/// </summary>
public class KitchenObjectHolder : MonoBehaviour
{
    [SerializeField]
    protected GameObject topPoint;
    //��ǰ��̨���еĶ���
    protected KitchObjectController kitchObjectController;


    public void SetKitchObjectController(KitchObjectController kitch)
    {
        this.kitchObjectController = kitch;
    }

    public void TransferKitchenObject(KitchenObjectHolder sourceCounter, KitchenObjectHolder targetCounter)
    {
        if (sourceCounter.GetKitchObjectController() == null)
        {
            Debug.Log("source no kitchen" + sourceCounter);
            return;
        }
        if (targetCounter.GetKitchObjectController() != null)
        {
            Debug.Log("Target has kitchen already!" + targetCounter);
            return;
        }
        KitchObjectController controller = sourceCounter.GetKitchObjectController();
        targetCounter.AddKitchenObjectController(controller);
        sourceCounter.SetKitchObjectController(null);
    }

    public KitchObjectController GetKitchObjectController()
    {
        return kitchObjectController;
    }

    public void AddKitchenObjectController(KitchObjectController kitchObjectController)
    {
        kitchObjectController.transform.SetParent(topPoint.transform);
        kitchObjectController.transform.localPosition = Vector3.zero;
        SetKitchObjectController(kitchObjectController);
    }
}
