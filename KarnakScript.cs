using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KarnakScript : MonoBehaviour
{
    private static int currentPannel = 0;
    private static int currentQuestion = 0;
    private int collectedKnow = 0;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private GameObject[] Questionpanels;
    [SerializeField] private GameObject Lastpanels, RamsisPanel;
    [SerializeField] private GameObject QueensPanel;
    [SerializeField] private GameObject NotEnoughKnowPanel;
    [SerializeField] private Text KeysText;
    [SerializeField] private GameObject rightAnswerPanel;
    [SerializeField] private GameObject WrongAnswerPanel;
    int score;
    private GameManager gameManager;
    private AudioSource myAudioSource;
    [SerializeField] AudioClip [] KarnakClips;
    [SerializeField] AudioClip QueenKarnak;
    [SerializeField] AudioClip RamsesKarnak;
    [SerializeField] AudioClip RightClip;
    [SerializeField] AudioClip WrongClip;
    private static int currentVisit = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        score = gameManager.getCurrentScore();
        myAudioSource = GetComponent<AudioSource>();
    }

    public void RightAnswer()
    {
        if(currentVisit == 1){
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
        currentVisit ++;
        gameManager.KarnakIsVisited();
        Time.timeScale = 1f;
        currentQuestion = 0;
        currentPannel = 0;
        SceneManager.LoadScene("LAND");
    }
    public void Display()
    {
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        if (panels[currentPannel] != null)
        {
            panels[currentPannel].SetActive(true);
            if(KarnakClips[currentPannel] != null){
                myAudioSource.clip = KarnakClips[currentPannel];
                myAudioSource.Play();
            }



            Time.timeScale = 0f;

        }

        else { Debug.Log("NO PANEL"); }
        collectedKnow++;
        KeysText.text = "Schlüssel: " + collectedKnow;

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
        panels[currentPannel].SetActive(false);
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        currentPannel++;

        Time.timeScale = 1f;
    }
    public void closeQuestionpanel()
    {
        if (currentQuestion < Questionpanels.Length)
        {
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
    }public void DisplayRamsis()
    {
        Time.timeScale = 0f;
        if(RamsesKarnak != null){
            myAudioSource.clip = RamsesKarnak;
            myAudioSource.Play();
        }
        RamsisPanel.SetActive(true);

    }
    public void closeRamsis()
    {
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        Time.timeScale = 1f;
        RamsisPanel.SetActive(false);
    }


    public void RightAnswrButton()
    {
       
        if (myAudioSource.isPlaying)
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
        if(QueenKarnak != null){
            myAudioSource.clip = QueenKarnak;
                myAudioSource.Play();
        }
        collectedKnow++;
        KeysText.text = "Schlüssel: " + collectedKnow;

    }
    public void CloseQueen()
    {
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        QueensPanel.SetActive(false);

    }
    public void CloseNotEnoughPanel()
    {
        Time.timeScale = 1f;
        NotEnoughKnowPanel.SetActive(false);
    }
    public bool hasKnowlage()
    {
        if (collectedKnow >= 4)
        {
            return true;
        }
        return false;
    }
    public void DisplayNotEnoughKnowladge()
    {
        Time.timeScale = 0f;
        NotEnoughKnowPanel.SetActive(true);
    }

}
