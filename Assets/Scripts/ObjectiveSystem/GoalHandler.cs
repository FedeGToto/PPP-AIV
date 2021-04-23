using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHandler : MonoBehaviour
{
    public class OnCheck : EventArgs
    {
        public int Result;
    }

    //i've used "OnCheck" just to see if i was calling the correct function

    public event EventHandler On_Goal_Collision;

    //i'm not sure how want the collision, so just in case i used both
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //i am using "Goal" as a tag for the obj which define the end of the level

        if (collision.gameObject.tag == "Goal")
        {
            On_Goal_Collision?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            On_Goal_Collision?.Invoke(this, EventArgs.Empty);
            PlayerPrefs.SetInt("levelReached", SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
