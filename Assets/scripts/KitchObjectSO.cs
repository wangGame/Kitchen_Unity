using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * ÿһ������һ��ʳ��
 */
[CreateAssetMenu]
public class KitchObjectSO : ScriptableObject
{
    [SerializeField]
    public GameObject prefab;
    //ʳ��Ĳ˵�
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private string objectName;
}
