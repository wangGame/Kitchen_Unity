using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Mode mode;
    public enum Mode { 
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraBackward,
    }

    // Update is called once per frame
    void Update()
    {
        //Ui面向相机
        switch (mode) { 
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookAtInverted:
                transform.LookAt(transform.position - Camera.main.transform.position + transform.position);
                break;
            case Mode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                    break;
            case Mode.CameraBackward:
                transform.forward = -Camera.main.transform.forward;
                break;
            default:
                transform.forward = Camera.main.transform.forward;
                break;
        }
        //transform.LookAt(Camera.main.transform);
    }
}
