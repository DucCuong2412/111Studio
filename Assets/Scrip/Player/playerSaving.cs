using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.iOS;

public class playerSaving : MonoBehaviour
{
    public static playerSaving Instance;
    public string key_score = "score_save";
    public int level = 0;
    public int score;
    public string key_score_format = "score_save";

    void Start()
    {
    }

    // Update is called once per frame
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.J))
        {
            save(level, score);

        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            load(level);

       

        }

    }
    //public void save()
    //{

    //    score++;
    //    PlayerPrefs.SetInt(key_score, score);
    //    PlayerPrefs.Save();



    //}
    //public void load()
    //{
    //    int s = PlayerPrefs.GetInt(key_score);
    //    Debug.Log("load: score=" + s);
    //}
    public void save(int level, int score)
    {
        Debug.Log("save level" + level + "" + score);
        PlayerPrefs.SetInt(level.ToString(), score);
        PlayerPrefs.Save();

    }
    public void load(int level)
    {
        int scoreLoad = PlayerPrefs.GetInt(level.ToString());
        Debug.Log("load level Score " + level +" " + scoreLoad);


    }

}
