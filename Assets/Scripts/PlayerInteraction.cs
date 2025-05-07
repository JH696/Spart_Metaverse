using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject miniGameArea;
    public GameObject pressF;

    public GameObject chest_100;
    public GameObject chest_200;
    public GameObject sword;
    public GameObject wand;

    private bool inMiniGameRange = false;
    private bool inSwordRange = false;
    private bool inWandRange = false;

    void Update()
    {
        if (inMiniGameRange && Input.GetKeyDown(KeyCode.F))
        {
            PlayerRoc.instance.SavePlayerPosition();
            SceneManager.LoadScene("MiniGame");
            Time.timeScale = 0f;
        }

        if (inSwordRange && Input.GetKeyDown(KeyCode.F))
        {
            float best = PlayerPrefs.GetFloat("bestScore");

            if (best >= 100)
            {
                wand.SetActive(false);
                sword.SetActive(true);
            }
        }
        else if (inWandRange && Input.GetKeyDown(KeyCode.F))
        {
            float best = PlayerPrefs.GetFloat("bestScore");

            if (best >= 200)
            {
                sword.SetActive(false);
                wand.SetActive(true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (pressF != null)
        {
            if (collision.gameObject == miniGameArea)
            {
                inMiniGameRange = true;
                pressF.SetActive(true);
            }
            else if (collision.gameObject == chest_100)
            {
                inSwordRange = true;
                pressF.SetActive(true);
            }
            else if (collision.gameObject == chest_200)
            {
                inWandRange = true;
                pressF.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (pressF != null)
        {
            if (collision.gameObject == miniGameArea)
            {
                inMiniGameRange = false;
                pressF.SetActive(false);
            }
            else if (collision.gameObject == chest_100)
            {
                inSwordRange = false;
                pressF.SetActive(false);
            }
            else if (collision.gameObject == chest_200)
            {
                inWandRange = false;
                pressF.SetActive(false);
            }
        }
    }
}



