using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchObjectController : MonoBehaviour
{
    //�����Եõ����ݶ���
    [SerializeField] private KitchenObject kitchenObject;

    // Start is called before the first frame update
    public KitchenObject GetKitchenObject() { 
        return kitchenObject;
    }
}
