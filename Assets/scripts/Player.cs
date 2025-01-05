using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : KitchObjectHold
{
    public static Player Instance { get; private set; } 
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    private bool isWalking;
    [SerializeField]
    private GameInput gameInput;
    [SerializeField]
    private LayerMask layerMask;
    //他现在要转移的是全部是柜台了  而不仅仅是某一个
    private BaseCounter clearCounter;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.clearCounter);
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.clearCounter?.Interact(this);
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
            if (hitInfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
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

    public void SetClearCounter(BaseCounter clearCounter) {
       
        if (this.clearCounter != clearCounter) {
            this.clearCounter?.UnSelectCounter();
            this.clearCounter = clearCounter;
            clearCounter?.SelectCounter();
        }
    }
}
  