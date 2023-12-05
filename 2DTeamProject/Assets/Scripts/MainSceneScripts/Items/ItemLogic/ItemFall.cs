using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ItemFall : MonoBehaviour
{
    GameObject item;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    float timer = 1;
    bool filckerCheck = true;

    private void Awake()
    {
        item = GetComponent<GameObject>();
        rigid = transform.GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        rigid.AddForce(transform.up * -1, ForceMode2D.Impulse);
    }

    
    private void FixedUpdate()
    {
        if (transform.position.y <= -4.3f)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            timer -= Time.deltaTime;

            if (timer <= 0 && filckerCheck == true)
            {
                timer = 0;
                StartCoroutine(Filcker());
                filckerCheck = false;
            }
        }
    }
    

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            StartCoroutine(Filcker());
            rigid.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeAll;
        }
    }
    */

    private IEnumerator Filcker()
    {
        float Counter = 0;

        while ( Counter < 10)
        {
            float alpCol = 0;
            while (alpCol <  1.0f)
            {
                alpCol += 0.1f;
                yield return new WaitForSeconds(0.01f);
                spriteRenderer.color = new Color(1, 1, 1, alpCol);
            }
            while (alpCol > 0f)
            {
                alpCol -= 0.1f;
                yield return new WaitForSeconds(0.01f);
                spriteRenderer.color = new Color(1, 1, 1, alpCol);
            }
            Counter++;
        }

    }
}
