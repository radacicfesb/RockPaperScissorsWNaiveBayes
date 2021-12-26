using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //num for checking round number
    int roundNum;

    //new gameobject is the one which is last instantitated
    GameObject newPlayerGameObject;
    GameObject newAIGameObject;

    void Start()
    {
        roundNum = 0;
    }

    void Update()
    {
        
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
}
