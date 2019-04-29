using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    private SpriteRenderer sr;
    public Sprite brokenHeart;
    public GameObject ExplosionPrefab;
    private bool Isdie=false;
    public AudioClip HeartBorken;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
    private void die() {
        sr.sprite = brokenHeart;
        AudioSource.PlayClipAtPoint(HeartBorken, transform.position);
        if (!Isdie)
        {
            Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            Isdie = true;
            PlayerMananger.Instance1.GameOver = true;
        }
    }
}
