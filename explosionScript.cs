using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 explosionDirection = Vector3.zero;
    private float explosionSpeed = 200f;
    private float explosionRange = 2f;
    private Vector3 pos;
    private Pyramiden p;
    void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody>();
        p= FindObjectOfType<Pyramiden>();
    }

    private void Update()
    {
       if( Vector3.Distance(pos, transform.position) >= explosionRange)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = explosionDirection * explosionSpeed * Time.deltaTime;
    }

    public void setExplosion(Vector3 Direction, float Speed, float Range )
    {
        explosionDirection = Direction; explosionSpeed = Speed; explosionRange = Range;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerScript>().Die();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bomb")
        {
            other.GetComponent<BombScript>().explode();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Treasure")
        {
           
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.gameObject.name == "Hint1")
        {
            p.Display();
            Destroy(other.gameObject);
        }
    }
}
