using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage = 30;

    public float distance;
    public LayerMask isLayer;

    void Start()
    {
        Invoke(nameof(DestroyBullet), 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Player"))
            {
                Debug.Log("맞춤 ㅋ");
            }
            //DestroyBullet();
        }
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }

    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
