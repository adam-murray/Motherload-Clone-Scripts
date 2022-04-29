using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class DestructableTile : MonoBehaviour
{
    private bool collide;
    private float startTime;
    private Dictionary<TileBase, TileData> dataFromTiles;

    public float holdTime;
    public float score;
    public List<TileData> tileDatas;
    public Tilemap ground;
    public Vector3Int currentTile;
    public Text scoreDisplay;

    // Start is called before the first frame update
    private void Start()
    {
        ground = GetComponent<Tilemap>();
        startTime = 0f;
        score = 0f;
    }

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tileData in tileDatas)
        {
            foreach(var tile in tileData.tiles)
                {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            startTime += Time.deltaTime;
            if (collide && startTime > holdTime)
            {
                startTime = 0f;
                // This is a hack until raycasts can be implemented, for now, tile may not be findable
                try
                {
                    // This should be replacing a the money value on the player, the UI should be doing this.
                    score += dataFromTiles[ground.GetTile(currentTile)].value;
                }
                catch (System.ArgumentNullException)
                {
                    score += 1;
                }
                scoreDisplay.text = score.ToString("0");
                ground.SetTile(currentTile, null);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTime = 0f;
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
                currentTile = ground.WorldToCell(hitPosition);
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
