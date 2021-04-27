using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInputs p;
        collision.gameObject.TryGetComponent(out p);
        if (p != null) 
        {
            if (p.IsRight)
            {
                // resettare tutto
            }
            else
                p.gameObject.SetActive(false);
        }
    }
}
