using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchObjectController : MonoBehaviour
{
    //它可以得到数据对象
    [SerializeField] private KitchenObject kitchenObject;

    // Start is called before the first frame update
    public KitchenObject GetKitchenObject() { 
        return kitchenObject;
    }
}
