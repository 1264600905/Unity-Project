using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour {
    public GameObject Pin;
    private Transform startPos;
    private Transform spawnPos;
    private Pin FlyPin;
    private bool Gameover;
    private int Score = 0;
    public Text ScoreText;
    public GameObject GameOver_Text;
    private Camera Main;
    public float speed=20;
	// Use this for initialization
	void Start () {
		startPos=GameObject.Find("StartPosition").transform;
        spawnPos = GameObject.Find("SpawnPosition").transform;
        Main = Camera.main;
        SpawnPin();
    }
	void SpawnPin()
    {
        FlyPin = GameObject.Instantiate(Pin, spawnPos.position, Pin.transform.rotation).GetComponent<Pin>();
    }
	// Update is called once per frame
	void Update () {
        if (Gameover) {
            GameOver_Text.active = enabled;
            return;
        }
	if(Input.GetKeyDown(KeyCode.Space))
        {
            Score++;
            ScoreText.text = Score.ToString();
            FlyPin.StartFly();
            SpawnPin();
        }
	}
    public void GameOver()
    {
        if (Gameover) return;
        Gameover = true;
        StartCoroutine(GameOver_Camera());
    }
    IEnumerator GameOver_Camera()
    {
        while (true)
        {
            Main.backgroundColor = Color.Lerp(Main.backgroundColor, Color.red, speed * Time.deltaTime);
            Main.orthographicSize = Mathf.Lerp(Main.orthographicSize, 3.5f, speed * Time.deltaTime);
            if (Mathf.Abs((Main.orthographicSize - 4)) < 0.01f)
                break;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
