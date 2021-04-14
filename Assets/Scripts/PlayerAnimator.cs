using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator playerAnimator;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            FlipSprite(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            FlipSprite(false);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetWalkState(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetWalkState(false);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Land();
        }
    }

    public void FlipSprite(bool isRight)
    {

        playerSprite.flipX = !isRight;

    }

    public void SetWalkState(bool isWalking)
    {
        playerAnimator.SetBool("IsLanding", false);
        playerAnimator.SetBool("IsWalking", isWalking);
    }

    public void Jump()
    {
        playerAnimator.SetBool("IsJumping", true);
    }
    public void Land()
    {
        playerAnimator.SetBool("IsJumping", false);
        playerAnimator.SetBool("IsLanding", true);
    }
}
