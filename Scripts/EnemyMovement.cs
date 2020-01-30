using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public class BoundaryE
//{
//    public float xMin, xMax, yMin, yMax;
//}

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private int n;
    public float time;
    private PlayerController gameController;
    public int scoreValue;
    public GameObject Table;
    public Sprite e1;
    public Sprite e2;
    private SpriteRenderer sP;
    private bool en;

    void Start()
    {
        en = false;
        n = 1;
        
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        sP = GetComponent<SpriteRenderer>();
        sP.sprite = e1;
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("Player");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<PlayerController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Table")
        {   
            StartCoroutine(ExampleCoroutine());
            
        }
        if (collision.collider.tag == "Wall")
        {
            StartCoroutine(ExampleCoroutine());
            
        }
        if (collision.collider.tag == "Enemy")
        {
            en = true;
            StartCoroutine(ExampleCoroutine());
            en = false;
        }

    }

    public void TakeDamage (int damage)
    {
        if(damage == 1)
        {
            gameController.AddScore(scoreValue);
            Debug.Log("Hit");
            Die();
            
            
        }
            
    }

    

    void Die ()
    {
        Instantiate(Table, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator ExampleCoroutine()
    {
        while(true)
        {
            if (n == 1)
            {

                sP.sprite = e2;
                if (en == false)
                {
                    GetComponent<Rigidbody2D>().velocity = transform.up * speed * -3;

                    yield return new WaitForSeconds(time);
                }

                GetComponent<Rigidbody2D>().velocity = transform.right * speed * -1;

                yield return new WaitForSeconds(time);
                
                n = -1;
                break;
            }
            if (n == -1)
            {
                sP.sprite = e1;
                if (en == false)
                {
                    GetComponent<Rigidbody2D>().velocity = transform.up * speed * -3;

                    yield return new WaitForSeconds(time);
                }
                
                GetComponent<Rigidbody2D>().velocity = transform.right * speed * 1;

                yield return new WaitForSeconds(time);
                n = 1;
                break;

            }
        }                
    }
}

    

