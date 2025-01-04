using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    private bool isWalking;
    [SerializeField]
    private GameInput gameInput;
    [SerializeField]
    private LayerMask layerMask;
    private ClearCounter clearCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.clearCounter.Interact();
        }
        HandInteraction();

    }

    private void FixedUpdate()
    {
        HandMove();
    }

    public bool IsWalking {  get { return isWalking; } }

    private void HandMove() {
        Vector3 direction = gameInput.getMoveDirectionNormalized();
        direction = direction.normalized;
        transform.position += direction * Time.deltaTime * speed;
        if (direction != Vector3.zero)
        {
            isWalking = true;
            //transform.forward = Vector3.Lerp(transform.forward,direction,Time.deltaTime*rotationSpeed);
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotationSpeed);
            //transform.forward = direction; //前方向
        }
        else
        {
            isWalking = false;
        }
    }

    private void HandInteraction() {
        //检测前方是否有柜台，如果有就执行响应操作
        /*RaycastHit hitInfo;
        bool isCollide = Physics.Raycast(transform.position,transform.forward,out hitInfo,2);
        if (isCollide) {
            Debug.Log(hitInfo.collider.name);
            ClearCounter counter = hitInfo.transform.GetComponent<ClearCounter>();
            counter.Interact();
        }*/
        /**
         * 参数说明：
         *   位置  
         *   正前方
         *   撞击信息
         *   距离
         *   设置撞击的曾
         *
         */
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 2, layerMask))
        {
            if (hitInfo.transform.TryGetComponent<ClearCounter>(out ClearCounter counter))
            {
                SetClearCounter(counter);
            }
            else
            {
                SetClearCounter(null);
            }
        }
        else {
            SetClearCounter(null);
        }
    }

    public void SetClearCounter(ClearCounter clearCounter) {
        if (clearCounter == null) {
            return;
        }
        if (this.clearCounter != clearCounter) {
            this.clearCounter?.UnSelectCounter();
            this.clearCounter = clearCounter;
            clearCounter?.SelectCounter();
        }
    }
}
  