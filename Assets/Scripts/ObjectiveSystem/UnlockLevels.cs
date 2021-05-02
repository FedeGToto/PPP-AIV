using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevels : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> levels;
    private int[] levelUnlocked = new int[4];

    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("levelReached", 1);
        int levelReached = PlayerPrefs.GetInt("allUnlocked", 1);

        if (levelReached <= currentLevel)
        {
            levelReached = currentLevel;

            PlayerPrefs.SetInt("allUnlocked", levelReached);
        }

        for (int i = 0; i < levels.Count; i++)
        {
            if (i + 1 <= levelReached)
            {
                levels[i].SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.SetInt("levelReached", 1);
        }
    }
}
