using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pyramiden : MonoBehaviour
{
    private static int currentPannel = 0; 
    private static int currentQuestion = 0;
    private int collectedKnow = 0;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject[] Questionpanels;
    [SerializeField] private GameObject Lastpanels;
    [SerializeField] private GameObject QueensPanel;
    [SerializeField] private GameObject NotEnoughKnowPanel;
    [SerializeField] private Text KeysText;


    [SerializeField] private GameObject rightAnswerPanel;
    [SerializeField] private GameObject WrongAnswerPanel;

    int score ;
    private GameManager gameManager;
    private PlayerScript player;
    private PyramidsAudio pyramidsAudio;
 
    enum hints { Hint1, Hint2, HInt3 };
    private AudioSource myAudioSource;
    private static int currentVisit = 1;
    //[SerializeField] AudioClip [] PyramidsClips;
   // [SerializeField] AudioClip [] newPyramidsClips;
   // [SerializeField] AudioClip QueenPyramids;
    // Start is called before the first frame update
    [SerializeField] AudioClip RightClip;
    [SerializeField] AudioClip WrongClip;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerScript>();
        pyramidsAudio = FindObjectOfType<PyramidsAudio>();
        score = gameManager.getCurrentScore();
        myAudioSource = GetComponent<AudioSource>();

    }

 
    
    public void RightAnswer()
    {
        if (currentVisit == 1){
            score = score + 10;
        gameManager.IncreaseScore(score);
        }
        myAudioSource.clip = RightClip;
        myAudioSource.Play();
        
        rightAnswerPanel.SetActive(true);
        
    }
    
    public void wrongAnswer()
    {
        myAudioSource.clip = WrongClip;
        myAudioSource.Play();
        WrongAnswerPanel.SetActive(true);
    }
    public void WrongAnswrButton()
    {
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
       
        WrongAnswerPanel.SetActive(false);
    }
    public void lastPanelButton()
    {
        currentVisit++;
        gameManager.PyramidIsVisited();
        Time.timeScale = 1f;
        SceneManager.LoadScene("LAND");
        currentQuestion = 0;
        currentPannel = 0;
    }
    public void Display()
    {
        if (panels[currentPannel] != null)
        {
           
            panels[currentPannel].SetActive(true);
            pyramidsAudio.StartClip();
           /*     if(newPyramidsClips[currentPannel] != null){
                myAudioSource.clip = newPyramidsClips[currentPannel];
                myAudioSource.Play();
            }if(newPyramidsClips[currentPannel] == null){
                Debug.Log("No Clip");
            } */
            

        }
        else { Debug.Log("NO PANEL"); }
        collectedKnow++;
            KeysText.text = "Schlüssel: " + collectedKnow;

            Time.timeScale = 0f;
    }
    public void nextPannel() 
    {           
        pyramidsAudio.StopAnyClip();
        if (panels[currentPannel] != null)
        {

            panels[currentPannel++].SetActive(false);
            Time.timeScale = 1f;
            
            panels[currentPannel].SetActive(true);
            pyramidsAudio.StartClip();
        }
        
    }
  
    public void DisplayQuestion()
    {
        if (Questionpanels[currentQuestion] != null)
        {
            Questionpanels[currentQuestion].SetActive(true);
            Time.timeScale = 0f;

        }

    }
    public void closeCurrentPanel()
    {
        pyramidsAudio.StopAnyClip();
        panels[currentPannel].SetActive(false);
        currentPannel++;

        Time.timeScale = 1f;
    }
    public void closeQuestionpanel()
    {
       if (currentQuestion < Questionpanels.Length) { 
        Questionpanels[currentQuestion].SetActive(false);
        currentQuestion++;
        Time.timeScale = 1f;
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
    

    public void RightAnswrButton()
    {        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
      rightAnswerPanel.SetActive(false);
        closeQuestionpanel();
    }
    public void DisplayQueen()
    {
        Time.timeScale = 0f;
        QueensPanel.SetActive(true);
         pyramidsAudio.StartQueenClip();
        collectedKnow++;
        KeysText.text = "Schlüssel: " + collectedKnow;

    }
    public void CloseQueen()
    {
        Time.timeScale = 1f;
        QueensPanel.SetActive(false);
        pyramidsAudio.StopAnyClip();
        
    }
    public void CloseNotEnoughPanel()
    {
        Time.timeScale = 1f;
        NotEnoughKnowPanel.SetActive(false);
    }
    public bool hasKnowlage()
    {
        if(collectedKnow >= 7)
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
}
