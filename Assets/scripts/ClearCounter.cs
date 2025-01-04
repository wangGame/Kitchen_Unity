using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    private GameObject selectCounter;
    [SerializeField]
    private KitchObjectSO KitchObject;
    [SerializeField]
    private Transform topTransform;
    private KitchObject kitchObject;

    //目标桌子
    [SerializeField]
    private ClearCounter targetCounter;
    private void Start()
    {
        selectCounter = transform.Find("SelectClearCounter_Visual").gameObject;
 
    }
    public void Interact() {
        if (kitchObject != null)
        {
            Debug.Log("已经有了");
        }
        else
        {
            if (kitchObject == null && targetCounter.GetKitchObject() == null)
            {
                kitchObject = Instantiate(KitchObject.prefab, topTransform).GetComponent<KitchObject>();
                kitchObject.transform.localPosition = Vector3.zero;
            }
            else
            {
                TranforKitchObject(this, targetCounter);
            }
        }
    }

    public void SelectCounter() 
    {
        selectCounter.SetActive(true);
    }

    public void UnSelectCounter() {
        selectCounter.SetActive(false);
    }

    public KitchObject GetKitchObject() { 
        return kitchObject;
    }


    public void SetKitchObject() {
        this.kitchObject = null;
    }
     
    public void TranforKitchObject(ClearCounter target, ClearCounter source) {
        if (source != null)
        {
            KitchObject kitchObject = source.GetKitchObject();
            if (kitchObject != null) {
                if (target != null) {
                    KitchObject kitch = target.GetKitchObject();
                    if (kitch == null)
                    {
                        AddKitchenObject(source.GetKitchObject());
                        source.SetKitchObject();
                    }
                    else {
                        Debug.Log("已经有了");
                    }
                }
            }
        }
        else { 
            return;
        }
    }

    public void AddKitchenObject(KitchObject kitchObject) { 
        kitchObject.transform.SetParent(topTransform);
        kitchObject.transform.localPosition = Vector3.zero ;
        this.kitchObject = kitchObject;
    }

    public void ClearKitchObject(ClearCounter other) { 
        other.SetKitchObject();
    }


}
