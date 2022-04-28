using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Guages : MonoBehaviour
{
    private Vector2 playerPosition;
    public Text depthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        setDepth(playerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        setDepth(playerPosition);
    }

    private void setDepth(Vector2 playerPosition)
    {
        depthDisplay.text =  playerPosition.y.ToString("0");
    }
}
