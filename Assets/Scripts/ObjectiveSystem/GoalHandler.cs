using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{
    public class OnCheck : EventArgs
    {
        public int Result;
    }

    //i've used "OnCheck" just to see if i was calling the correct function

    public event EventHandler<OnCheck> On_Goal_Collision;

    //i'm not sure how want the collision, so just in case i used both
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //i am using "Goal" as a tag for the obj which define the end of the level

        if (collision.gameObject.tag == "Goal")
        {
            On_Goal_Collision?.Invoke(this, new OnCheck {Result = 1});
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            On_Goal_Collision?.Invoke(this, new OnCheck { Result = 2 });
        }
    }

}
