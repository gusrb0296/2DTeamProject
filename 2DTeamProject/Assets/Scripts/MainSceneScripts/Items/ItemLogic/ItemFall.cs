using UnityEngine;

public class ItemFall : MonoBehaviour
{
    GameObject item;
    Rigidbody2D rigid;

    private void Awake()
    {
        item = GetComponent<GameObject>();
        rigid = transform.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigid.AddForce(transform.up * -1, ForceMode2D.Impulse);
    }
}
