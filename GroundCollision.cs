using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundCollision : MonoBehaviour
{
    public Tilemap ground;
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.bounds.center);
        if (collider.tag == "Player")
        {
            Vector3Int cellPosition = Vector3Int.FloorToInt(collider.bounds.center);
            Vector2 tilePosition = ground.GetCellCenterWorld(cellPosition);
            Debug.Log(tilePosition);
            ground.SetTile(ground.WorldToCell(tilePosition), null);
            Debug.Log(ground.GetTile(ground.WorldToCell(tilePosition)));
        }
    }
}
