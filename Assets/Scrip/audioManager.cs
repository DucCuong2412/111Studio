using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public float volume;
    public float save_volume;
    public AudioMixer mixer;
    public Slider Slider;
    // audio
    public static AudioManager instance;
    public AudioSource sfxSource;



    //player
    public AudioClip atk1;
    public AudioClip atk2;
    public AudioClip boom;
    public AudioClip jump;
    public AudioClip die;



    //sound boss An
    public AudioClip an1;
    public AudioClip an2;
    public AudioClip an3;
    public AudioClip an4;
    public AudioClip an5;
    public AudioClip an6;
    public AudioClip an7;
    public AudioClip an8;

    //sound boss Lập
    public AudioClip lap1;
    public AudioClip lap2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {


        if (PlayerPrefs.HasKey("mussic_volume"))
        {
            loadmusic();
            Slider.value = save_volume;
        }
        else
        {
            _Music(save_volume);
        }
    }
    private void Update()
    {

        Debug.Log("âm lượng:" + PlayerPrefs.GetFloat("mussic_volume"));
    }
    // chuc nang cua Menu
    //build music
    public void _Music(float volume)
    {
        mixer.SetFloat("volume", volume);
        save_volume = volume;
        Debug.Log("volume" + volume);
        PlayerPrefs.SetFloat("mussic_volume", save_volume);

    }
    public void loadmusic()
    {
        save_volume = PlayerPrefs.GetFloat("mussic_volume");
        volume = save_volume;
        _Music(volume);
        Slider.value = volume;

    }

    public void sound_jump()
    {
        sfxSource.PlayOneShot(jump);

    }
    public void sound_atk1()
    {
        sfxSource.PlayOneShot(atk1);
    }
    public void sound_atk2()
    {
        sfxSource.PlayOneShot(atk2);
    }
    public void sound_die()
    {
        sfxSource.PlayOneShot(die);
    }

    public void sound_lap1()
    {
        sfxSource.PlayOneShot(lap1);
    }
    public void sound_lap1_stop()
    {
        sfxSource.Stop();
    }
    public void sound_lap2()
    {

        sfxSource.PlayOneShot(lap2);
    }


    public void sound_an1()
    {
        sfxSource.PlayOneShot(an1);
    }
    public void sound_an2()
    {
        sfxSource.PlayOneShot(an2);
    }
    public void sound_an3()
    {
        sfxSource.PlayOneShot(an3);
    }

    public void sound_an4()
    {
        sfxSource.PlayOneShot(an4);
    }
    public void sound_an5()
    {
        sfxSource.PlayOneShot(an5);
    }
    public void sound_an6()
    {
        sfxSource.PlayOneShot(an6);
    }
    public void sound_an7()
    {
        sfxSource.PlayOneShot(an7);
    }
    public void sound_an8()
    {
        sfxSource.PlayOneShot(an8);
    }

}
