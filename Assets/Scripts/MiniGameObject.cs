using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameObject : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (gameObject.name.Contains("Axe"))
        {
            this.transform.Rotate(0, 0, 300 * Time.deltaTime);
            this.transform.position += Vector3.left * 1f * Time.deltaTime;
        }
        else if (gameObject.name.Contains("Knife"))
        {
            this.transform.Rotate(0, 0, 500 * Time.deltaTime);
            this.transform.position += Vector3.left * 5f * Time.deltaTime;
        }
        else if (gameObject.name.Contains("Spear"))
        {
            this.transform.position += Vector3.left * 7.5f * Time.deltaTime;
        }
        else if (gameObject.name.Contains("Arrow"))
        {
            this.transform.position += Vector3.left * 10f * Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (MiniGamePlayer.Instance.godMode) return;

            Destroy(this.gameObject);
        }
    }
}

