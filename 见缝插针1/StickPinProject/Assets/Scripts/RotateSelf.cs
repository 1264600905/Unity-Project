using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public float speed=180;
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
	}
}
