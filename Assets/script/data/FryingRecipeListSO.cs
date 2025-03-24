using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeListSO : ScriptableObject
{
    public List<FryingReceipe> fryingRecipeList;
    public FryingReceipe GetFryingRecipe(KitchenObject input) {
        foreach (var item in fryingRecipeList)
        {
            if (item.input == input) { 
                return item;
            }
        }
        return null;
    }
}

[Serializable]
public class FryingReceipe { 
    public KitchenObject input;
    public KitchenObject output;
    public float fryingTime;
}
