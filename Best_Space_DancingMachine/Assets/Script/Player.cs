using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    public Animator animator;
    public int dance = 0;

    public void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    public void Update()
    {

       dance = PlayerData.getInstance().danceNum;
       animator.SetInteger("dancePlay", dance);

    }
}
