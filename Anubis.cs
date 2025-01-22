using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Anubis : MonoBehaviour
{
    [SerializeField] private Transform[] target;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int neededNatron = 1;
    [SerializeField] private int neededOil =1;
    [SerializeField] private int neededHerbs =1;
    Rigidbody rb;

    bool isMoving= true;
    private int counter = 0;
    private PlayerScript myPlayer;
    private float minDelay = 0.25f;
    private float maxDelay = 3f;
  
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
      
        rb = GetComponent<Rigidbody>();
        if (target.Length ==0)
        {
            isMoving = false;
            Debug.LogWarning("Anubis "+ gameObject.name +"has no waypoints assigned!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // if (isMoving)
        //{
         //   movements();
        //}
    }
 /*   void movements()
    {
        if (target[0] != null)
        {
          rb.MovePosition(Vector3.MoveTowards(transform.position, target[counter].position, speed * Time.deltaTime));
        if (Vector3.Distance(transform.position, target[counter].position) < 0.1f)
        {
            Invoke("changeMove", UnityEngine.Random.Range(minDelay, maxDelay));

            if (counter >= target.Length - 1)
            {
                changeMove();
                counter = 0;
            }

            else
            {
                changeMove();
                counter++;
            }

        }
        }
        else { Debug.Log(" "); }
       
    }
*/
    private bool HasAllTools()
    {
        if (gameManager.getNatron() >= neededNatron && gameManager.getOil() >=neededOil && gameManager.getHerbs() >= neededHerbs)
        {
            return true;
        }
        return false;
    }
    private void changeMove()
    {
        if (isMoving)  
            isMoving = false;
        else isMoving = true;   
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            if (HasAllTools())
            {
                collision.gameObject.GetComponent<PlayerScript>().freez();collision.gameObject.GetComponent<PlayerScript>().unfreez();
                Destroy(gameObject);
                gameManager.SetOil(-neededOil);
                gameManager.SetHerbs(-neededHerbs);
                gameManager.SetNatron(-neededNatron);
                
            }
            else {
            
            collision.gameObject.GetComponent<PlayerScript>().Die();
            Invoke("changeMove", 2f);
            changeMove(); 
            }
            
        }
        if (collision.gameObject.tag == "Bomb")
        {
            Invoke("changeMove", 4f);
            changeMove();
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (HasAllTools())
            {
                
                Destroy(gameObject);
                gameManager.SetOil(-neededOil);
                gameManager.SetHerbs(-neededHerbs);
                gameManager.SetNatron(-neededNatron);
                

            }
            else
            {
                

                other.gameObject.GetComponent<PlayerScript>().Die();
                Invoke("changeMove", 2f);
                changeMove();
            }

        }
    }*/
}
