using UnityEngine;

public class dash : MonoBehaviour
{
    public Player_controler playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap"))
        {
            playerScript.EndDash();
            playerScript.checkDash = false;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap"))
        {
            playerScript.checkDash = true;

        }
    }
}
