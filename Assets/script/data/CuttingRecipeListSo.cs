
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[Serializable]
public class CuttingRecipe
{
    public KitchenObject input;
    public KitchenObject output;
    public int cuttingCountMax;
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

    public CuttingRecipe cuttingRecipe(KitchenObject input) {
        foreach (CuttingRecipe c in list)
        {
            if (c.input == input)
            {
                return c;
            }
        }
        return null;
    }
}
