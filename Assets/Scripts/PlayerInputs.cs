//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum combination { com_1, com_2, com_3, com_4, com_5, com_6, com_7, com_8, last}

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] float minLag, maxLag;
    [SerializeField] bool degugIsRightPlayer;
    [SerializeField] KeyCode leftKey, rightKey, jumpKey;

    KeyCode A, W, D;

    Rigidbody2D rb;

    bool isJumping;

    float hMove, vMove;
    [SerializeField] float speed, jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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

        Debug.Log((int)com);


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

        if (rb.velocity.y == 0) isJumping = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hMove * speed, rb.velocity.y);
    }
        
    private void Move(KeyCode leftKey, KeyCode rightKey, KeyCode jumpKey)
    {
        if (Input.GetKey(leftKey))
            hMove = -1;
        else if (Input.GetKey(rightKey))
            hMove = 1;
        else hMove = 0f;

        if (Input.GetKeyDown(jumpKey) && !isJumping) 
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            isJumping = false;
        }
    }
}
