using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //getting GameMechanics object
    GameMechanics mech;
    GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("Game Manager");
        mech = manager.GetComponent<GameMechanics>();
    }
    void Update()
    {
        CheckForPlayerInput();
    }

    //spawning objects
    void CheckForPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            mech.SpawnPlayerRock();
        }
        else if (Input.GetKeyDown(KeyCode.P))           //dodat jos animacije itd
        {
            mech.SpawnPlayerPaper();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            mech.SpawnPlayerScissors();
        }
    }

    
}
