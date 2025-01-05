using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField]
    private CounterOpenDoor counterOpenDoor;
    //Interact
    public override void Interact(Player player)
    {
        if(player.IsHaveKitch())return;
        counterOpenDoor.OpenDoor();
        CreateKitchObject();
        TranforKitchObject(player, this);
        /*
        //第一次创建    第二次转移
        if (kitchObject == null)
        {
        }
        else
        {
        }*/
    }

    //只有自己有
    public void CreateKitchObject()
    {
        kitchObject = Instantiate(KitchObject.prefab, topTransform).GetComponent<KitchObject>();
        kitchObject.transform.localPosition = Vector3.zero;
    }
}
