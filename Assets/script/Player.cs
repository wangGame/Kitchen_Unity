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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ˮƽ
        float horizonTal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3 (horizonTal, 0,vertical);
        transform.position += direction.normalized * Time.deltaTime* speed;

        //Vector3 Lerp �� Vector3 sLerp������
        //����
        if (direction != Vector3.zero) {
            //����Ϊ0��ʱ��
            //Vector3.Slerp
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * playerRotationSpeed);
        }
    }

    public bool IsWalk {
        get {
            return isWalk; 
        } 
    }  
}  
