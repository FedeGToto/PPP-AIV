//using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] bool degugIsRightPlayer;
    [SerializeField] KeyCode leftKey, rightKey, jumpKey;

    List<KeyCode> possibleInputs;

    Rigidbody2D rb;

    bool isJumping;

    float hMove, vMove;
    [SerializeField] float speed, jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        possibleInputs = new List<KeyCode>();

        possibleInputs.Add(KeyCode.W);
        possibleInputs.Add(KeyCode.A);
        possibleInputs.Add(KeyCode.D);

        // se � il player giusto avr� gli input giusto
        if (degugIsRightPlayer)
        {
            leftKey = KeyCode.A;
            rightKey = KeyCode.D;
            jumpKey = KeyCode.W;
        }
        else
        {
            // altrimenti in modo random gli setto gli input
            int indx = Random.Range(0, possibleInputs.Count);
            leftKey = possibleInputs[indx];
            possibleInputs.RemoveAt(indx);

            indx = Random.Range(0, possibleInputs.Count);
            rightKey = possibleInputs[indx];
            possibleInputs.RemoveAt(indx);

            jumpKey = possibleInputs[0];
        }
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
