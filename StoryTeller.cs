using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;


public class StoryTeller : MonoBehaviour
{
    
    private int currentIntroPannel = 0;
    private int currentintroclip = 0;
    [SerializeField] private GameObject[] IntroPanels;
    private GameManager gameManager;
    [SerializeField] GameObject PyramidsPanel;
    [SerializeField] GameObject LuxorPanel;
    [SerializeField] GameObject KarnakPanel;
    [SerializeField] GameObject SinaiPanel;
    [SerializeField] GameObject NotEnoughLuxorPanel;
    [SerializeField] GameObject AnubisLuxorPanel;
    [SerializeField] GameObject AnubisKarnakPanel;
    [SerializeField] GameObject NotEnoughScorePyramidPanel;
    [SerializeField] GameObject NotEnoughScoreSinaiPanel;
    [SerializeField] GameObject NobiPanel;
    [SerializeField] GameObject PriestPanel;
    [SerializeField] GameObject NobelPanel;
    [SerializeField] GameObject SoldierPanel;
    [SerializeField] GameObject FarmerPanel;
    [SerializeField] GameObject KingPanel;
    [SerializeField] GameObject WestSidePanel;
    [SerializeField] GameObject WheatPanel;
    private AudioSource myAudioSource;
    [SerializeField] AudioClip [] IntroClips;
    [SerializeField] AudioClip NobelClip;
    [SerializeField] AudioClip NobiClip;
    [SerializeField] AudioClip FarmerClip;
    [SerializeField] AudioClip PriestClip;
    [SerializeField] AudioClip SoldierClip;
    [SerializeField] AudioClip KingClip;
    [SerializeField] AudioClip WestSideClip;
    [SerializeField] AudioClip WheatClip;
    private MainMenuController mainMenu;
    private string usersname;
    [SerializeField] private TextMeshProUGUI welcoming;
    classesConnection connection;
    // Start is called before the first frame update
    void Start()
    {
        connection = FindObjectOfType<classesConnection>();
        mainMenu =  FindObjectOfType<MainMenuController>();
      //  
            setWelcomeName();
        myAudioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        usersname = " ";
        // Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void setUsername(string newName)
    {
        usersname = newName;
        
   
    }

    public void setWelcomeName()
    {
       /*  if(gameManager !=null){
        //if (!string.IsNullOrEmpty(gameManager.getUsername()))
       // {
            usersname = gameManager.getUsername();
            
       // }
        }*/
        welcoming.text = "Willkommen " + usersname + " in History Quest";

    }
    public void displayFirstPanel()
    {
        
        Time.timeScale = 0f;
        if(IntroPanels[currentIntroPannel] != null){
        IntroPanels[currentIntroPannel].SetActive(true);
        }
        else Debug.Log("Panel not reached");
        
    }

    public void nextIntroPannel() 
    {
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        if(currentIntroPannel == 0)
        {
            myAudioSource.Play();
        }
        

        if (IntroPanels[currentIntroPannel +1] != null)
        {
            if (IntroClips[currentintroclip] != null && currentIntroPannel > 0)
            {
                
                myAudioSource.clip = IntroClips[currentintroclip++];
                myAudioSource.Play();
            }
            IntroPanels[currentIntroPannel++].SetActive(false);
           

            IntroPanels[currentIntroPannel].SetActive(true);
            
            
        }
        

    }
    public void LastIntroPanel()
    {
        if (myAudioSource.isActiveAndEnabled)
        {
            myAudioSource.Stop();
        }
        
        IntroPanels[currentIntroPannel].SetActive(false);
        Time.timeScale = 1f;
        loadAnubisLuxorPanel();
    }

    //Pyramids
    public void displayPyramidBorderPanel()
    {
        Time.timeScale = 0f;
        NotEnoughScorePyramidPanel.SetActive(true);
    } public void cancelPyramidBorderPanel()
    {
        Time.timeScale = 1f;
        NotEnoughScorePyramidPanel.SetActive(false);
    }
    public void loadPyramidsPanel()
    {
        Time.timeScale = 0f;
        PyramidsPanel.SetActive(true);
    }
    public void PyramidButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Pyramiden");
    }
    public void CancelPyramid()
    {
        Time.timeScale = 1f;
        PyramidsPanel.SetActive(false);
    }

