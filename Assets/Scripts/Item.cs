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

        PlayerInputs eventReset = GameObject.Find("RealPlayer").GetComponent<PlayerInputs>();
        eventReset.resetItems += ActivateItem;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory.instance.Add();
        anim.SetBool("Pick", true);
        coll.enabled = false;
    }

    private void ActivateItem(object sender, EventArgs e)
    {
        anim.SetBool("Pick", false);
        coll.enabled = true;
    }
}
