using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    public float speed=12;
    private Transform startPos;
    private bool isFly = false;
    private bool isReach = false;
    private Transform spawnPos;
    private Transform Tagget;
    private Vector3 temp;
    // Use this for initialization
    void Start () {
        startPos = GameObject.Find("StartPosition").transform;
        spawnPos = GameObject.Find("SpawnPosition").transform;
        Tagget = GameObject.Find("Circle").transform;
        temp = Tagget.position;
        temp.y -= -0.29f;
        temp = Tagget.position - temp;
       
    }
	
	// Update is called once per frame
	void Update () {
		if(isFly==false)
        {
            if (isReach==false)
            {
                transform.position=Vector3.MoveTowards(transform.position, startPos.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, startPos.position) < 0.05f)
                    isReach = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,temp, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position,temp) < 0.05f)
            {
                transform.position = temp;
                transform.parent = Tagget;
                isFly = false;
            }
            }
                
	}
    public void StartFly()
    {
        isFly = true;
        isReach = true;
    }
}
