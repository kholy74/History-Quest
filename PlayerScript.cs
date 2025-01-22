using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
   float speed = 250f;
    private bool isMovingForward = false; 
    private bool isMovingBackward = false;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    [SerializeField] GameObject bombPrefab;
    private GameManager gameManager;
    private StoryTeller storyTeller;
    Rigidbody rb;
    bool isMoving = true;
    private float DelayTime = 1f;
    [SerializeField] GameObject pyramidRequirmentsPanel;
    private Pyramiden p;
    private LuxorScript luxor;
    private KarnakScript karnak;
    public float rotationSpeed = 100f;
    private Animator myAnimator;
    private Moses moses;
    [SerializeField] AudioClip openChest;
    [SerializeField] AudioClip disappearClip;
    [SerializeField] AudioClip CollectClip;
    private float tempInput =0;
    private AudioSource myAudioSource;
   
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        p = FindObjectOfType<Pyramiden>();
        luxor = FindObjectOfType<LuxorScript>();
        karnak = FindObjectOfType<KarnakScript>();
        storyTeller = FindObjectOfType<StoryTeller>();
        moses = FindObjectOfType<Moses>();
        myAudioSource = GetComponent<AudioSource>();
        
       
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ){
               if(SceneManager.GetActiveScene().name == "Moses"){speed = 350f;}
                
                else
                {
                    speed = 500;
                }
        }
        else{
            speed = 250f;
        }

        updateAnimator();
        if (isMoving) {
            
            if (Input.GetMouseButton(1)) 
            {
               
                float mouseX = Input.GetAxis("Mouse X");

                
                transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime, Space.World);
            }
              
    	float keyboardInput = 0f;
     
       if (Input.GetKey(KeyCode.LeftArrow) || isRotatingLeft)
        {
            keyboardInput -= 1f; 
        }
       
        if (Input.GetKey(KeyCode.RightArrow)|| isRotatingRight)
        {
            keyboardInput += 1f; 
        }
        
     
        transform.Rotate(Vector3.up, (keyboardInput + tempInput) * rotationSpeed * Time.deltaTime, Space.World);
    

            Movement();
           
        }
        

    }
    public void freez()
    {
        isMoving = false;
        Time.timeScale = 0f;

    }
    public void unfreez()
    {
        isMoving = true;
        Time.timeScale = 1f;
    }
    private void rotation()
    {
        if (rb.velocity != Vector3.zero)
            transform.forward = rb.velocity;
    }

    void Movement()
    {
        

        Vector3 newVel =  Vector3.zero;

       
        if (Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.UpArrow) || isMovingForward == true)
        {
            

            newVel -= transform.right * (speed * Time.deltaTime);

            
        }
        else if (Input.GetKey(KeyCode.S) ||Input.GetKey(KeyCode.DownArrow)|| isMovingBackward == true) {

           
            newVel += transform.right * (speed * Time.deltaTime);


        }
        else if (Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.RightArrow)|| isMovingRight == true)
        {
            
           // newVel += transform.forward * (speed * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow) || isMovingLeft == true)
        {
            
           
           // newVel -= transform.forward * (speed * Time.deltaTime);
        }
         else if ( isMovingRight == true && isMovingForward)
        {
            newVel += (transform.forward * (speed * Time.deltaTime))+(-transform.right * (speed * Time.deltaTime));
           
        }
        else if ( isMovingLeft == true && isMovingForward)
        {
            newVel += (-transform.forward * (speed * Time.deltaTime))+(-transform.right * (speed * Time.deltaTime));
           
        }
        else if ( isMovingLeft == true && isMovingBackward)
        {
            newVel += (-transform.forward * (speed * Time.deltaTime))+(transform.right * (speed * Time.deltaTime));
           
        }
        else if ( isMovingRight == true && isMovingBackward)
        {
            newVel += (transform.forward * (speed * Time.deltaTime))+(transform.right * (speed * Time.deltaTime));
           
        }

        rb.velocity = newVel;
 
    }
    void HandleRotation()
    {
        if (isRotatingLeft)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (isRotatingRight)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Pyramids
        if (collision.gameObject.name == "PyramidsBorder")
        {
            if (gameManager.getCurrentScore() >= 40)
            {
                Destroy(collision.gameObject);
                gameManager.loadAnubisPyramidsPanel();
            }
            else { storyTeller.displayPyramidBorderPanel(); }

        }
        if (collision.gameObject.tag == "PyramidDoor")
        {
            storyTeller.loadPyramidsPanel();
        }
        if (collision.gameObject.tag == "Treasure")
        {
            myAudioSource.clip = openChest;
                myAudioSource.Play();
           HintScript hintaya = collision.gameObject.GetComponent<HintScript>();
              if (hintaya != null)
            {
                
                hintaya.setAnimator();
            }
             Destroy(collision.gameObject,1);
           

        }
        if (collision.gameObject.tag == "Hint")
        {
            myAudioSource.clip = CollectClip;
            myAudioSource.Play();
            Destroy(collision.gameObject);
            p.Display();
        }
        if (collision.gameObject.tag == "Star")
        {
            myAudioSource.clip = CollectClip;
            myAudioSource.Play();
            Destroy(collision.gameObject);
            moses.Display();
        }
        if (collision.gameObject.name == "closeCross")
        {
            
            Destroy(collision.gameObject);
            moses.closeCrossRoad();
        }
        if (collision.gameObject.tag == "Question")
        {
            Destroy(collision.gameObject);
            p.DisplayQuestion();
        }
        if (collision.gameObject.name == "OutDoorPyramids")
        {

            p.DisplayLastPanel();
        }
        if (collision.gameObject.name == "QueeensChamber")
        {
            Destroy(collision.gameObject);
            p.DisplayQueen();
        }
        if (collision.gameObject.name == "Thoth")
        {
            if (p.hasKnowlage())
            {
                myAudioSource.clip = disappearClip;
                myAudioSource.Play();
                Destroy(collision.gameObject);
            }
            else
            {
                p.DisplayNotEnoughKnowladge();
            }


        }
        if (collision.gameObject.name == "ThothMoses")
        {
            if (moses.hasKnowlage())
            {
                myAudioSource.clip = disappearClip;
                myAudioSource.Play();
                Destroy(collision.gameObject);
            }
            else
            {
                moses.DisplayNotEnoughKnowladge();
            }


        }
        if (collision.gameObject.name == "LuxorBorder")
        {
            if (gameManager.getCurrentScore() >= 20)
            {
                gameManager.loadAnubisKarnakPanel();
                Destroy(collision.gameObject);
            }
            else
            {
                storyTeller.loadNotEnoughLuxorPanel();
            }


        }
        if (collision.gameObject.tag == "SinaiBorder")
        {
            if (gameManager.getCurrentScore() >= 60)
            {
                gameManager.resetToolsSinai();
                gameManager.loadSainaiQuestPanel();
                Destroy(collision.gameObject);
            }
            else
            {
                storyTeller.loadNotEnoughSinaiPanel();
            }


        }

        if (collision.gameObject.tag == "Stairs")
        {
            rb.useGravity = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            myAudioSource.clip = disappearClip;
                myAudioSource.Play();
        }

        //luxor and Karnak temples


        if (collision.gameObject.name == "LuxorDoor")
        {
            storyTeller.loadLuxorPanel();
        }
        if (collision.gameObject.tag == "LuxorKey")
        {
            myAudioSource.clip = CollectClip;
            myAudioSource.Play();
            Destroy(collision.gameObject);
            luxor.Display();
        }if (collision.gameObject.tag == "KarnakKey")
        {
            myAudioSource.clip = CollectClip;
            myAudioSource.Play();
            Destroy(collision.gameObject);
            karnak.Display();
        }

        if (collision.gameObject.name == "Obelisk")
        {
            Destroy(collision.gameObject);
            luxor.DisplayQueen();
        }if (collision.gameObject.name == "ObeliskKarnak")
        {
            Destroy(collision.gameObject);
            karnak.DisplayQueen();
        }
        if (collision.gameObject.tag == "QuestionLuxor")
        {
            Destroy(collision.gameObject);
            luxor.DisplayQuestion();
        }if (collision.gameObject.tag == "QuestionKarnak")
        {
            Destroy(collision.gameObject);
            karnak.DisplayQuestion();
        }if (collision.gameObject.name == "Ramsis")
        {
            myAudioSource.clip = disappearClip;
                myAudioSource.Play();
            Destroy(collision.gameObject);
            karnak.DisplayRamsis();
        }
        if (collision.gameObject.name == "ThothLuxor")
        {
            if (luxor.hasKnowlage())
            {
                myAudioSource.clip = disappearClip;
                myAudioSource.Play();
                Destroy(collision.gameObject);
            }
            else
            {
                luxor.DisplayNotEnoughKnowladge();
            }


        }if (collision.gameObject.name == "ThothKarnak")
        {
            if (karnak.hasKnowlage())
            {
                Destroy(collision.gameObject);
            }
            else
            {
                karnak.DisplayNotEnoughKnowladge();
            }


        }
        if (collision.gameObject.name == "OutDoorLuxor")
        {

            luxor.DisplayLastPanel();
        }
        if (collision.gameObject.name == "OutDoorMoses")
        {

            moses.DisplayLastPanel();
        }
        if (collision.gameObject.name == "OutDoorKarnak")
        {

            karnak.DisplayLastPanel();
        }

 
        if (collision.gameObject.name == "KarnakDoor")
        {
            storyTeller.loadKarnakPanel();
        }
        if (collision.gameObject.name == "SinaiDoor")
        {
           if(gameManager.hasAllSinai()){
                
                storyTeller.loadSinaiPanel();
            }
            else{
               storyTeller.loadNotEnoughSinaiPanel();
            }
            
        }

        // Egyptian Characters
        if (collision.gameObject.name == "Nobi")
        {
            storyTeller.LoadNobiPanel();
        }
        if (collision.gameObject.name == "Priest")
        {
            storyTeller.LoadPriestPanel();
        }
        if (collision.gameObject.name == "Nobel")
        {
            storyTeller.LoadNobelPanel();
        }
        if (collision.gameObject.name == "Soldier")
        {
            storyTeller.LoadSoldierPanel();
        }
        if (collision.gameObject.name == "Farmer")
        {
            storyTeller.LoadFarmerPanel();
        }
        if (collision.gameObject.name == "King")
        {
            storyTeller.LoadKingPanel();
        }
        if (collision.gameObject.name == "WestSide")
        {
            storyTeller.LoadWestSidePanel();
        }
        if (collision.gameObject.name == "Wheat")
        {
            storyTeller.LoadWheatPanel();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Stairs")
        {
            rb.useGravity = false;
        }
    }
    public float getDelayTime()
    {
        return DelayTime;
    }
    public void Die()
    {
        
        isMoving = false;

        
        rb.isKinematic = true;
       
        gameManager.playerdied();

        
       Destroy(gameObject, DelayTime);
    }
    private void placeBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        //    GameObject bomb = Instantiate(bombPrefab, new Vector3 ( transform.position.x, 0 , transform.position.z), Quaternion.identity);
          //  bomb.transform.position = new Vector3(Mathf.Round( transform.position.x), 1.5f, Mathf.Round(transform.position.z));
        }
    }
    public void delayedFreez()
    {
        Invoke("freez", 1f);
        freez();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "PyramidRequi")
        {
         //   pyramidRequirmentsPanel.SetActive(true);
        }
        if (other.gameObject.tag == "Stairs")
        {
            rb.useGravity = false;
        }
    }
    public void PyramidRequiButton()
    {
        pyramidRequirmentsPanel.SetActive(false);
    }
    private void updateAnimator()
    {
        if(rb.velocity == Vector3.zero)
        myAnimator.SetBool("IsRunning", false);
        else
            myAnimator.SetBool("IsRunning", true);
    }
    public void moveForward()
    {
        isMovingForward = true;
        //Vector3 newVel = Vector3.zero;
        //newVel -= transform.right * (speed * Time.deltaTime);
        //rb.velocity = newVel;
    }
    public void stopMovingForward()
    {
        isMovingForward = false;
    }
    public void moveBackward()
    {
        isMovingBackward = true;
        //Vector3 newVel = Vector3.zero;
        //newVel += transform.right * (speed * Time.deltaTime);
        //rb.velocity = newVel;

    }
    public void stopMovingBackward()
    {
        isMovingBackward = false;
    }
    public void moveRight()
    {
        isMovingRight = true;
        //Vector3 newVel = Vector3.zero;
        //newVel += transform.forward * (speed * Time.deltaTime);
        //rb.velocity = newVel;
    }
    public void stopMovinRight()
    {
        isMovingRight = false;
    }
    public void moveLeft()
    {
        isMovingLeft = true;
        //Vector3 newVel = Vector3.zero;
        //newVel -= transform.forward * (speed * Time.deltaTime);
        //rb.velocity = newVel;
    }
    public void stopMovingLeft()
    {
        isMovingLeft = false;
    }
    public void rotateLeft()
    {
        isRotatingLeft = true;
    }

    public void stopRotatingLeft()
    {
        isRotatingLeft = false;
    }

    public void rotateRight()
    {
        isRotatingRight = true;
    }

    public void stopRotatingRight()
    {
        isRotatingRight = false;
    }
    public void updateSpeed(float addedSpeed)
    {
        speed +=addedSpeed;
    }
    

}