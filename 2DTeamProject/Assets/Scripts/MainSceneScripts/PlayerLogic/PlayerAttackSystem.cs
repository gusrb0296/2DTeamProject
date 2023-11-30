using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    // �÷��̾ ���ݹ�ư�� ���� �̺�Ʈ�� �ߵ��Ǹ� _controller���� ��( ) �� �޾ƿ�
    // �÷��̾��� transform(��ġ)�� �������� ���� �������� force��ŭ�� ���� �ָ� Bullet Prefab�� ��

    // �Ѿ��� ��ũ��Ʈ�� ���� �ۼ� (�Ѿ� ��ũ��Ʈ���� �浹 ó��)

    TopDownCharacterController _controller;

    Rigidbody2D bulletRigid;

    GameObject bullet; // ( bullet�� player�� �߻��ϴ� �Ѿ� Prefab )

    [SerializeField] int force = 5; // ( bullet�� ���� ���ǵ� )
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
