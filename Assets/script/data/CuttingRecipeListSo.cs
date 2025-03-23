
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CuttingRecipe
{
    public KitchenObject input;
    public KitchenObject output;
}

[CreateAssetMenu()]
public class CuttingRecipeListSao : ScriptableObject {
    [SerializeField]
    public List<CuttingRecipe> list;
    public KitchenObject getOutput(KitchenObject input) { 
        foreach (CuttingRecipe c in list)
        {
            if (c.input == input) { 
                return c.output;
            }
        }
        return null;
    }
}
