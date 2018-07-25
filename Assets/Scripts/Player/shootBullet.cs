using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shootBullet : MonoBehaviour {

    public float bulletVelocity;
    public GameObject bullet;
    public GameObject bullet1;
    public int ammo;
    public Text ammoText;
    public string currentScene;
    public bool unshootable;
    public GameObject PauseManager;
    public Color red;
    public Color lightRed;
    public Color white;

    public float winTimer;
    public float winTime;

    public float colorTimer;
    public float colorTime;

    public Animator ammoTextAnim;
    public bool ammoDeplete;

    // Use this for initialization
    void Start () {
        winTime = winTimer;
        colorTime = colorTimer;
	}
	
	// Update is called once per frame
	void Update () {
        ammoText.text = ammo.ToString();
        ammoTextAnim.SetBool("AmmoDeplete", ammoDeplete);
        if (Input.GetMouseButtonDown(0) && ammo >= 1 && unshootable == false)
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();

            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate(
                                    bullet1,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);

            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;

            ammo = ammo - 1;
        }

        if(winTime <= 0)
        {
            PauseManager.GetComponent<PauseManager>().WinGame();
        }

        if(ammoDeplete == true)
        {
            ammoDeplete = false;
        }
        if(GetComponent<SpriteRenderer>().color == lightRed)
        {
            colorTime--;
        }
        if(colorTime <= 0)
        {
            GetComponent<SpriteRenderer>().color = white;
            colorTime = colorTimer;
        }
        if(ammo == 0)
        {
            StartCoroutine(GameOverWithoutAmmo());
        }
    }

    IEnumerator GameOverWithoutAmmo()
    {
        yield return new WaitForSeconds(2);
        PauseManager.GetComponent<PauseManager>().GameOver();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillZone")
        {
            gameObject.GetComponent<SpriteRenderer>().color = red;
            PauseManager.GetComponent<PauseManager>().GameOver();
        }
        if(collision.tag == "EnemyExplosion")
        {
            ammo = ammo - 1;
            GetComponent<SpriteRenderer>().color = lightRed;
            ammoDeplete = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            winTime--;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            winTime = winTimer;
        }
    }
}
