using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusicSource;
    public AudioSource playerStepSource;
    public AudioSource playerShootSource;
    public AudioSource enemyStepSource;
    public AudioSource scrimmerSource;
    public AudioSource enemyAttackSource;
    public AudioSource keyPickUpSource;
    public AudioSource closeDoorSource;
    public AudioSource openDoorSource;
    public AudioSource openBoxSource;

    public AudioClip backgroundMusic;
    public AudioClip[] playerStepSounds;
    public AudioClip playerShootSound;
    public AudioClip[] enemyStepSounds;
    public AudioClip scrimmerSound;
    public AudioClip enemyAttackSound;
    public AudioClip keyPickUpSound;
    public AudioClip closeDoorSound;
    public AudioClip openDoorSound;
    public AudioClip openBoxSound;

    private static SoundManager instance = null;
      
    public static SoundManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundMusic != null)
        {
            backgroundMusicSource.clip = backgroundMusic;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }

    public void PlayPlayerStepSound(bool isMoving)
    {
        if (playerStepSource != null && playerStepSounds.Length > 0 && isMoving)
        {
            int index = Random.Range(0, playerStepSounds.Length);
            playerStepSource.clip = playerStepSounds[index];
            playerStepSource.Play();
        }
    }

    public void PlayPlayerShootSound()
    {
        if (playerShootSource != null && playerShootSound != null)
        {
            playerShootSource.clip = playerShootSound;
            playerShootSource.Play();
        }
    }

    public void PlayMobStepSound()
    {
        if (enemyStepSource != null && enemyStepSounds.Length > 0)
        {
            int index = Random.Range(0, enemyStepSounds.Length);
            enemyStepSource.clip = enemyStepSounds[index];
            enemyStepSource.Play();
        }
    }

    public void PlayScrimmerSound()
    {
        if (scrimmerSource != null && scrimmerSound != null)
        {
            scrimmerSource.clip = scrimmerSound;
            scrimmerSource.Play();
        }
    }

    public void PlayEnemyAttackSound()
    {
        if (enemyAttackSource != null && enemyAttackSound != null)
        {
            enemyAttackSource.clip = enemyAttackSound;
            enemyAttackSource.Play();
        }
    }

    public void PlayKeyPickUpSound()
    {
        if (keyPickUpSource != null && keyPickUpSound != null)
        {
            keyPickUpSource.clip = keyPickUpSound;
            keyPickUpSource.Play();
        }
    }

    public void PlayCloseDoorSource()
    {
        if (closeDoorSource != null && closeDoorSound != null)
        {
            closeDoorSource.clip = closeDoorSound;
            closeDoorSource.Play();
        }

    }
    public void PlayOpenDoorSourceSource()
    {
        if (openDoorSource != null && openDoorSound != null)
        {
            openDoorSource.clip = openDoorSound;
            openDoorSource.Play();
        }
    }
    public void PlayOpenBoxSound()
    {
        if (openBoxSource != null && openBoxSound != null)
        {
            openBoxSource.clip = openBoxSound;
            openBoxSource.Play();
        }
    }

}
