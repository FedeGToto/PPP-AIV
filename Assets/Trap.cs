using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInputs player = collision.gameObject.GetComponent<PlayerInputs>();

        if (player != null)
        {
            player.ResetPosition();
        }
    }
}
