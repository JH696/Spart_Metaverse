using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCamera : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        if (target == null)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;
        transform.position = targetPosition;
    }
}
