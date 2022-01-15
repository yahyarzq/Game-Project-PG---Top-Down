using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource soundFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake() {
        instance = this;
    }

    public void PlaySound(AudioClip clip){
        soundFX.clip = clip;
        soundFX.volume =Random.Range(.3f,.5f);
        soundFX.pitch = Random.Range(.0f,1);
        //soundFX.Play();
    }
}
