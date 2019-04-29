using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMananger : MonoBehaviour {
    public int lifeVal = 3;
    public int Score = 0;
    public bool isDead;
    public GameObject Born;
    private static PlayerMananger Instance;
    public bool GameOver = false;
    public Text PlayerScore;
    public Text PlayerLife;
    public GameObject GameOver_UI;
    public static PlayerMananger Instance1
    {
        get
        {
            return Instance;
        }

        set
        {
            Instance = value;
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    private void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    void Update () {
        if(GameOver)
        {
            GameOver_UI.SetActive(true);
            Invoke("returnToMenu", 5);
            return;
        }
        else GameOver_UI.SetActive(false);
        if (isDead)
        {
            Invoke("Reccover", 3);
            isDead = false;
        }
        PlayerLife.text = lifeVal.ToString();
        PlayerScore.text = Score.ToString();
	}
    private void Reccover()
    {
        GameObject player;
        if(lifeVal<=0)
        {
            //GameOver
            GameOver = true;
        }
        else
        {
            player = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            player.GetComponent<Born>().CreatPlayer = true;
            lifeVal--;
            if(lifeVal>0)
            {
                isDead = false;
            }
        }
    }
}
