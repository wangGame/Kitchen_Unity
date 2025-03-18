using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储物品的台子
/// </summary>
public class ContainerCounter : BaseCounter
{
    [SerializeField]
    private KitchenObject kitchenObject;
    [SerializeField]
    private ContainerAnimation doorAnimation;
    public override void Interact(Player player)
    {
        if (player.GetKitchObjectController() != null) { 
            return;
        }
        Debug.Log("Clear Counter Interact");
        CreateKitchenObject(kitchenObject);
        TransferKitchenObject(this, player);
        doorAnimation.OpenDoor();
    }
}
