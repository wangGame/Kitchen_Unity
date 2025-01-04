using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchObjectHold : MonoBehaviour
{
    //����  ���ǳ���kitch��λ��
    [SerializeField]
    protected Transform topTransform;
    //��ǰ���е���ʲô
    protected KitchObject kitchObject;

    public KitchObject GetKitchObject()
    {
        return kitchObject;
    }


    public void SetKitchObject()
    {
        this.kitchObject = null;
    }


    public void TranforKitchObject(KitchObjectHold target, KitchObjectHold source)
    {
        if (source != null)
        {
            KitchObject kitchObject = source.GetKitchObject();
            if (kitchObject != null)
            {
                if (target != null)
                {
                    KitchObject kitch = target.GetKitchObject();
                    if (kitch == null)
                    {
                        target.AddKitchenObject(source.GetKitchObject());
                        source.SetKitchObject();
                    }
                    else
                    {
                        Debug.Log("�Ѿ�����");
                    }
                }
            }
        }
        else
        {
            return;
        }
    }


    public void AddKitchenObject(KitchObject kitchObject)
    {
        kitchObject.transform.SetParent(topTransform);
        kitchObject.transform.localPosition = Vector3.zero;
        this.kitchObject = kitchObject;
    }

    public void ClearKitchObject(ClearCounter other)
    {
        other.SetKitchObject();
    }



}
