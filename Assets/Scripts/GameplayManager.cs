using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    private int score;

    public int levelNumber;
    public bool spawn  =true;
    public GameObject[] enemies;

    public Level[] level;
    public TextMeshProUGUI currentScoreText,maxScoreText,roundCount;

    public TextMeshProUGUI roundComplete;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        levelNumber = 0;
        roundCount.text = "Round "+ (levelNumber+1);
    }

    // Update is called once per frame
    void Update()
    {
        Score();
        textUpdateScore();
    }


    void Score(){
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(score >= level[levelNumber].scoreMax){
            StartCoroutine(UpScore());
        }
    }
    public void AddScore(int amountscore){
        score += amountscore;
    }


    IEnumerator UpScore(){
        roundComplete.gameObject.SetActive(true);
        roundComplete.text ="Round "+ (levelNumber+1)+" Complete";
        score =0;
        levelNumber++;
        //GameObject.Find("Player").GetComponent<PlayerController>().weapon = level[levelNumber].weapon
        destroyAllEnemy();
        spawn =false;
        yield return new WaitForSeconds(2);
        roundComplete.gameObject.SetActive(false);
        roundCount.text = "Round "+ (levelNumber+1);
        spawn =true;


    }
    void destroyAllEnemy(){
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }
    }
    void textUpdateScore(){
        currentScoreText.text = score.ToString();
        maxScoreText.text = level[levelNumber].scoreMax.ToString();
    }
}
