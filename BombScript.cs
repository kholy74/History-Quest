using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    PlayerScript player;
    private float ExplodedelayTime = 2f;
    private float timer = 0;
    [SerializeField] private GameObject explosion;
    private float Range = 2f;
    // Start is called before the first frame update
    void Start()
    {
       
        player = GetComponent<PlayerScript>();
      //
      //explosion = GetComponent<explosionScript>();
       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ExplodedelayTime)
        {
            explode();
            
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<SphereCollider>().isTrigger = false;
        }
    }
    public void explode()
    {
        GameObject exr  =  Instantiate(explosion, transform.position, Quaternion.identity);
        exr.GetComponent<explosionScript>().setExplosion(Vector3.right, 200f, Range);
        
        GameObject exl = Instantiate(explosion, transform.position, Quaternion.identity);
        exl.GetComponent<explosionScript>().setExplosion(Vector3.left, 200f, Range);
        GameObject exf = Instantiate(explosion, transform.position, Quaternion.identity);
        exf.GetComponent<explosionScript>().setExplosion(Vector3.forward, 200f, Range);
        GameObject exb = Instantiate(explosion, transform.position, Quaternion.identity);
        exb.GetComponent<explosionScript>().setExplosion(Vector3.back, 200f, Range);
      /*  GameObject exrf = Instantiate(explosion, transform.position, Quaternion.identity);
        exrf.GetComponent<explosionScript>().setExplosion(new Vector3(1,0,1), 200f, Range);
        GameObject exrb = Instantiate(explosion, transform.position, Quaternion.identity);
        exrb.GetComponent<explosionScript>().setExplosion(new Vector3(1, 0, -1), 200f, Range);
        GameObject exlf = Instantiate(explosion, transform.position, Quaternion.identity);
        exlf.GetComponent<explosionScript>().setExplosion(new Vector3(-1, 0, 1), 200f, Range);
        GameObject exlb = Instantiate(explosion, transform.position, Quaternion.identity);
        exlb.GetComponent<explosionScript>().setExplosion(new Vector3(-1, 0, -1), 200f, Range);*/

        Destroy(gameObject);
    }
}
