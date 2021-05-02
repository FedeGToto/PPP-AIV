using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossFight : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInputs p;
        collision.gameObject.TryGetComponent(out p);
        if (p != null)
        {
            if (p.GetKey())
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
    }
}
