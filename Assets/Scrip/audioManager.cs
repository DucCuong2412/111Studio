using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{




    public float volume;
    public float save_volume;
    public AudioMixer mixer;
    public Slider Slider;
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
        DontDestroyOnLoad(gameObject);
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



}
