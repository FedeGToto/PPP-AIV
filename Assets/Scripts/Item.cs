using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator anim;
    Collider2D coll;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();


        GameObject g = GameObject.FindGameObjectWithTag("Player");
        PlayerInputs eventReset = g.GetComponent<PlayerInputs>();

        eventReset.resetItems += ActivateItem;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" || collision.gameObject.tag == "RightPlayer")
        {
            Inventory.instance.Add();
            anim.SetBool("Pick", true);
            coll.enabled = false;
        }
    }

    private void ActivateItem(object sender, EventArgs e)
    {
        anim.SetBool("Pick", false);
        coll.enabled = true;
    }
}
