using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * 柜台比较多，但是存在公用的方法， 选中和未选中的状态
 */
public class BaseCounter : KitchObjectHold
{
    [SerializeField]
    protected KitchObjectSO KitchObject;
    private GameObject selectCounter; //选中功能
    //柜台有选中的功能
    private void Start()
    {
        selectCounter = transform.Find("SelectCounter").gameObject;
    }

    public virtual void Interact(Player player)
    {
        Debug.LogWarning("未复写！");
    }

    public void SelectCounter()
    {
        selectCounter.SetActive(true);
    }

    public void UnSelectCounter()
    {
        selectCounter.SetActive(false);
    }


}
