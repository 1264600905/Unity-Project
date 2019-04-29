using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float moveSpeed = 10;
    public bool isPlayerBullet;
    public AudioClip Hit;
	void Update () {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
        Destroy(gameObject, 3f);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       switch(collision.tag)
        {
            case "Player":
                if(!isPlayerBullet)
                {
                    collision.SendMessage("dead");
                }
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(Hit, transform.position);
                break;
            case "Barriar":
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(Hit, transform.position);
                break;
            case "Enemy":
                if(isPlayerBullet)
                {
                    collision.SendMessage("dead");
                    Destroy(gameObject);
                }
                break;
            case "Heart":
                collision.SendMessage("die");
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

}
