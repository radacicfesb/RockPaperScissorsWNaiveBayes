using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawn : MonoBehaviour
{
    //getting GameMechanics gameobject
    GameMechanics mech;
    GameObject manager;

    void Start()
    {
        manager = GameObject.Find("Game Manager");
        mech = manager.GetComponent<GameMechanics>();
    }

    void Update()
    {
        //triba provjerit jel runda manja od 10

        //AI will play if players input is valid
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.S))
        {
            RandomPlay();
        }
        
    }

    //first 10 rounds are randomly played
    void RandomPlay()
    {
        //with this random num AI randomly calls one methods
        int rand = Random.Range(0, 3);

        switch (rand)
        {
            case 0:
                mech.SpawnAIRock();
                break;
            case 1:
                mech.SpawnAIPaper();
                break;
            case 2:
                mech.SpawnAIScissors();
                break;
        }
    }
}
