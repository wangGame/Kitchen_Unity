using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance { get; private set; }
    [SerializeField]
    private RecipListSO recipListSO;
    [SerializeField]
    private float orderRate = 2;
    private float orderTimer;
    private bool isStartOrder;
    [SerializeField]
    private int maxOrder;
    private int orderCount;
    //随机下单
    private List<RecipeSo> orderRecipeSOList;

    private void Awake()
    {
        instance = this;
        orderRecipeSOList = new List<RecipeSo>();
    }

    private void Update()
    {
        if (isStartOrder) {
            OrderUpdate();        
        }
    }

    public void OrderUpdate() {
        orderTimer += Time.deltaTime;
        if (orderTimer >= orderRate && orderCount<maxOrder) {
            orderTimer = 0;
            OrderNewRecipe();
        }
    }

    private void OrderNewRecipe() { 
        orderCount++;
        int random = Random.Range(0, recipListSO.recipeSos.Count);
        orderRecipeSOList.Add(recipListSO.recipeSos[random]);
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchen) {
        RecipeSo correctRecipe = null;
        foreach (var item in orderRecipeSOList)
        {
            if (IsCrrect(item, plateKitchen)) { 
                correctRecipe = item;
            }
        }

        if (correctRecipe != null) {
            print("成功");
        } else {
            print("失败");
            orderRecipeSOList.Remove(correctRecipe);
        }
    }

    private bool IsCrrect(RecipeSo recipe,PlateKitchenObject plateKitchenObject) {
        List<KitchenObject> list1 = recipe.GetKitchenObjects();
        List<KitchenObject> list2 = plateKitchenObject.GetKitchenObjects();
        if (list1.Count!=list2.Count) { return false; }
        foreach (var item in list1)
        {
            if (!list2.Contains(item)) { 
                return false;
            }
        }
        return true;
    }
}
