using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    // 플레이어가 공격버튼을 눌러 이벤트가 발돌되면 _controller에서 값( ) 을 받아옴
    // 플레이어의 transform(위치)를 기준으로 위쪽 방향으로 force만큼의 힘을 주며 Bullet Prefab을 찍어냄

    // 총알의 스크립트는 따로 작성 (총알 스크립트에서 충돌 처리)

    TopDownCharacterController _controller;

    Rigidbody2D bulletRigid;

    GameObject bullet; // ( bullet는 player가 발사하는 총알 Prefab )

    [SerializeField] int force = 5; // ( bullet에 가할 스피드 )
    [SerializeField] private float coolTime = 1.0f;

    private bool coolTimeCheck = true;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    private void Start()
    {
        _controller.OnAttackEvent += Attack;
    }

    private void Attack()
    {
        // CoolTime Check
        if (coolTimeCheck == true) StartCoroutine(CollTime(coolTime));
    }

    private void RecallBullet()
    {
        GameObject playerBullet = Instantiate(bullet);
        playerBullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerBullet);
    }

    private void ApplyAttck(GameObject obj)
    {
        bulletRigid = obj.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(transform.up * this.force, ForceMode2D.Impulse);
    }

    private IEnumerator CollTime(float time)
    {
        // CoolTime Setting
        coolTimeCheck = false;

        RecallBullet();

        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        // CoolTime Reset
        coolTimeCheck = true;
    }
}
