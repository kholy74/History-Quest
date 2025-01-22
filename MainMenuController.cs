using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject UserNamePanel;
    [SerializeField] TextMeshProUGUI userNameInput;
    static string userName;
    classesConnection con;
    private GameManager gameManager;
 
    void Start()
    {
        con = FindObjectOfType<classesConnection>();
        gameManager = FindObjectOfType<GameManager>();
        userName = " ";
    }
    public void loadLand()
    {
        UpdateUserName();
        gameManager.UpdateUserName();
        SceneManager.LoadScene("Land");
    }
    public void loadUserNamePanel()
    {
        
        UserNamePanel.SetActive(true);  
    }public void closeUserNamePanel()
    {
        UserNamePanel.SetActive(false);
        Debug.Log(userNameInput.text); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void UpdateUserName()
    {
        if (!string.IsNullOrEmpty(userNameInput.text))
            userName = userNameInput.text;
        else userName = " ";
    }
    public string getUserName()
    {
   //  UpdateUserName();
     return userName; 
    }
}
