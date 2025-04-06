using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    [SerializeField] private float spawnRate = 3;
    private float timer = 3;
    [SerializeField] private KitchenObject plateSo;
    [SerializeField]private int plateCountMax = 3;
    private List<KitchObjectController> plateList;

    private void Awake()
    {
        plateList = new List<KitchObjectController>();
    }

    public override void Interact(Player player)
    {
        if (player.GetKitchObjectController() == null) {
            if (plateList.Count > 0) {
                KitchObjectController kitch =  plateList[plateList.Count - 1];
                player.AddKitchenObjectController(kitch);
                plateList.Remove(kitch);

            }
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (plateList.Count < plateCountMax)
        {
            if (timer > spawnRate)
            {
                SpawnPlate();
                timer = 0;
            }
        }
        
    }


    public void SpawnPlate() {
        KitchObjectController kitchen = GameObject.Instantiate(plateSo.prefab, topPoint.transform).GetComponent<KitchObjectController>();
        SetKitchObjectController(kitchen);
        plateList.Add(kitchen);
        kitchen.transform.localPosition = Vector3.up * 0.1f * plateList.Count;

    }
}
