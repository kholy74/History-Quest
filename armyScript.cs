using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armyScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    bool isMoving = false;
    Rigidbody rb;
    private float speed = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (target  == null)
        {
            isMoving = false;
            Debug.LogWarning("ARMY " + gameObject.name + "has no waypoints assigned!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            movements();
            
        }
    }
     void movements()
{
    if (isMoving)
    {
        rb.MovePosition(Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
        
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            isMoving = false; 
            
            //if (counter < target.Length)
            //{
                
              //  isMoving = true;
            //}
        }
    }
}
public void setMoving(){
    isMoving = true;
}
}
