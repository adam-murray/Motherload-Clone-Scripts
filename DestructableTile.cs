using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructableTile : MonoBehaviour
{
    private bool collide;
    private float startTime;

    public float holdTime;
    public Tilemap ground;
    public Vector3Int currentTile;

    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            startTime += Time.deltaTime;
            if (collide && startTime > holdTime)
            {
                ground.SetTile(currentTile, null);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 hitPosition = Vector2.zero;
            Vector3Int cellPosition = ground.WorldToCell(transform.position);

            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.0001f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.0001f * hit.normal.y;
                cellPosition = ground.WorldToCell(hitPosition);
                currentTile = ground.WorldToCell(cellPosition);
                collide = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collide = false;
        startTime = 0f;
    }
}
