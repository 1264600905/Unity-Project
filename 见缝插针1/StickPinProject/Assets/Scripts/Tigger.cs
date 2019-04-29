using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tigger : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tigger")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManger>().GameOver();
        }
    }
}
