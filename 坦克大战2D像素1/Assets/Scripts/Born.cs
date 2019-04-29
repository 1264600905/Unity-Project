using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {
    public GameObject PlayerPrefab;
    // Use this for initialization
    public GameObject[] EnemyPrefab;
    public bool CreatPlayer;
	void Start () {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
	}

    // Update is called once per frame
    void Update()
    {

    }
    private void BornTank()
    {
        if(CreatPlayer)
        Instantiate(PlayerPrefab, transform.position, transform.rotation);
        else
        {
            int num = Random.Range(0, 2);
                Instantiate(EnemyPrefab[num], transform.position, transform.rotation);      
        }
    }
}
