using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;//坦克移动速度
    private SpriteRenderer playerSprite;
    public Sprite[] tankSprite;//上右下左
    public GameObject Bullet;
    private Vector3 BulletAngles;
    private float bulletCD=0;
    public GameObject explosionPrefab;
    private float defendTimeVal=3f;
    private bool isDefended=true;
    public GameObject defendPrefab;
    public AudioClip[] IdleAndMove; //0是idle，1是Move
    private AudioSource PlayerAud;
    // Use this for initialization
    private void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        PlayerAud = GetComponent<AudioSource>();
    }
    public void dead()//坦克的死亡方法
    {
        if (isDefended)
            return;
        Instantiate(explosionPrefab, transform.position,transform.rotation);
        Destroy(gameObject);
        PlayerMananger.Instance1.isDead = true;
    }
    void FixedUpdate()
    {
        if (PlayerMananger.Instance1.GameOver == true)
            return;
        Move();
        if (isDefended)
        {
            defendTimeVal -= Time.deltaTime;
            defendPrefab.SetActive(true);
            if (defendTimeVal < 0)
            {
                isDefended = false;
                defendPrefab.SetActive(false);
            }
        }
        if (bulletCD >= 0.7f)
        {
            Attack();
        }
        else
        {
            bulletCD += Time.deltaTime;
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {//子弹产生的角度应该是子弹当前的角度加上子弹应该旋转的角度。
            Instantiate(Bullet, transform.position, Quaternion.Euler(transform.eulerAngles + BulletAngles));
            bulletCD = 0f;
        }
    }
    private void Move()//坦克移动方法
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            playerSprite.sprite = tankSprite[3];
            BulletAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            playerSprite.sprite = tankSprite[1];
            BulletAngles = new Vector3(0, 0, -90);
        }
        if (Mathf.Abs(h) > 0.05)
        {
            PlayerAud.clip = IdleAndMove[1];
            if (!PlayerAud.isPlaying)
            {
                PlayerAud.Play();
            }
        }
            if (h != 0)
                return;
            float v = Input.GetAxisRaw("Vertical");
            transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime, Space.World);
        //这里如果把移动的transform代码写在return前面
        //，上一次执行的代码V的值依旧存在所以还是会使坦克在竖直轴上移动；        
        if (v < 0)
            {
                playerSprite.sprite = tankSprite[2];
                BulletAngles = new Vector3(0, 0, -180);
            }
            else if (v > 0)
            {
                playerSprite.sprite = tankSprite[0];
                BulletAngles = new Vector3(0, 0, 0);
            }
        if (Mathf.Abs(v) > 0.05)
        {
            PlayerAud.clip = IdleAndMove[1];
            if (!PlayerAud.isPlaying)
            {
                PlayerAud.Play();
            }
        }
        else
        {
            PlayerAud.clip = IdleAndMove[0];
            if (!PlayerAud.isPlaying)
            {
                PlayerAud.Play();
            }
        }
    }
    }


