using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public int damage = 1;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        EnemyMovement enemy = hitInfo.GetComponent<EnemyMovement>();
        TableHP table = hitInfo.GetComponent<TableHP>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (table != null)
        {
            table.TakeDamage(damage);
        }
        Moving1 spider = hitInfo.GetComponent<Moving1>();
        if (spider != null)
        {
            spider.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
