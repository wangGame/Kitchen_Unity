using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ClearCounter : KitchObjectHold
{
    private GameObject selectCounter;
    [SerializeField]
    private KitchObjectSO KitchObject;
    
    //Ŀ������
    [SerializeField]
    private ClearCounter targetCounter;
    private void Start()
    {
        selectCounter = transform.Find("SelectClearCounter_Visual").gameObject;
 
    }
    public void Interact() {
        if (kitchObject != null)
        {
            Debug.Log("�Ѿ�����");
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

    

}
