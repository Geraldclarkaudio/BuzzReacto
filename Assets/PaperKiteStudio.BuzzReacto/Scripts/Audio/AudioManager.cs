using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Item Sounds")]

    public AudioClip collectedItemSound;
    public AudioClip combinedItemsSound;
    public AudioClip droppedItem;

    [Header("Player Sounds")]
   
    public AudioClip[] footSteps;

    [Header("Enemy Sounds")]
    public AudioClip enemyDestroySound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #region ITEM SPECIFIC SOUNDS
    public void PlayCollectedSound()
    {
        audioSource.clip = collectedItemSound;
        audioSource.Play();
    }

    public void PlayCombinedItemsSound()
    {
        audioSource.clip = combinedItemsSound;
        audioSource.Play();
    }

    public void PlayDropSound()
    {
        audioSource.clip = droppedItem;
        audioSource.Play();
    }
    #endregion

    #region ENEMY SOUNDS
    public void EnemyDestroyed()
    {
        audioSource.clip = enemyDestroySound;
        audioSource.Play();
    }
    #endregion


}
