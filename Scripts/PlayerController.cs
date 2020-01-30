using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int points;
    public Boundary boundary;
    public Text scoreText;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public int health = 3;
    public float iFrames;
    private int hp = 3;
    public GameObject[] enemies;
    private float nextFire;
    public Sprite p1;
    public Sprite p2;
    private SpriteRenderer sR;
    public bool is1;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        sR = GetComponent<SpriteRenderer>();
        sR.sprite = p1;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        UpdateScore();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //  if (Input.GetButton("escape"))
        //    {
        //          Application.Quit();
        //        }
        if (enemies.Length == 0)
        {
            Debug.Log("They dead");
            if(is1==true)
            {
                SceneManager.LoadScene("Game2");
            }
            if (is1 == false)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        GetComponent<Rigidbody2D>().velocity = movement * speed;

        GetComponent<Rigidbody2D>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyMovement enemy = hitInfo.GetComponent<EnemyMovement>();
        TableHP table = hitInfo.GetComponent<TableHP>();
        if (enemy != null)
        {
            Debug.Log("Party Boi");
            hp = hp - 1;
            if (hp == 0)
            {
                health = health - 1;
            }
            StartCoroutine(ExampleCoroutine());
        }
        if (table != null)
        {
            Debug.Log("Table");
            hp = hp - 1;
            if (hp == 0)
            {
                health = health - 1;
            }
            StartCoroutine(ExampleCoroutine());
        }
        Moving1 spider = hitInfo.GetComponent<Moving1>();
        if (spider != null)
        {
            Debug.Log("Pinata");
            hp = hp - 1;
            if (hp == 0)
            {
                health = health - 1;
            }
            StartCoroutine(ExampleCoroutine());

        }
        if (health <= 0)
        {

            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + points + "\n" + "HP: " + hp;
    }

    public void AddScore(int newScoreValue)
    {
        points += newScoreValue;
        UpdateScore();
    }

    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            sR.sprite = p2;
            yield return new WaitForSecondsRealtime(iFrames);
            sR.sprite = p1;
            yield return new WaitForSecondsRealtime(iFrames);
            sR.sprite = p2;
            yield return new WaitForSecondsRealtime(iFrames);
            sR.sprite = p1;
            yield return new WaitForSecondsRealtime(iFrames);
            sR.sprite = p2;
            yield return new WaitForSecondsRealtime(iFrames);
            sR.sprite = p1;
            yield return new WaitForSecondsRealtime(iFrames);
            sR.sprite = p2;
            yield return new WaitForSecondsRealtime(iFrames);
            sR.sprite = p1;
            health = health - 1;
            break;
        }
    }
}
