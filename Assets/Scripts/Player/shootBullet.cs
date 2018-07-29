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
        //Set the ammo text equal to the ammo variable
        ammoText.text = ammo.ToString();
        //Set the parameter in the ammotext animation to the ammoDeplete variable to use when the ammo depletion animation needs to play
        ammoTextAnim.SetBool("AmmoDeplete", ammoDeplete);
        //If you click the mouse button, ammo is greater than 0 and you are able to shoot...
        if (Input.GetMouseButtonDown(0) && ammo >= 1 && unshootable == false)
        {
            //Find mouse position relative to camera
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Find the direction of the mouse relative to the player
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();

            // Creates the bullet locally
            GameObject bullet = (GameObject)Instantiate(
                                    bullet1,
                                    transform.position + (Vector3)(direction * 0.5f),
                                    Quaternion.identity);

            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
            //Deplete ammo by 1
            ammo = ammo - 1;
        }

        //If you are in the finish zone for winTime...
        if(winTime <= 0)
        {
            //Call the winGame function
            PauseManager.GetComponent<PauseManager>().WinGame();
        }
        //If ammo needs to be depleted...
        if(ammoDeplete == true)
        {
            //Deplete 1, then sets variable to false
            ammoDeplete = false;
        }
        //If color is lightRed, indicating damage
        if(GetComponent<SpriteRenderer>().color == lightRed)
        {
            //Start color timer to turn color back to white
            colorTime--;
        }
        //After color timer is up...
        if(colorTime <= 0)
        {
            //Change color back to original color
            GetComponent<SpriteRenderer>().color = white;
            //Change color timer back to original value
            colorTime = colorTimer;
        }
        //If ammo is 0...
        if(ammo == 0)
        {
            //Start function 'GameOverWithoutAmmo'
            StartCoroutine(GameOverWithoutAmmo());
        }
    }

    IEnumerator GameOverWithoutAmmo()
    {
        //Wait for 2 Seconds
        yield return new WaitForSeconds(2);
        //Call GameOver function in the GameObject 'PauseManager'
        PauseManager.GetComponent<PauseManager>().GameOver();
    }
    public void ResetScene()
    {
        //Reload Current Scene
        SceneManager.LoadScene(currentScene);
        //Change time scale to normal time
        Time.timeScale = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If object enters KillZone on hazard...
        if (collision.tag == "KillZone")
        {
            //change color to red
            gameObject.GetComponent<SpriteRenderer>().color = red;
            //Call GameOver function on the 'PauseManager'
            PauseManager.GetComponent<PauseManager>().GameOver();
        }
        //If object collides with explosion
        if(collision.tag == "EnemyExplosion")
        {
            //Lose 1 ammo
            ammo = ammo - 1;
            //Change color to light red
            GetComponent<SpriteRenderer>().color = lightRed;
            //Play deplete ammo animation
            ammoDeplete = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //If you stay in the finish
        if (collision.tag == "Finish")
        {
            //Begin win timer to see if you stay in the finish for certain amount of time
            winTime--;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //If you exit the finish
        if (collision.tag == "Finish")
        {
            //Reset win timer
            winTime = winTimer;
        }
    }
}
