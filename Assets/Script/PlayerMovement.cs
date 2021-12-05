using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {

    public GameManager gameManager;
    //different speeds
    public int speed = 3;    // The speed that the player will move at.
    public int originalSpeed = 3; 
    //movement
    Vector3 movement;      // The vector to store the direction of the player's movement
    Rigidbody playerRigidbody;      // Reference to the player's rigidbody.
    Animator anim;                      //for animation
    //for bomb
    public int noBomb;
    public GameObject bombPrefab;
    //for keys
    public int blueKey;
    public int greenKey;
    //health
    public int currentHealth = 5;
    //particle affects
    public GameObject invEffect;
    public GameObject HealthEffect;
    public GameObject SpeedEffect;
    //blood
    public GameObject Blood;
    //timer
    public float timeRemaining = 3;
    public bool timerIsRunning = false;
    //collectables
    public int gems;
    public int Cheese;
    //arrow guides
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public GameObject Arrow4;
    public GameObject Arrow5;
    public GameObject Arrow6;
    public GameObject Arrow7;
    public GameObject Arrow8;
    public GameObject Arrow9;
    public GameObject Arrow10;
    //heart
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    //Invincible
    public bool isInvincible;
    public int invincible;
    //SpeedPowerUp
    public bool isSpeed;
    public int speedItem;
    //medkit
    public bool hasMed = false;
    public int medKit;
    //AudioClips
    public AudioClip eat1;
    public AudioClip enemyHitSound;






    // Use this for initialization
    void Start()
    {
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //StartCoroutine(Hit());
        timerIsRunning = false;
        isInvincible = false;
    }

	private void FixedUpdate()
    {   // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Debug.Log(currentHealth);

        dropBomb();
        // Move the player around the scene.
        useInvincibility();
        useMoreSpeed();
        useMedKit();
        Animating(h, v);
        Move(h, v);
        Turning();
	}

    //press space to drop bomb (remove one bomb from inventory) and place bombPrefab instead
    void dropBomb()
    {   
        if (noBomb > 0 && Input.GetKeyDown(KeyCode.Space))
        { //Drop bomb
            noBomb--;
            Instantiate(bombPrefab, new Vector3(GetComponent<Transform>().position.x, bombPrefab.transform.position.y, GetComponent<Transform>().position.z),bombPrefab.transform.rotation);        
        }
    }

    //press 4 key to use invincibility item and remove one from inventory
    void useInvincibility()
    {
        invincibleScript invinciblitiy = gameObject.GetComponent<invincibleScript>();

        if (invincible > 0 && Input.GetKeyDown(KeyCode.Alpha4))
        {
            invincible--;
            //Set the particle affect
            invEffect.SetActive(true);
            AudioSource.PlayClipAtPoint(eat1, transform.position);
            invinciblitiy.timerHit();
        }
    }

    //press 3 key to use speed item and remove one from inventory
    void useMoreSpeed()
    {
        speedPowerUp speedPwrUp = gameObject.GetComponent<speedPowerUp>();

        if (speedItem > 0 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            speedItem--;
            //Set the particle affect
            SpeedEffect.SetActive(true);
            AudioSource.PlayClipAtPoint(eat1, transform.position);
            speedPwrUp.timerHit();
        }
    }
    
    void useMedKit()
    {

        if (medKit > 0 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            medKit--;
            //Set the particle affect
            HealthEffect.SetActive(true);
            AudioSource.PlayClipAtPoint(eat1, transform.position);
            addMedHealth();
        }
        else if (medKit == 0)
        {
            hasMed = false;
        }
    }


    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);


    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool("isWalking", walking);
    }


    void Turning()
    {
            if (Input.GetKey(KeyCode.W))
            { //Up 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, -0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            { //Left 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, 270, 0);
            }

            if (Input.GetKey(KeyCode.S))
            { //Down 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, -180, 0);
            }

            if (Input.GetKey(KeyCode.D))
            { //Right 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
            }       
    }

    // Update is called once per frame
    void Update() {
       //for timer
        if (timerIsRunning == true)
        {
            if(timeRemaining > 0)
            {
                //Hit();       
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                normalSpeed(); // back to normal speed
                endHit(); //end blood affect
                resetTimer();
            }
        }

        if (currentHealth > numOfHearts)
        {
            currentHealth = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(currentHealth == 0)
        {
            GameManager gManager = gameObject.GetComponent<GameManager>();
            gManager.EndGame();
        }
    }

    //collide with the guided arrows (set them to false)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow1")
        {
            Arrow1.SetActive(false);
        }
        if (other.name == "Arrow2")
        {
            Arrow2.SetActive(false);
        }
        if (other.name == "Arrow3")
        {
            Arrow3.SetActive(false);
        }
        if (other.name == "Arrow4")
        {
            Arrow4.SetActive(false);
        }
        if (other.name == "Arrow5")
        {
            Arrow5.SetActive(false);
        }
        if (other.name == "Arrow6")
        {
            Arrow6.SetActive(false);
        }
        if (other.name == "Arrow7")
        {
            Arrow7.SetActive(false);
        }
        if (other.name == "Arrow8")
        {
            Arrow8.SetActive(false);
        }
        if (other.name == "Arrow9")
        {
            Arrow9.SetActive(false);
        }
        if (other.name == "Arrow10")
        {
            Arrow10.SetActive(false);
        }
    }

    //display blood affect
    public void Hit()
    {
        AudioSource.PlayClipAtPoint(enemyHitSound, transform.position);
        Blood.SetActive(true);
    }

    //end blood affect
    public void endHit()
    {
        Blood.SetActive(false);
    }

   
    public void timerHit()
    {
        timerIsRunning = true;
    }
    
    public void resetTimer()
    {
        timerIsRunning = false;
        if(timerIsRunning == false)
        {
            timeRemaining = 3;
        }
    }

    public void normalSpeed()
    {
        speed = 5;
    }

    public void SlimeAttack()
    {
        speed = 1;
    }
    
    public void lavaDamage()
    {
        currentHealth -= 1;
    }

    public void gemsBunch()
    {
        gems += 4;
    }

    public void invincibleOn()
    {
        isInvincible = true;
    }

    public void invincibleOff()
    {
        isInvincible = false;
    }

    public void addInvincible()
    {
        invincible++;
    }

    public void burgerHeal()
    {
        currentHealth++;
        //set heal affect on
        HealthEffect.SetActive(true);
    }

    public void speedOn()
    {
        isSpeed = true;
        speed = 6;
    }

    public void speedOff()
    {
        isSpeed = false;
        speed = 3;
    }

    public void addSpeed()
    {
        speedItem++;
    }

    public void addMedKit()
    {
        hasMed = true;
        medKit++;
    }

    public void addMedHealth()
    {
        currentHealth += 3;
    }

    public void brownDamage()
    {
        currentHealth -= 3;
    }

    //display instructions on what to collect.
    void OnGUI()
    {
        GUIStyle headStyle1 = new GUIStyle();
        GUIStyle headStyle2 = new GUIStyle();
        headStyle1.fontSize = 20;
        headStyle2.fontSize = 25;
        GUI.Label(new Rect(580, 590, 100, 20), " " + noBomb, headStyle2);
        GUI.Label(new Rect(680, 590, 100, 20), " " + medKit, headStyle2);
        GUI.Label(new Rect(780, 590, 100, 20), " " + speedItem, headStyle2);
        GUI.Label(new Rect(880, 590, 100, 20), " " + invincible, headStyle2);

        GUI.Label(new Rect(1100, 20, 100, 20), "Collect the gems " + " (" + gems + " / 10)", headStyle1);
        GUI.Label(new Rect(1100, 40, 100, 20), "Collect the green key" + " (" + Variables.greenKey + " / 1)", headStyle1);
        GUI.Label(new Rect(1100, 60, 100, 20), "Collect the blue key" + " (" + Variables.blueKey + " / 1)", headStyle1);
    }
}
