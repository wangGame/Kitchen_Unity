using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        animator.SetTrigger("OpenClose");
    }
}
