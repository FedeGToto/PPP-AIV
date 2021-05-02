using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerInputs player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("RightPlayer").GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.ResetPosition();
        }
    }
}
