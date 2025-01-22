using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classesConnection : MonoBehaviour
{
    static string username;
    // Start is called before the first frame update
    void Start()
    {
        username = string.Empty;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setUsername(string newName)
    {
        username = newName;
   
    }
    public string getUsername()
    {
        return username;
    }
}
