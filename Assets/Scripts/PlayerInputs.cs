using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] PlayerAnimator anim;
    [SerializeField] float speed, jumpForce;
    public bool IsRight;

    KeyCode leftKey, rightKey, jumpKey;

    Rigidbody2D rb;

    Vector2 initialPos;

    bool isJumping;

    public bool isRightPlayer = false;
    public List<PlayerInputs> falsePlayers;
    public event EventHandler resetItems;

    public CamerasManager cameras;

    float hMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPos = rb.position;
    }

    public void SetInput(PossibleInput p)
    {
        leftKey = p.leftKey;
        rightKey = p.rightKey;
        jumpKey = p.jumpKey;
    }

    private void Update()
    {
        Move(leftKey, rightKey, jumpKey);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            SceneManager.LoadScene(0);

        if (hMove == 0)

        if (rb.velocity.y == 0) isJumping = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hMove * speed, rb.velocity.y);
    }
        
    private void Move(KeyCode leftKey, KeyCode rightKey, KeyCode jumpKey)
    {
        if (Input.GetKey(leftKey))
        {
            hMove = -1;
            anim.SetWalkState(true);
            anim.FlipSprite(false);
        }
        else if (Input.GetKey(rightKey))
        {
            hMove = 1;
            anim.SetWalkState(true);
            anim.FlipSprite(true);
        }
        else
        {
            anim.SetWalkState(false);
            hMove = 0f;
        }

        if (Input.GetKeyDown(jumpKey) && !isJumping) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            anim.Jump();
        }

        if (rb.velocity.y < 0) anim.Land();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            isJumping = false;
        }
    }

    public void ResetPosition()
    {
        if (isRightPlayer)
        {
            rb.position = initialPos;

            for (int i = 0; i < falsePlayers.Count; i++)
            {
                falsePlayers[i].rb.gameObject.SetActive(true);
                falsePlayers[i].rb.position = falsePlayers[i].initialPos;
            }

            resetItems?.Invoke(this, EventArgs.Empty);
            cameras.AssignCameras();
        }

        else
        {
            //disable gameObj an Rb collider
            rb.position = initialPos;
            gameObject.SetActive(false);
        }
    }

}
