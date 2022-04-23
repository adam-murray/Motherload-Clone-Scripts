using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float boost;
    public FuelBar fuel;
    private bool onGround;
    private Rigidbody2D body;
    private float boostLimit;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        boostLimit = boost;
        fuel.SetMaxBoost(boostLimit);
    }

    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        fuel.SetBoost(boost);

        // If player is pressing space, and boost is not disabled
        if (Input.GetKey(KeyCode.Space) && boost > 0)
        {
            // Increase the time we have been boosting for
            boost -= Time.deltaTime;
            // Boost us up!
            body.velocity = new Vector2(body.velocity.x, speed);
        }
        if (onGround && boost <= boostLimit)
        {
            // Regain boost while on the ground
            boost += Time.deltaTime;
        }

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
