using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawn : MonoBehaviour
{
    //getting GameMechanics gameobject
    GameMechanics mech;
    GameObject manager;

    //counter of each option played by player
    int playedRock = 0;
    int playedScissors = 0;
    int playedPaper = 0;

    //chances of player playing each option
    float chanceOfRock = 0.0f;
    float chanceOfScissors = 0.0f;
    float chanceOfPaper = 0.0f;

    void Start()
    {
        manager = GameObject.Find("Game Manager");
        mech = manager.GetComponent<GameMechanics>();
    }

    void Update()
    {
        //calling method Chance() so AI can learn 
        Chance();

        //AI will play if players input is valid
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.S))
        {
            //if roundNum is <= 10 AI will play random
            if (mech.roundNum < 10)
                RandomPlay();

            //else AI will play based on Naive Bayes 
            else
                NaiveBayes();
        }
        Debug.Log(chanceOfRock);
    }

    //method for random playing
    void RandomPlay()
    {
        //with this random num AI randomly calls one method
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

    //method for calculating chances of player playing each option
    void Chance()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.S))
        { 
            if (Input.GetKeyDown(KeyCode.R))
            {
                playedRock++;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                playedScissors++;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                playedPaper++;
            }
            else
                return;

            chanceOfRock = (float)playedRock / (mech.roundNum + 1);
            chanceOfScissors = (float)playedScissors / (mech.roundNum + 1);
            chanceOfPaper = (float)playedPaper / (mech.roundNum + 1);
        } 
    }

    //implemented Naive Bayes
    void NaiveBayes()
    {
        if (chanceOfRock > chanceOfScissors && chanceOfRock > chanceOfPaper)
        {
            mech.SpawnAIPaper();
        }
        else if (chanceOfScissors > chanceOfRock && chanceOfScissors > chanceOfPaper)
        {
            mech.SpawnAIRock();
        }
        else if (chanceOfPaper > chanceOfRock && chanceOfPaper > chanceOfScissors)
        {
            mech.SpawnAIScissors();
        }
        else
        {
            RandomPlay(); //calling RandomPlay() in case all chances are equal
        }
    }
}
