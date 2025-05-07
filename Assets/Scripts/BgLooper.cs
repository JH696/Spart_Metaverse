using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackGround")
        ||(collision.CompareTag("GroundRock")))
        {
            float widtnOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widtnOfBgObject * numBgCount;
            collision.transform.position = pos;
        }
        else if (collision.CompareTag("Obstacle") || collision.CompareTag("Potion"))
        {
            Destroy(collision.gameObject);
        }
    }
}
