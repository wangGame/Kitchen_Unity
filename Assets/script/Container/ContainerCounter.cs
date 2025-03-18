using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �洢��Ʒ��̨��
/// </summary>
public class ContainerCounter : BaseCounter
{
    [SerializeField]
    private KitchenObject kitchenObject;
    public override void Interact(Player player)
    {
        if (kitchObjectController == null)
        {
            Debug.Log("Clear Counter Interact");
            kitchObjectController = GameObject.Instantiate(kitchenObject.prefab, topPoint.transform).GetComponent<KitchObjectController>();
            kitchObjectController.transform.localPosition = Vector3.zero;
        }
        else
        {
            TransferKitchenObject(this, player);
        }
    }
}
