using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Hero : MonoBehaviour
{

    public Camera c;

    //regular movement stuff
    private Rigidbody2D rd;
    public Transform arrowTransform;
    public float speed = 20f; // speed of hero
    public bool mouseControl = true; // mouse control status

    //egg stuff
    public GameObject egg;
    private float eggSpeed = 40f;
    private float eggCooldown = 0.2f;
    private float nextSpawn = 0.0f;
    private int numOfEggs = 0;
    
    //TMP Pro stuff
    public TextMeshProUGUI heroText;
    public TextMeshProUGUI eggText;
    public TextMeshProUGUI heroTouchingText;
    public int touchingEnemy = 0;


    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        c = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Switch between mouse control
        if(Input.GetKeyDown(KeyCode.M))
            mouseControl = !mouseControl;

        speed += 0.2f * Input.GetAxis("Vertical");
        transform.position += transform.up * (speed * Time.smoothDeltaTime);

        // Detect key for rotation
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 45 * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -45 * Time.deltaTime));
        }

        // Moves the hero based on mouse control
        if(mouseControl)
        {
            string text = "Mouse";
            heroText.text = "Hero: Drive (" + text + ")";
            rd.velocity = new Vector2(); // Stops Hero from moving forward

            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = c.ScreenToWorldPoint(mousePos); 
            worldPos.z = transform.position.z;

            transform.position = worldPos;
        }
        else {
            string text2 = "Keyboard";
            heroText.text = "Hero: Drive (" + text2 + ")"; 
            rd.velocity = transform.up * speed;
        } 


        if(Input.GetKey(KeyCode.Space))
        {
            SpawnEggs();
        }
    }

    //spawns egg when the user presses space
    private void SpawnEggs()
    {
        if(Time.time > nextSpawn)
        {

            GameObject eggSpawn = Instantiate(egg, arrowTransform.position, arrowTransform.rotation);
            eggSpawn.GetComponent<EggBehavior>().heroScript = this;
            numOfEggs++;
            eggText.text = "Egg: OnScreen (" + numOfEggs + ")"; 

            Rigidbody2D rb2 = eggSpawn.GetComponent<Rigidbody2D>();
            rb2.velocity = arrowTransform.up * eggSpeed;
            nextSpawn = Time.time + eggCooldown;
        }
    }

    // to decrease the eggcount one it disappears from the screen
    public void decreaseEggCount()
    {
        numOfEggs--;
        eggText.text = "Egg: OnScreen (" + numOfEggs + ")"; 
    }
    
    //this function is for the amount of times an egg or the hero object has touched an enemy object
    void OnTriggerEnter2D(Collider2D collide) { 

        if(collide.gameObject.CompareTag("Enemy"));
            touchingEnemy++;
            heroTouchingText.text = "TouchedEnemy(" + touchingEnemy + ")";
    }
}