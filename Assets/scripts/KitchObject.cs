using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchObject : MonoBehaviour
{
    [SerializeField]
    private KitchObjectSO kitchObjectSO;

    public KitchObjectSO GetKitchObjectSO() { return kitchObjectSO; }  
}
