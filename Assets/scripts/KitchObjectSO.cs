using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 每一个代表一个食材
 */
[CreateAssetMenu]
public class KitchObjectSO : ScriptableObject
{
    [SerializeField]
    public GameObject prefab;
    //食物的菜单
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private string objectName;
}
