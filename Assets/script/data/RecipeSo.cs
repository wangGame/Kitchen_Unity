using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSo : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]
    private List<KitchenObject> kitchenObjects;

    public List<KitchenObject> GetKitchenObjects() { return kitchenObjects; }
}
