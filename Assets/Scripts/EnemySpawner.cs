using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadius = 15;
    public float time =2.0f;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Spwan enemies in random in range player 
    IEnumerator SpawnAnEnemies(){
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        if(GameplayManager.instance.spawn){
            if(Random.value <= 0.2 && GameplayManager.instance.levelNumber>= 2)
                Instantiate(enemies[2],spawnPos,Quaternion.identity);
            else
                Instantiate(enemies[Random.Range(0,enemies.Length -1 )],spawnPos,Quaternion.identity);
        }
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemies());
    }
}
