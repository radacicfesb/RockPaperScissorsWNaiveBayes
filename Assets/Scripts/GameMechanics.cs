using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour
{
    [Header("Spawning Objects")]
    [SerializeField] GameObject rock;
    [SerializeField] GameObject paper;
    [SerializeField] GameObject scissors;

    [Header("Player Object Position")]
    [SerializeField] Transform spawnPos;

    void Start()
    {
    
    }

    void Update()
    {
  
    }

    public void SpawnRock()
    {
        Instantiate(rock, spawnPos.position, Quaternion.identity);
    }

    public void SpawnPaper()
    {
        Instantiate(paper, spawnPos.position, Quaternion.identity);
    }

    public void SpawnScissors()
    {
        Instantiate(scissors, spawnPos.position, Quaternion.identity);
    }


}
