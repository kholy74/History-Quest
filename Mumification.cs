using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mumification : MonoBehaviour
{
    GameManager gameManager;
    ToolsSpawner toolSpawner;
    enum Tools { Natron, Oil, Herbs, Food, Water, NewHerb };

    
    static bool firstNatron = true;
    static bool firstOil = true;
    static bool firstHerbs = true;
    static bool firstFood = true;
    static bool firstWater = true;
    static bool firstNewHerbs = true;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
       toolSpawner = FindObjectOfType<ToolsSpawner>();  
        body = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter(Collider other)
    {
        
            if (gameObject.tag =="Natron")
            {
                if (other.gameObject.tag == "Player")
                {
                    if (firstNatron)
                    {

                        firstNatron = false;
                        toolSpawner.displayPanel("Natron");
                        
                    }
                    gameManager.SetNatron(1);
                    Destroy(gameObject);
                }
            }
            if (gameObject.tag == "Oil")
            {
                if (other.gameObject.tag == "Player")
                {
                    if (firstOil)
                    {
                        firstOil = false;
                        toolSpawner.displayPanel("Oil");

                    }
                    gameManager.SetOil(1);
                    Destroy(gameObject);
                }
            }
            if (gameObject.tag == "Herb")
            {
                if (other.gameObject.tag == "Player")
                {
                    if (firstHerbs)
                    {
                        firstHerbs = false;
                        toolSpawner.displayPanel("Herb");

                    }
                    gameManager.SetHerbs(1);
                    Destroy(gameObject);
                }
            }
            if (gameObject.name == "Food")
            {
                if (other.gameObject.tag == "Player")
                {
                    if (firstFood)
                    {
                        firstFood = false;
                        toolSpawner.displayPanel("Food");

                    }
                    gameManager.SetFood(1);
                    Destroy(gameObject);
                }
            }
             if (gameObject.name == "Water")
            {
                if (other.gameObject.tag == "Player")
                {
                    if (firstWater)
                    {
                        firstWater = false;
                        toolSpawner.displayPanel("Water");

                    }
                    gameManager.SetWater(1);
                    Destroy(gameObject);
                }
            }
            if (gameObject.name == "NewHerb")
            {
                if (other.gameObject.tag == "Player")
                {
                    if (firstNewHerbs)
                    {
                        firstNewHerbs = false;
                        toolSpawner.displayPanel("NewHerb");

                    }
                    gameManager.SetNewHerb(1);
                    Destroy(gameObject);
                }
            }

        
    }
  


}
