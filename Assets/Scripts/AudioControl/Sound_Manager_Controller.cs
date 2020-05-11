using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager_Controller : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float musicVolume;
    [SerializeField, Range(0, 1)] float sfxVolume;

    [SerializeField] AudioClip[] musicAudiClips;

    // Start is called before the first frame update
    void Start()
    {
        Sound_Manager.Instance.PlayMusic(musicAudiClips[0]);
    }

    // Update is called once per frame
    void Update()
    {
        Sound_Manager.Instance.SetMusicVolume(musicVolume);
        Sound_Manager.Instance.SetSFXVolume(sfxVolume);
    }
}
