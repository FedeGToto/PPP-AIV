using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoadNextLevel : MonoBehaviour
{
    public enum Levels {Main_Menu, Level_1, Level_2, Level_3, Level_4, Level_5}

    public void Start()
    {
        //GoalHandler goal = GameObject.Find("Player").GetComponent<GoalHandler>();

        GameObject g = GameObject.FindGameObjectWithTag("Player");
        GoalHandler goal = g.GetComponent<GoalHandler>();
        goal.On_Goal_Collision += Load_Next_Level;
    }

    public void Load_Next_Level(object sender, EventArgs e)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Load_Level(int level)
    {
        Levels levels = (Levels)level;
        SceneManager.LoadScene(levels.ToString());
    }
}
