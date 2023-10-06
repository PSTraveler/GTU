using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    // 몬스터 공격
    public int damage = 2;
    public Transform pos;
    public BoxCollider2D box;

    public float cooltime;
    private float currenttime;

    // 몬스터 피격
    public int hp = 3;

    // 몬스터 이동
    public float speed;
    bool isLeft = false;

    // 총알
    public GameObject bullet;
    public Transform bulletpos;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 몬스터 이동
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // 몬스터 피격
        if (hp <= 0)
        {
            SpawnManager._instance.enemyCount--;
            SpawnManager._instance.isSpawn[int.Parse(transform.parent.name) - 1] = false;
            Destroy(this.gameObject);
        }
        // 공격 모션
        Collider2D[] collider = Physics2D.OverlapBoxAll(pos.position, new Vector2(2f, 1f), 1);
        if (collider != null)
        {
            for (int i = 0; i < collider.Length; i++)
            {
                if (currenttime <= 0)
                {
                    if (collider[i].CompareTag("Player"))
                    {
                        animator.SetBool("isAtk", true);
                        Instantiate(bullet, bulletpos.position, transform.rotation);
                    }
                    else
                    {
                        animator.SetBool("isAtk", false);
                    }
                    currenttime = cooltime;
                }
            }
        }
        currenttime -= Time.deltaTime;
    }
    public void Enbox()
    {
        box.enabled = true;
    }
    public void Debox()
    {
        box.enabled = false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(pos.position, new Vector3(10f, 1f, 1f));
    }

    // 몬스터 이동
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPoint"))
        {
            if (!isLeft)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isLeft = true;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isLeft = false;
            }
        }
    }

    // 몬스터 피격
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
