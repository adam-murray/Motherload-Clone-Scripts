using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float boostLimit;
    public float speed;
    public float boostCooldown;
    public FuelBar fuel;
    private bool boostDisabled;
    private bool onGround;
    private float boostTimer;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        fuel.SetMaxBoost(boostLimit);
    }

    void Start()
    {
        boostTimer = 0f;
    }

    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        fuel.SetBoost(boostLimit - boostTimer);

        // If player is pressing space, and boost is not disabled
        if (Input.GetKey(KeyCode.Space) && boostDisabled == false)
        {
            // Increase the time we have been boosting for
            boostTimer += Time.deltaTime;
            // Boost us up!
            body.velocity = new Vector2(body.velocity.x, speed);
        }
        // If we have been boosting for equal to or more than the boost limit
        if (boostTimer >= boostLimit)
        {
            // Disable boost
            boostDisabled = true;
            // Decrese current cooldown
            boostCooldown -= Time.deltaTime;
        }
        if (onGround)
        {
            if (boostCooldown < boostLimit)
            {
                // Regain boost while on the ground
                boostCooldown += Time.deltaTime;
            }
        }
        if (boostCooldown <= 0)
        {
            // re-enable boost
            boostDisabled = false;
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
