using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roaryAnimationEnds : MonoBehaviour
{
    private Animator animator;
    private bool animationPlayed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!animationPlayed && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.IsInTransition(0))
        {
            animationPlayed = true;
            gameObject.SetActive(false);
        }
    }
}
