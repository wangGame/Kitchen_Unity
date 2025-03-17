using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 需要在右键中创建
/// </summary>
[CreateAssetMenu]
public class KitchenObject : ScriptableObject
{
    [SerializeField]
    public GameObject prefab;
    [SerializeField]
    public Sprite sprite;
    [SerializeField]
    public string objectName;
}
