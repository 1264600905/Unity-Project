using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour {
    private int choice = 0;
    public Transform[] pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
        {
            choice = 0;
            transform.position = pos[0].position;
        }else if(Input.GetKeyDown(KeyCode.S))
        {
            choice = 1;
            transform.position = pos[1].position;
        }
        if(choice==0&&Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
	}
}
