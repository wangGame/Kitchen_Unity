using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 * ��̨�Ƚ϶࣬���Ǵ��ڹ��õķ����� ѡ�к�δѡ�е�״̬
 */
public class BaseCounter : KitchObjectHold
{
    [SerializeField]
    protected KitchObjectSO KitchObject;
    private GameObject selectCounter; //ѡ�й���
    //��̨��ѡ�еĹ���
    private void Start()
    {
        selectCounter = transform.Find("SelectCounter").gameObject;
    }

    public virtual void Interact(Player player)
    {
        Debug.LogWarning("δ��д��");
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
