using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float playerRotationSpeed;
    private bool isWalk;
    [SerializeField]
    private LayerMask counterLayerMask;
    private ClearCounter selectedCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            HandleInteraction();
        }
    }

    private void FixedUpdate()
    {
        HandMovement();
    }

    public bool IsWalk {
        get {
            return isWalk; 
        } 
    }

    private void HandMovement() {
        //ˮƽ
        float horizonTal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizonTal, 0, vertical);
        transform.position += direction.normalized * Time.deltaTime * speed;

        //Vector3 Lerp �� Vector3 sLerp������
        //����
        if (direction != Vector3.zero)
        {
            //����Ϊ0��ʱ��
            //Vector3.Slerp
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * playerRotationSpeed);
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
    }

    public void HandleInteraction() {
        //���ǰ���Ƿ���ڹ�̨
        bool isCollide = Physics.Raycast(transform.position,transform.forward,out RaycastHit raycastHit,2, counterLayerMask );
        if (isCollide)
        {
            //Debug.Log(raycastHit.collider.gameObject);
            raycastHit.collider.gameObject.TryGetComponent<ClearCounter>(out ClearCounter clearCounter);
            if (clearCounter != null)
            {
                //clearCounter.Interact();
                SetSelectedCounter(clearCounter);
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else {
            SetSelectedCounter(null);
        }
    }

    public void SetSelectedCounter(ClearCounter clearCounter) {
        if (clearCounter != null) {
            
                if (selectedCounter != null)
                {
                    selectedCounter.CanCelSelected();
                }
                clearCounter.SelectCounter();
                clearCounter.Interact();
            
            this.selectedCounter = clearCounter;
        }
    }

   
}  
