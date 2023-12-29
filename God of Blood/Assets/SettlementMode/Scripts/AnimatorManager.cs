using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator animator;
    int horizontal;
    int vertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        // animation snapping
        float snappedHor;
        float snappedVert;

        #region Snapped Horizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            snappedHor = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            snappedHor = 1;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snappedHor = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            snappedHor = -1;
        }
        else
        {
            snappedHor = 0;
        }
        #endregion
        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < 0.55f)
        {
            snappedVert = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            snappedVert = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snappedVert = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snappedVert = -1;
        }
        else
        {
            snappedVert = 0;
        }
        #endregion

        animator.SetFloat(horizontal, snappedHor, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVert, 0.1f, Time.deltaTime);

        //Debug.Log("Horizontal = " + snappedHor + "; Vertical = " + snappedVert);
    }
}
