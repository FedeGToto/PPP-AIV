using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSubscriber : MonoBehaviour
{
    //this was a test

    void Start()
    {
        GoalHandler goal = GameObject.Find("Player").GetComponent<GoalHandler>();
        goal.On_Goal_Collision += DoSomething;
    }

    private void DoSomething(object sender, GoalHandler.OnCheck e)
    {
        Debug.Log("You reached the goal asshole " + e.Result);

    }

}
