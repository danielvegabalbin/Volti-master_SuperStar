using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Manager : MonoBehaviour
{
	#region Static Instance
	private static Sound_Manager instance;
	public static Sound_Manager Instance 
	{
		get 
		{

			if (instance == null)
			{
				instance = FindObjectOfType<Sound_Manager>();
				if (instance == null)
				{
					instance = new GameObject("Spawned AudioManager", typeof(Sound_Manager)).GetComponent<Sound_Manager>();
				}
			}
			return instance;
		}

		private set 
		{
			instance = value;
		
		}
	
	
	
	}
	#endregion

	#region Fields

	[SerializeField] float definedVolume = 1;
	[SerializeField] float transitionTime = 1;
	[SerializeField] float musicVolume;

	private AudioSource musicSource;
	private AudioSource musicSource2;
	private AudioSource sfxSource;

	private bool firstMusicSourceIsPlaying;
	#endregion

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);

		musicSource = this.gameObject.AddComponent<AudioSource>();
		musicSource2 = this.gameObject.AddComponent<AudioSource>();
		sfxSource = this.gameObject.AddComponent<AudioSource>();

		musicSource.loop = true;
		musicSource2.loop = true;

	}


	public void PlayMusic(AudioClip musicClip) 
	{
		//Determine which source is Active
		AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;


		activeSource.clip = musicClip;
		activeSource.volume = definedVolume;
		activeSource.Play();
		
	
	}
	public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
	{
		AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;

		StartCoroutine(UpdateMusicWithFade(activeSource,newClip,transitionTime));
	}
	public void PlayMusicWithCrossFade(AudioClip musicClip, float transitionTime = 1.0f)
	{
		//Determine which audioSource is active
		AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
		AudioSource newSource = (firstMusicSourceIsPlaying) ? musicSource2 : musicSource;

		//swap
		firstMusicSourceIsPlaying = !firstMusicSourceIsPlaying;

		//set the fields of tthe music audioSource
		newSource.clip = musicClip;
		newSource.Play();
		StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, transitionTime));
	}
	private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
	{
		if (!activeSource.isPlaying)
		{
			activeSource.Play();
		}

		float t = 0.0f;

		//Fade Out
		for (t = 0; t < transitionTime; t += Time.deltaTime)
		{
			activeSource.volume =(musicVolume- ((1 - (t/transitionTime))* musicVolume));
			//activeSource.volume = (musicVolume - ((t / transitionTime) * musicVolume));
			yield return null;
		}
		activeSource.Stop();
		activeSource.clip = newClip;
		activeSource.Play();

		//Fade In
		for (t = 0; t < transitionTime; t += Time.deltaTime)
		{
			activeSource.volume =  (t / transitionTime) * musicVolume;
			//activeSource.volume = (musicVolume - ((t / transitionTime) * musicVolume));
			yield return null;
		}
		


	}
	private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transitionTime)
	{
		

		float t = 0.0f;

		
		for (t = 0; t < transitionTime; t += Time.deltaTime)
		{
			
			original.volume = (1 - (t / transitionTime));
			newSource.volume = (t / Time.deltaTime);
			//activeSource.volume = (musicVolume - ((t / transitionTime) * musicVolume));
			yield return null;
		}
		original.Stop();
	}
	
	public void PlaySFX(AudioClip clip) 
	{
		sfxSource.PlayOneShot(clip);
	}
	public void PlaySFX(AudioClip clip,float volume)
	{
		sfxSource.PlayOneShot(clip,volume);
	}

	public void SetMusicVolume(float volume) 
	{
		musicSource.volume = volume;
		musicSource2.volume = volume;
	
	}
	public void SetSFXVolume(float volume)
	{
		sfxSource.volume = volume;

	}
}
