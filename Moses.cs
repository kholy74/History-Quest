using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moses : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;  
    [SerializeField] private GameObject NotEnoughKnowPanel;
    [SerializeField] private GameObject Lastpanels;
    [SerializeField] private GameObject CrossRoad;
    [SerializeField] private Text StartsText;
    private static int currentPannel = 0; 
    private int collectedKnow = 0;
    [SerializeField] private List<JewsScript> jewsC;
    private JewsScript jewsScript;
    private GameManager gameManager;
    private AudioSource myAudioSource;
    [SerializeField] AudioClip [] MosesClips;
    // Start is called before the first frame update
    void Start()
    {
        jewsScript = FindObjectOfType<JewsScript>();
        gameManager = FindObjectOfType<GameManager>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Display()
    {
        if (panels[currentPannel] != null)
        {
            
            panels[currentPannel].SetActive(true);
            if(MosesClips[currentPannel] != null){
                myAudioSource.clip = MosesClips[currentPannel];
                myAudioSource.Play();
            }
            collectedKnow++;
            StartsText.text = "Sterne: " + collectedKnow;

            Time.timeScale = 0f;

        }
        else { Debug.Log("NO PANEL"); }
        
    }
     public void closeCurrentPanel()
    {
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        panels[currentPannel].SetActive(false);
        currentPannel++;

        Time.timeScale = 1f;
    }
   public void CloseNotEnoughPanel()
    {
        Time.timeScale = 1f;
        NotEnoughKnowPanel.SetActive(false);
    }
    public bool hasKnowlage()
    {
        if(collectedKnow >= 5)
        {
            return true;
        }
        return false;
    }
    public void DisplayNotEnoughKnowladge()
    {
        Time.timeScale = 1f;
        NotEnoughKnowPanel.SetActive(true);
    }
    public void openCrossRoad(){
        CrossRoad.SetActive(false);
    }
    public void closeCrossRoad(){
        CrossRoad.SetActive(true);
    }
    public void secondMove(){
        jewsScript.setMoving();
        foreach (JewsScript j in jewsC)
        {
            j.setMoving();
        }
        
        
    }
    public void DisplayLastPanel()
    {
        Time.timeScale = 0f;

        Lastpanels.SetActive(true);
                    
    }
    public void closeLastPanel()
    {

        Time.timeScale = 1f;
        Lastpanels.SetActive(false);
    }
    
public void lastPanelButton()
    {
        gameManager.SainiaIsVisited();
        Time.timeScale = 1f;
        SceneManager.LoadScene("LAND");
        currentPannel = 0;
    }
}
