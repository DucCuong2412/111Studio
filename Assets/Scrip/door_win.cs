using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_win : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel_win;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                panel_win.SetActive(true);

            }
        }
    }
}
