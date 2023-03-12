using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeposanAnimation : MonoBehaviour
{
    private Animator animator;
    bool flag = true;

    public void Area()
    {
        if (flag == true)
        {
            animator = GetComponent<Animator>();
            animator.SetTrigger("Appear");
            flag = false;
        }
    }
}