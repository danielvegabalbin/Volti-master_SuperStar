using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGO : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;

    [SerializeField] AudioSource audioSource;

    [SerializeField] bool useAudio = true;
    private void OnTriggerEnter(Collider other)
    {
        if (useAudio)
        {

            if (other.tag == "Player")
            {
                PlaySound();

                Destroy(gameObject, 0.1f);

            }
        }

    }
    void PlaySound()
    {
        Sound_Manager.Instance.PlaySFX(audioClip);
    }

    
}
