using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameMechanics : MonoBehaviour
{
    [Header("Spawning Objects")]
    [SerializeField] GameObject rock;
    [SerializeField] GameObject paper;
    [SerializeField] GameObject scissors;

    //spawning pos
    [Header("AI Object Position")]
    [SerializeField] Transform spawnAIPos;

    [Header("Player Object Position")]
    [SerializeField] Transform spawnPlayerPos;

    [Header("UI Numbers")]
    [SerializeField] Text round;
    [SerializeField] Text withoutBayes;
    [SerializeField] Text withBayes;

    //num for checking round number
    public int roundNum = 0;
    int afterRandomRoundNum = 1;

    //nums for win rate
    int playerWonCounter = 0;
    int aiWonCounter = 0;
    int aiWonCounterWithBayes = 0;

    //new gameobject is the one which is last instantitated
    GameObject newPlayerGameObject;
    GameObject newAIGameObject;

    //win rate
    float winRateWithoutBayes = 0.0f;
    float winRateWithBayes = 0.0f;
    

    void Start()
    {
        roundNum = 0;
    }

    void Update()
    {
        //write out round num
        round.text = roundNum.ToString();

        //check for situations
        //PlayerWon();
        //Debug.Log(playerWonCounter);
        //Debug.Log(aiWonCounter);
        
        AIWon();
        Tie();
    }

    #region Player Spawning
    public void SpawnPlayerRock()
    {
        newPlayerGameObject = Instantiate(rock, spawnPlayerPos.position, Quaternion.identity);
        roundNum++;
        Destroy(newPlayerGameObject, 2f);
    }

    public void SpawnPlayerPaper()
    {
        newPlayerGameObject = Instantiate(paper, spawnPlayerPos.position, Quaternion.Euler(90, 0, 180));
        roundNum++;
        Destroy(newPlayerGameObject, 2f);
    }

    public void SpawnPlayerScissors()
    {
        newPlayerGameObject = Instantiate(scissors, new Vector3(spawnPlayerPos.position.x, -.1f, spawnPlayerPos.position.z), Quaternion.identity);
        roundNum++;
        Destroy(newPlayerGameObject, 2f);
    }
    #endregion

    #region AI Spawning
    public void SpawnAIRock()
    {
        newAIGameObject = Instantiate(rock, spawnAIPos.position, Quaternion.identity);
        Destroy(newAIGameObject, 2f);
    }

    public void SpawnAIPaper()
    {
        newAIGameObject = Instantiate(paper, spawnAIPos.position, Quaternion.Euler(90, 0, 180));
        Destroy(newAIGameObject, 2f);
    }

    public void SpawnAIScissors()
    {
        newAIGameObject = Instantiate(scissors, new Vector3(spawnAIPos.position.x, -.1f, spawnAIPos.position.z), Quaternion.identity);
        Destroy(newAIGameObject, 2f);
    }
    #endregion

    #region Round Outcome
    //player win situations
    private void PlayerWon()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.S))
        {
            if ((newPlayerGameObject.CompareTag("Rock") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Scissors") && newAIGameObject != null))
            {
                playerWonCounter++;
            }
            else if ((newPlayerGameObject.CompareTag("Scissors") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Paper") && newAIGameObject != null))
            {
                playerWonCounter++;
            }
            else if ((newPlayerGameObject.CompareTag("Paper") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Rock") && newAIGameObject != null))
            {
                playerWonCounter++;
            }
        }
        else return;
    }

    //AI win situations
    void AIWon()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.S))
        { 
            if ((newPlayerGameObject.CompareTag("Scissors") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Rock") && newAIGameObject != null))
            {
                if(roundNum <= 10)
                {
                    aiWonCounter++;
                }
                else
                {
                    aiWonCounterWithBayes++;
                }
            }
            else if ((newPlayerGameObject.CompareTag("Paper") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Scissors") && newAIGameObject != null))
            {
                if (roundNum <= 10)
                {
                    aiWonCounter++;
                }
                else
                {
                    aiWonCounterWithBayes++;
                }
            }
            else if ((newPlayerGameObject.CompareTag("Rock") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Paper") && newAIGameObject != null))
            {
                if (roundNum <= 10)
                {
                    aiWonCounter++;
                }
                else
                {
                    aiWonCounterWithBayes++;
                }
            }

            //write out and calcute win rate without Bayes
            if (roundNum <= 10)
                WithoutNaiveBayes();
            else
                //write out and calculate win rate with Bayes 
                WithNaiveBayes();
        }
        else return;
    }

    //tie situations
    void Tie()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.S))
        {
            if ((newPlayerGameObject.CompareTag("Rock") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Rock") && newAIGameObject != null))
            {
                return;
            }
            else if ((newPlayerGameObject.CompareTag("Scissors") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Scissors") && newAIGameObject != null))
            {
                return;
            }
            else if ((newPlayerGameObject.CompareTag("Paper") && newPlayerGameObject != null) && (newAIGameObject.CompareTag("Paper") && newAIGameObject != null))
            {
                return;
            }
        }
        else return;
    }
    #endregion

    #region Win Rate Calculating

    //method that calculates AI win rate without Naive Bayes
    void WithoutNaiveBayes()
    {
        winRateWithoutBayes = (float) 100 * aiWonCounter / roundNum;
        withoutBayes.text = winRateWithoutBayes.ToString("F2") + "%";
    }

    void WithNaiveBayes()
    {
        winRateWithBayes = (float) 100 * aiWonCounterWithBayes / afterRandomRoundNum;
        afterRandomRoundNum++;
        if (winRateWithBayes > 100)
            winRateWithBayes = 100;
        withBayes.text = winRateWithBayes.ToString("F2") + "%";
        Debug.Log(afterRandomRoundNum);
    }

    #endregion
}
