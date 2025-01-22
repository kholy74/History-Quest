using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewsScript : MonoBehaviour
{
    [SerializeField] private Transform[] target;
   // [SerializeField] private Transform target2;
    [SerializeField] private float speed = 30f;
    bool isMoving = true;
    bool ismovingAgain = false;
    private int counter = 0;
    Rigidbody rb;
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (target[0]  == null)
        {
            isMoving = false;
            Debug.LogWarning("Anubis " + gameObject.name + "has no waypoints assigned!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateAnimator();
        if (isMoving)
        {
            movements();
            
        }
       // if(ismovingAgain){
         //       moveAgain();
       // }
    }
    void movements()
{
    if (counter < target.Length && isMoving)
    {
        rb.MovePosition(Vector3.MoveTowards(transform.position, target[counter].position, speed * Time.deltaTime));
        
        if (Vector3.Distance(transform.position, target[counter].position) < 0.1f)
        {
            isMoving = false; // Stops the current movement
            counter++;
            //if (counter < target.Length)
            //{
                // Ready for the next target
              //  isMoving = true;
            //}
        }
    }
}
public void setMoving()
{
    
    if (counter < target.Length)
    {
        isMoving = true;
    }
}

 /*   void movements()
    {
        if (target[0] != null)
        {
          rb.MovePosition(Vector3.MoveTowards(transform.position, target[counter].position, speed * Time.deltaTime));
        if (Vector3.Distance(transform.position, target[counter].position) < 0.1f)
        {
            isMoving = false;
            counter++;
            

        }
        }
        else { Debug.Log(" "); }
       
    }
    
    public void setMoving(){
        isMoving = true;
    }
*/
   // public void moveAgain()
    //{
        
     //   if (target2 != null)
      //  {
       //     rb.MovePosition(Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime));
        //    if (Vector3.Distance(transform.position, target2.position) < 0.1f)
         //   {
                //Invoke("changeMove", UnityEngine.Random.Range(minDelay, maxDelay));

                
         //           isMoving=false;
                

          //  }
       // }
        //else { Debug.Log(" "); }

    //}
    private void updateAnimator()
    {
        if (rb.velocity == Vector3.zero)
            myAnimator.SetBool("isRunning", false);
        else
            myAnimator.SetBool("isRunning", true);
    }
}
