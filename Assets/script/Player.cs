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
        //水平
        float horizonTal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3 (horizonTal, 0,vertical);
        transform.position += direction.normalized * Time.deltaTime* speed;

        //Vector3 Lerp 和 Vector3 sLerp的区别
        //朝向
        if (direction != Vector3.zero) {
            //朝向不为0的时候
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
