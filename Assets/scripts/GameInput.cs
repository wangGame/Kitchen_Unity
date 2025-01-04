using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 getMoveDirectionNormalized (){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        return direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
