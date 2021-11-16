using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;    // The speed that the player will move at.
    Vector3 movement;      // The vector to store the direction of the player's movement
    Rigidbody playerRigidbody;      // Reference to the player's rigidbody.
    Animator anim;                      //for animation
    //for bomb
    public int noBomb = 3;
    public GameObject bombPrefab;
    public int currentHealth = 5;
    //blood
    public GameObject Blood;
    public float timeRemaining = 3;
    public bool timerIsRunning = false;







    // Use this for initialization
    void Start () {
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        //StartCoroutine(Hit());
        timerIsRunning = false;
    }

	private void FixedUpdate()
    {   // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Debug.Log(currentHealth);

        dropBomb();
        // Move the player around the scene.
        Animating(h, v);
        Move(h, v);
        Turning();

	}


    void dropBomb()
    {   
        if (noBomb > 0 && Input.GetKeyDown(KeyCode.Space))
        { //Drop bomb
            
            Instantiate(bombPrefab, new Vector3(GetComponent<Transform>().position.x, bombPrefab.transform.position.y, GetComponent<Transform>().position.z),bombPrefab.transform.rotation);
            
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
                GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            { //Left 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, 270, 0);
            }

            if (Input.GetKey(KeyCode.S))
            { //Down 
                GetComponent<Transform>().rotation  = Quaternion.Euler(0, 180, 0);
            }

            if (Input.GetKey(KeyCode.D))
            { //Right 
                GetComponent<Transform>().rotation  = Quaternion.Euler(0, 90, 0);
            }
        
    }

    // Update is called once per frame
    void Update() {
        
        if(timerIsRunning == true)
        {
            if(timeRemaining > 0)
            {
                Hit();
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                endHit();
            }
        }
        
    }

    /**public IEnumerator Hit()
    {
        yield return new WaitForSeconds(timer);
        Blood.SetActive(true);

        if(timer == 0)
        {
            Blood.SetActive(false);
        }
        
    }**/

    public void Hit()
    {
        Blood.SetActive(true);
    }

    public void endHit()
    {
        Blood.SetActive(false);
    }

    public void timerHit()
    {
        timerIsRunning = true;
    }


	
}
