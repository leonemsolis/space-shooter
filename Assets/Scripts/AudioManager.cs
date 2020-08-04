using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource audioSource;

    public static AudioClip selectSound;
    public static AudioClip shoot1Sound;
    public static AudioClip shoot2Sound;
    public static AudioClip winSound;
    public static AudioClip loseSound;
    public static AudioClip playerExplodeSound;
    public static AudioClip asteroidExplodeSound;

    // Singleton instance
    public static AudioManager instance;
    
    private void Awake()
    {   
        // Create singleton
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
            //Load sounds
            selectSound = Resources.Load<AudioClip>("select");
            shoot1Sound = Resources.Load<AudioClip>("shoot1");
            shoot2Sound = Resources.Load<AudioClip>("shoot2");
            winSound = Resources.Load<AudioClip>("win");
            loseSound = Resources.Load<AudioClip>("lose");
            asteroidExplodeSound = Resources.Load<AudioClip>("asteroid");
            playerExplodeSound = Resources.Load<AudioClip>("player");

            audioSource = GetComponent<AudioSource>();
        } else {
            Destroy(gameObject);
        }
    }

    public static void PlaySelect() {
        audioSource.PlayOneShot(selectSound);
    }

    // Play random shoot sound
    public static void PlayShoot() {
        if(Random.Range(0f, 1f) > .5f) {
            audioSource.PlayOneShot(shoot1Sound);
        } else {
            audioSource.PlayOneShot(shoot2Sound);
        }
    }

    public static void PlayPlayerExplosion() {
        audioSource.PlayOneShot(playerExplodeSound);
    }

    public static void PlayAsteroidExplosion() {
        audioSource.PlayOneShot(asteroidExplodeSound);
    }

    public static void PlayWin() {
        audioSource.PlayOneShot(winSound);
    }

    public static void PlayLose() {
        audioSource.PlayOneShot(loseSound);
    }

}
