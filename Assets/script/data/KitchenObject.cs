using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ҫ���Ҽ��д���
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
