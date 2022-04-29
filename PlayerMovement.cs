using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float boost;
    public BoostBar boostBar;
    public Vector2 rotationStart;
    private bool onGround;
    private Rigidbody2D body;
    private float boostLimit;
    private float horizontalMovement;
    private float verticalMovement;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        boostLimit = boost;
        boostBar.SetMaxBoost(boostLimit);
    }

    void Update()
    {
        Vector2 velocity = body.velocity;
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
        //bool beginRotation = velocity.x > rotationStart.x || velocity.y > rotationStart.y;
        /*
        if (beginRotation)
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        */

        // If player is pressing space, and boost is not disabled
        if (Input.GetKey(KeyCode.Space) && boost > 0)
        {
            // Increase the time we have been boosting for
            boost -= Time.deltaTime;
            // Boost us up!
            body.velocity = new Vector2(body.velocity.x, body.velocity.x + speed);
            boostBar.SetBoost(boost);
        }
        if (onGround && boost <= boostLimit)
        {
            // Regain boost while on the ground
            boost += Time.deltaTime;
        }
        body.velocity = new Vector2(horizontalMovement * speed, body.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }


}
