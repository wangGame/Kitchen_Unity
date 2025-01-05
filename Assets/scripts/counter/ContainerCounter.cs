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
        //��һ�δ���    �ڶ���ת��
        if (kitchObject == null)
        {
        }
        else
        {
        }*/
    }

    //ֻ���Լ���
    public void CreateKitchObject()
    {
        kitchObject = Instantiate(KitchObject.prefab, topTransform).GetComponent<KitchObject>();
        kitchObject.transform.localPosition = Vector3.zero;
    }
}
