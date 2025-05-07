using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoc : MonoBehaviour
{
    public static PlayerRoc instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY"))
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            player.transform.position = new Vector2(x, y);
            PlayerPrefs.DeleteKey("PlayerX");
            PlayerPrefs.DeleteKey("PlayerY");
        }

    }
    public void SavePlayerPosition()
    {
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        }
    }
}
