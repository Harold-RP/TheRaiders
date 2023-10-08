using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAS;
    public AudioSource sfxAS;
    public float musicVol = 0.5f;
    public float sfxVol = 1f;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        musicAS.volume = musicVol;
        musicAS.loop = true;
        musicAS.playOnAwake = true;
        sfxAS.volume = sfxVol;
        sfxAS.loop = false;
        sfxAS.playOnAwake = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip sound)
    {
        sfxAS.PlayOneShot(sound);
    }

    public void SetMusic(AudioClip music)
    {
        musicAS.Stop();
        musicAS.clip = music;
        musicAS.Play();
    }
}
