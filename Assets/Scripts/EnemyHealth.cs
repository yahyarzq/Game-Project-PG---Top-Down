using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health;

    public int scoreKill;

    private bool explosion;

    public AudioClip deathClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroyEnemy();
    }

    void destroyEnemy(){
        if (health < 1){
            GameplayManager.instance.AddScore(scoreKill);
            Destroy(gameObject);
            SoundManager.instance.PlaySound(deathClip);
        }
    }
    private void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Projectile") //
        {
            health -= GameObject.Find("Player").GetComponent<PlayerController>().weapon.damage;
            Destroy(target.gameObject);
        }
    }
    public void TakeDamage(){
        if(!explosion){
            explosion =true;
            health -= GameObject.Find("Player").GetComponent<PlayerController>().weaponSecondary.damage;
        }
    }
}
