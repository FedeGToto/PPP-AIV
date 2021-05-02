using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Key : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keyNum;
    Animator anim;
    Collider2D col;
    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        keyNum.text = "x0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInputs p;
        collision.gameObject.TryGetComponent(out p);
        if (p != null)
        {
            anim.SetBool("Picked", true);
            p.PickKey();
            col.enabled = false;
            keyNum.text = "x1";
        }
    }
}
