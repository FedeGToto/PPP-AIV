using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


enum combination { com_1, com_2, com_3, com_4, com_5, com_6, last}

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] PlayerAnimator anim;
    [SerializeField] float speed, jumpForce;

    KeyCode A, W, D;
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

        A = KeyCode.A;
        W = KeyCode.W;
        D = KeyCode.D;

        combination com = (combination)Random.Range(0, (int)combination.last);

        switch (com)
        {
            case combination.com_1:
                leftKey =  W;
                rightKey = A;
                jumpKey =  D;
                break;
            case combination.com_2:
                leftKey = W;
                rightKey = D;
                jumpKey = A;
                break;
            case combination.com_3:
                leftKey = D;
                rightKey = W;
                jumpKey = A;
                break;
            case combination.com_4:
                leftKey = D;
                rightKey = A;
                jumpKey = W;
                break;
            case combination.com_5:
                leftKey = A;
                rightKey = D;
                jumpKey = W;
                break;
            case combination.com_6:
                leftKey = A;
                rightKey = W;
                jumpKey = D;
                break;
        }


        // se è il player giusto avrà gli input giusto
        //if (degugIsRightPlayer)
        //{
        //    leftKey = KeyCode.A;
        //    rightKey = KeyCode.D;
        //    jumpKey = KeyCode.W;
        //}
        //else
        //{
        //    // altrimenti in modo random gli setto gli input
        //    int indx = Random.Range(0, possibleInputs.Count);
        //    leftKey = possibleInputs[indx];
        //    possibleInputs.RemoveAt(indx);

        //    indx = Random.Range(0, possibleInputs.Count);
        //    rightKey = possibleInputs[indx];
        //    possibleInputs.RemoveAt(indx);

        //    jumpKey = possibleInputs[0];
        //}
    }

    private void Update()
    {
        Move(leftKey,rightKey,jumpKey);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(0);
        }

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
