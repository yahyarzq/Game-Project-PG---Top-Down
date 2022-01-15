using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon",menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite currentWeapon;
    public GameObject bulletPrefab;
    private Animator anim;
    private Transform firePoint;
    public float fireRate = 1;
    public int damage = 20;

    public float bulletForce = 20f;

    public AudioClip[] shootClips ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFirePoint(Transform firepoint){
        firePoint = firepoint;
    }
    public void Shoot(){
        GameObject bullet =  Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce,ForceMode2D.Impulse);
        SoundManager.instance.PlaySound(shootClips[Random.Range(0,shootClips.Length)]);
    }

}
