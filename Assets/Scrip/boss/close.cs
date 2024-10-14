using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    public GameObject panel_boss_die;

   public void close_bossDie()
    {
        panel_boss_die.SetActive(false);

    }
}
