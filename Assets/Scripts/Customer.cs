using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAnimation(bool isAccept)
    {
        anim.SetBool("Accept", isAccept);
    }
}
