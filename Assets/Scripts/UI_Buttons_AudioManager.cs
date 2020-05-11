using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Buttons_AudioManager : MonoBehaviour
{
    [SerializeField] Sound_Manager sound_Manager;
    [SerializeField] AudioClip[] audioClips;
    
    [SerializeField] Button[] buttons;
    [SerializeField] AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(() => PlaySound(closureIndex));
        }
    }

    void PlaySound(int buttonIndex)
    {
        Sound_Manager.Instance.PlaySFX(audioClips[buttonIndex]);
        
    }
}
