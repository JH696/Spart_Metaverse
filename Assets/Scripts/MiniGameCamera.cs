using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;

    void Start()
    {
        if (target == null)
        {
            return;
        }

        offsetX = transform.position.x - target.position.x;
    }
    void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 position = transform.position;
        position.x = target.position.x + offsetX;
        transform.position = position;
    }
}
