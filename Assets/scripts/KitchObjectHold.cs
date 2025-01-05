using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 当前持有，不仅仅是用户会持有，并且柜台也持有
 */
public class KitchObjectHold : MonoBehaviour
{
    //顶部  就是持有kitch的位置
    [SerializeField]
    protected Transform topTransform;
    //当前持有的是什么
    protected KitchObject kitchObject;

    public KitchObject GetKitchObject()
    {
        return kitchObject;
    }

    public bool IsHaveKitch() { 
        return kitchObject != null;
    }

    public void SetKitchObject()
    {
        this.kitchObject = null;
    }

    //转移方法
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
