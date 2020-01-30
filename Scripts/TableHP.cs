using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHP : MonoBehaviour
{
    public int hP = 3;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public int scoreValue;
    private PlayerController gameController;

    private SpriteRenderer sP;
    


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("Player");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<PlayerController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        sP = GetComponent<SpriteRenderer>();
        sP.sprite = s1;
    }

    public void TakeDamage(int damage)
    {
        hP = hP - damage;
        if (hP == 2)
        {
            Debug.Log("Hit");

            sP.sprite = s2;
            
        }
        if (hP == 1)
        {
            Debug.Log("Hit");

            sP.sprite = s3;

        }
        if (hP == 0)
        {
            Debug.Log("Hit");
            gameController.AddScore(scoreValue);
            Die();
            

        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
