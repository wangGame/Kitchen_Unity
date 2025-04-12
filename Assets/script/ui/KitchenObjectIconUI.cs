using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenObjectIconUI : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;
    [SerializeField]
    private Sprite sprite1;
    // Start is called before the first frame update
    public void Show(Sprite sprite) { 
        gameObject.SetActive(true);
        iconImage.sprite = sprite;
        transform.rotation = Quaternion.identity;
        transform.localScale = new Vector3(1,1,1);
    }

    public void Hide() { 
     //   transform.gameObject.SetActive(false);
    }
}