    //Luxor
    public void loadLuxorPanel()
    {
        Time.timeScale = 0f;
        LuxorPanel.SetActive(true);
    }
    public void LuxorButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Luxor");
    }
    public void CancelLuxor()
    {
        Time.timeScale = 1f;
        LuxorPanel.SetActive(false);
    }  public void loadAnubisLuxorPanel()
    {
        AnubisLuxorPanel.SetActive(true);
    }
    public void CancelAnubisLuxor()
    {
        AnubisLuxorPanel.SetActive(false);
    }

    //Karnak 

    public void loadKarnakPanel()
    {
        Time.timeScale = 0f;
        KarnakPanel.SetActive(true);
    }
    public void KarnakButton()
    {
        gameManager.KarnakIsVisited();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Karnak");
    }
    public void CancelKarnak()
    {
        Time.timeScale = 1f;
        KarnakPanel.SetActive(false);
    }
    public void loadNotEnoughLuxorPanel()
    {
        Time.timeScale = 0f;
        NotEnoughLuxorPanel.SetActive(true);
    }
    public void CancelNotEnoughLuxor()
    {
        Time.timeScale = 1f;
        NotEnoughLuxorPanel.SetActive(false);
    }
   public void loadAnubisKarnakPanel()
    {
        AnubisKarnakPanel.SetActive(true);
    }
    public void CancelAnubisKarnak()
    {
        AnubisKarnakPanel.SetActive(false);
    }
     public void loadNotEnoughSinaiPanel()
    {
        Time.timeScale = 0f;
        NotEnoughScoreSinaiPanel.SetActive(true);
    }
    public void CancelNotEnoughSinai()
    {
        Time.timeScale = 1f;
        NotEnoughScoreSinaiPanel.SetActive(false);
    }

    public void loadSinaiPanel()
    {
        Time.timeScale = 0f;
        SinaiPanel.SetActive(true);
    }
    public void SinaiButton()
    {
        Time.timeScale = 1f;
        gameManager.SainiaIsVisited();
        SceneManager.LoadScene("Moses");
    }
    public void CancelSinai()
    {
        Time.timeScale = 1f;
        SinaiPanel.SetActive(false);
    }
    public void LoadNobiPanel(){
        Time.timeScale = 0f;
        myAudioSource.clip = NobiClip;
        myAudioSource.Play();
        NobiPanel.SetActive(true);
    }
    public void closeNobiPanel(){
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        NobiPanel.SetActive(false);
    }
    public void LoadPriestPanel(){
        Time.timeScale = 0f;
        myAudioSource.clip = PriestClip;
        myAudioSource.Play();
        PriestPanel.SetActive(true);
    }
    public void closePriestPanel(){
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        PriestPanel.SetActive(false);
    }
    public void LoadNobelPanel(){
        Time.timeScale = 0f;
        myAudioSource.clip = NobelClip;
        myAudioSource.Play();
        NobelPanel.SetActive(true);
    }
    public void closeNobelPanel(){
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        NobelPanel.SetActive(false);
    }
     public void LoadSoldierPanel(){
        Time.timeScale = 0f;
        myAudioSource.clip = SoldierClip;
        myAudioSource.Play();
        SoldierPanel.SetActive(true);
    }
    public void closeSoldierPanel(){
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        SoldierPanel.SetActive(false);
    }
     public void LoadFarmerPanel(){
        Time.timeScale = 0f;
        myAudioSource.clip = FarmerClip;
        myAudioSource.Play();
        FarmerPanel.SetActive(true);
    }
    public void closeFarmerPanel(){
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        FarmerPanel.SetActive(false);
    }
      public void LoadKingPanel(){
        Time.timeScale = 0f;
        myAudioSource.clip = KingClip;
        myAudioSource.Play();
        KingPanel.SetActive(true);
    }
    public void closeKingPanel(){
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        KingPanel.SetActive(false);
    }
    public void LoadWestSidePanel(){
        Time.timeScale = 0f;
        myAudioSource.clip = WestSideClip;
        myAudioSource.Play();
        WestSidePanel.SetActive(true);
    }
    public void closeWestSidePanel(){
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        WestSidePanel.SetActive(false);
    }
    public void LoadWheatPanel(){
        Time.timeScale = 0f;
        myAudioSource.clip = WheatClip;
        myAudioSource.Play();
       WheatPanel.SetActive(true);
    }
    public void closeWheatPanel(){
        Time.timeScale = 1f;
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        WheatPanel.SetActive(false);
    }
}
