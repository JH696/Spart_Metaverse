using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGamePlayer : MonoBehaviour
{
    public static MiniGamePlayer Instance;

    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    bool isFlap = false;
    public bool godMode = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isFlap = true;
        }
    }
    private void FixedUpdate()
    {

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundRock")
        || (collision.CompareTag("Obstacle")))
        {
            if (godMode) return;
            if (isDead) return;

            GameManager.instance.ReduceLife();
            StartCoroutine(GodTime(0.4f));
            animator.SetInteger("IsHit", 1);
            Invoke("ResetHit", 0.4f);
        }
        else if (collision.CompareTag("Potion"))
        {
            if (isDead) return;

            GameManager.instance.IncreaseLife();
        }
    }

    void ResetHit()
    {
        animator.SetInteger("IsHit", 0);
    }
    IEnumerator GodTime(float duration)
    {
        godMode = true;

        yield return new WaitForSeconds(duration);

        godMode = false;
    }
}
