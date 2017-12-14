using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public Animator animator;

    public void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("dancePlay", 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("dancePlay", 0);
        }

    }
}
