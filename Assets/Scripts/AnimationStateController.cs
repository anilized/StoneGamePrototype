using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    private bool isWalking;
    // for not using string on Animator set methods
    private int isWalkingHash;
    private int isRunningHash;
    
    void Start()
    {
        //Declarations
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalking = animator.GetBool(isWalkingHash);
    }
    
    void Update()
    {
        bool forwardPress = Input.GetKey(KeyCode.W);
        bool runPress = Input.GetKey(KeyCode.LeftShift);
        if (forwardPress)
        {
            Debug.Log("Forward press");
            animator.SetBool(isWalkingHash, true);
            isWalking = true;
            if (runPress && (isWalking == true || isWalking == false))
            {
                isWalking = false;
                animator.SetBool(isRunningHash, true);
                
            } else
            {
                animator.SetBool(isRunningHash, false);
                animator.SetBool(isWalkingHash, true);
                
                
            }
        } else
        {
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isRunningHash, false);
            
            
        }
        
    }
}
