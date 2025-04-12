using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectGridUI : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectIconUI iconUI;
    // Start is called before the first frame update
    void Start()
    {
        iconUI.Hide();   
    }

    public void showKitchenObjectUI(KitchenObject kitchenObject) {
        KitchenObjectIconUI iconUIObject = Instantiate(iconUI);
        iconUIObject.transform.SetParent(transform);
        iconUIObject.Show(kitchenObject.sprite);
    }
}
