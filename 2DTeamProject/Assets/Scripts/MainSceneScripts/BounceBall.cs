using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    [SerializeField] private int _ballHp;
    [SerializeField] private int _ballDamage;
    [SerializeField] private float speed = 300;

    private Hearts _heart;
    private Animator _anim;
    private SpriteRenderer _sprite;

    private Rigidbody2D _rigidbody;

    Rigidbody2D SmallBallRigid;

    public List<GameObject> BallList;
    public List<GameObject> RewardItemList;
    public List<Sprite> SpriteList;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _heart = GameObject.Find("Player").GetComponent<Hearts>();
        _anim = GameObject.Find("Player").GetComponent<Animator>();

        _sprite = GetComponent<SpriteRenderer>();
        int RanSpriteNum = Random.Range(0, 3);
        _sprite.sprite = SpriteList[RanSpriteNum];
    }

    private void Start()
    {
        if (_ballHp == 3)
        {
            RandomLaunch(this.gameObject);
            RandomSpawn(this.gameObject);
        }
    }

    // 왼쪽, 오른쪽 랜덤한 값을 받아 해당 방향으로 Speed만큼 곱한 속도로 이동
    private void RandomLaunch(GameObject obj)
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 dir = new Vector2(x, 0);
        _rigidbody.AddForce(dir * speed);
    }


    // 매개변수 방향대로 공이 이동
    private void DirtionLaunch(GameObject obj, Vector2 direction)
    {
        SmallBallRigid = obj.GetComponent<Rigidbody2D>();
        SmallBallRigid.AddForce(direction * speed);
    }

    // x: -8 ~ 8 /  y: 2 ~ 3 사이 위치로 랜덤하게 변경
    public void RandomSpawn(GameObject obj)
    {
        Vector2 RandomPos = new Vector2(Random.Range(-8, 8), Random.Range(2, 3));
        this.transform.position = RandomPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.instance.PlaySFX("ExplodedBall");
            BallHitted();

            // 공 파괴 될 때 아이템 생성
            int RandomPercent = Random.Range(0, 5);
            if (RandomPercent == 1)
            {
                int RandomIndex = Random.Range(0, 5);
                Instantiate(RewardItemList[RandomIndex], this.transform.position, Quaternion.identity);
            }
            GameManager.instance._uiManager.scoreText += Random.Range(150, 200);

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {

            _heart.DecreaseHealth(_ballDamage); // 체력 감소
            if (_heart.playerHealth <= 0)
                _anim.SetTrigger("Death");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            BallHitted();
            Destroy(gameObject);
        }
    }

    private void BallHitted()
    {
        if (_ballHp == 3)
            Split(1);
        else if (_ballHp == 2)
            Split(2);
        else
            Destroy(gameObject);
    }

    private void Split(int index)
    {
        GameObject ball1 = Instantiate(BallList[index], new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z), Quaternion.identity);
        GameObject ball2 = Instantiate(BallList[index], new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), Quaternion.identity);
        DirtionLaunch(ball1, Vector2.left);
        DirtionLaunch(ball2, Vector2.right);
    }
}
