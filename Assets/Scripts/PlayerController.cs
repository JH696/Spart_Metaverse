using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : BassController
{
    private Camera camera;

    private Vector2? targetPosition = null;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPosition = camera.ScreenToWorldPoint(mousePosition);
            targetPosition = worldPosition;
        }

        if (targetPosition != null)
        {
            Vector2 direction = ((Vector2)targetPosition - (Vector2)transform.position);

            if (direction.magnitude > 0.1f)
            {
                movementDirection = direction.normalized;
            }
            else
            {
                movementDirection = Vector2.zero;
                targetPosition = null;
            }
        }

        Vector2 mouseDirection = camera.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = (mouseDirection - (Vector2)transform.position);

    }


}
