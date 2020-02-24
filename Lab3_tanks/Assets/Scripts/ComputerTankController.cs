using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComputerTankController : MonoBehaviour
{
    private Vector3 velocity;
    public GameObject bullet;
    private SpriteRenderer rend;
    private Animator anim;
    private bool canFire = true;
    public float speed = 2.0f;
    public GameController gameController;

    // Use this for initialization
    void Start()
    {
        velocity = new Vector3(1f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // calculate location of screen borders
        // this will make more sense after we discuss vectors and 3D
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        //get the width of the object
        float width = rend.bounds.size.x;
 
        //1% of the time, switch the direction: 
        int change = Random.Range(0, 100);
        if (change == 0)
        {
            velocity = new Vector3(-velocity.x, -velocity.y, 0);
        }

        //make sure the obect is inside the borders... if edge is hit reverse direction
        if ((transform.position.x <= leftBorder + width / 2.0) && velocity.x < 0f)
        {
            velocity = new Vector3(1f, 0f, 0f);
        }
        if ((transform.position.x >= rightBorder - width / 2.0) && velocity.x > 0f)
        {
            velocity = new Vector3(-1f, 0f, 0f);
        }
        transform.position = transform.position + velocity * Time.deltaTime * speed;

        FireShots();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool lose = gameController.SetComputerTankText();
        if (lose)
        {
            Destroy(gameObject);
        }
    }

    private void FireShots()
    {
        //... steps for controlling tank
        //shooting the bullet from the player
        if (canFire==true)
        {
            //the offset 
            Vector3 offset = new Vector3(0f, -1f, 0f);

            //creates a bullet that is pointing in the opposite direction... pick the one you need  
            GameObject b = Instantiate(bullet, new Vector3(0f, 0f, 0f), Quaternion.AngleAxis(180, Vector2.left));
            b.GetComponent<BulletController>().InitPosition(transform.position + offset, new Vector3(0f, 2f, 0f));
            canFire = false;

            //this starts a coroutine... a non-blocking function
            StartCoroutine(PlayerCanFireAgain());
        }

        //... more stuff  as needed goes down here  
    }

    //will wait 3 seconds and then will reset the flag
    IEnumerator PlayerCanFireAgain()
    {
        //this will pause the execution of this method for 3 seconds without blocking
        yield return new WaitForSecondsRealtime(3);
        canFire = true;
    }
}