using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 1;//坦克移动速度
    private SpriteRenderer playerSprite;
    public Sprite[] tankSprite;//上右下左
    public GameObject Bullet;
    private Vector3 BulletAngles;
    private float bulletCD = 0;
    public GameObject explosionPrefab;
    private float AIMoveDirection=5;
    private float h = 0, v = 0;
    //private float defendTimeVal = 3f;
    //private bool isDefended = true;
    //public GameObject defendPrefab;
    // Use this for initialization
    private void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    private void Update()
    {
        //if (isDefended)
        //{
        //    defendTimeVal -= Time.deltaTime;
        //    defendPrefab.SetActive(true);
        //    if (defendTimeVal < 0)
        //    {
        //        isDefended = false;
        //        defendPrefab.SetActive(false);
        //    }
        //}
        if (bulletCD >= 3f)
        {
            Attack();
        }
        else
        {
            bulletCD += Time.deltaTime;
        }

    }
    public void dead()//坦克的死亡方法
    {
        //if (isDefended)
        //    return;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        PlayerMananger.Instance1.Score++;
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Attack()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{//子弹产生的角度应该是子弹当前的角度加上子弹应该旋转的角度。
            Instantiate(Bullet, transform.position, Quaternion.Euler(transform.eulerAngles + BulletAngles));
            bulletCD = 0f;
        //}
    }
    private void Move()//坦克移动方法
    {
        if (AIMoveDirection > 4)
        {
            int num = Random.Range(0, 6);
            switch (num)
            {
                case 0:
                    h = -1;
                    v = 0;
                    AIMoveDirection = 0;
                    break;
                case 1:
                    h = 1;
                    v = 0;
                    AIMoveDirection = 0;
                    break;
                case 2:
                    h = 0;
                    v = 1;
                    AIMoveDirection = 0;
                    break;
                case 3:
                case 4:            
                    h = 0;
                    v = -1;
                    AIMoveDirection = 0;
                    break;
                default:
                    break;
            }
        }
        else
            AIMoveDirection += Time.deltaTime;
        //float h = Input.GetAxisRaw("Horizontal");
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
        //float v = Input.GetAxisRaw("Vertical");
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            AIMoveDirection = 5;
        }
    }
}

