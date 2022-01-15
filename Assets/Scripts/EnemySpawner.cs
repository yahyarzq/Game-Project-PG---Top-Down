using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadius = 8;
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
        Instantiate(enemies[Random.Range(0,enemies.Length)],spawnPos,Quaternion.identity);

        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemies());
    }
}
