using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    static int lives =3;
    [SerializeField] private GameObject Palyerpf;
    [SerializeField] private Transform plyerParentTrans;
    [SerializeField] private CameraController cam;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text LivesText;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] GameObject PyramidsPanel;
    [SerializeField] GameObject LuxorPanel;
     [SerializeField] GameObject KarnakWelcomePanel;
     [SerializeField] GameObject LuxorWelcomePanel;
     [SerializeField] GameObject PyramidsWelcomePanel;
    [SerializeField] GameObject NotEnoughLuxorPanel;
    [SerializeField] GameObject AnubisLuxorPanel;[SerializeField] GameObject AnubisKarnakPanel;[SerializeField] GameObject AnubisPyramidsPanel; [SerializeField] GameObject SainaiQuestPanel; 
    [SerializeField] private Text NatronText;
    [SerializeField] private Text OilText;
    [SerializeField] private Text HerbsText;
    [SerializeField] private GameObject MobileController;
    [SerializeField] private GameObject WinPanel;
    private bool isPaused = false;
    private Vector3 diePos;
    private PlayerScript myPlayer;
    private Vector3 ResPos;
    private Vector3 updatePos = Vector3.zero;
    static int Currentscore =0;
    static int CurrentNatron = 0; static int CurrentOil= 0; static int CurrentHerbs = 0;
    static bool LuxorVisited = false, PyramidVisited = false, KarnakVisited = false, SainaiVisited = false;
    private static bool storyStarted = false;
    private StoryTeller storyTeller;
    private MainMenuController mainMenu;
    private AudioSource myAudioSource;
    [SerializeField] AudioClip WinClip;
    static string username;   
    [SerializeField] GameObject UserNamePanel;
    [SerializeField] TextMeshProUGUI userNameInput;
    [SerializeField] private TextMeshProUGUI welcomingKarnak;
    [SerializeField] private TextMeshProUGUI welcomingLuxor;
    [SerializeField] private TextMeshProUGUI welcomingPyramids;
    // Start is called before the first frame update
     void Awake(){
        myAudioSource = GetComponent<AudioSource>();
    storyTeller = FindObjectOfType<StoryTeller>(); 
        if(storyTeller!=null){
            storyTeller.setUsername(username);
        }
        if (SceneManager.GetActiveScene().name == "Karnak"){
        welcomingKarnak.text = "Willkommen " + username + " im Karnak-Tempel";
        }
        if (SceneManager.GetActiveScene().name == "Luxor"){
        welcomingLuxor.text = "Willkommen " + username + " im Luxor-Tempel";
        }
        if (SceneManager.GetActiveScene().name == "Pyramiden"){
        welcomingPyramids.text = "Willkommen " + username + " zu den Pyramiden von Gizeh";
        }
        if (SceneManager.GetActiveScene().name == "LAND" && SainaiVisited)
        {
            ResPos = new Vector3(53.0134201f,1.99999988f,90.289444f);
            if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
            myAudioSource.clip = WinClip;
            myAudioSource.Play();
            WinPanel.SetActive(true);

        }
        
 }
    void Start()
    {
        
        mainMenu = FindObjectOfType<MainMenuController>();
        
        
        if (SceneManager.GetActiveScene().name == "Pyramiden")
        {
            PyramidsWelcomePanel.SetActive(true);
            Time.timeScale = 0f;
            ResPos = new Vector3(-82.2752151f, 1.54999995f, -38);
        }
        else if (SceneManager.GetActiveScene().name == "Luxor")
        {
            LuxorWelcomePanel.SetActive(true);
            Time.timeScale = 0f;
            ResPos = new Vector3(-29.316185f, 1, -27.3425579f);
        }else if (SceneManager.GetActiveScene().name == "Karnak")
        {
            
            KarnakWelcomePanel.SetActive(true);
            Time.timeScale = 0f;
            ResPos = new Vector3(80,1, -27);

        }else if (SceneManager.GetActiveScene().name == "Moses")
        {
            ResPos = new Vector3(1.11472321f,9.29948044f,192.018433f);

        }
        
        else if (SceneManager.GetActiveScene().name == "LAND" && PyramidVisited)
        {
            ResPos = new Vector3(-70, 2, -51);
            Debug.Log("Sinai visited? "+SainaiVisited);
        }else if (SceneManager.GetActiveScene().name == "LAND" && KarnakVisited)
        {
            ResPos = new Vector3(459, 2, 53);
        }
        else
        {
            ResPos = new Vector3(566.004272f, 2, 86.140007f);
        }
        if (!storyStarted && SceneManager.GetActiveScene().name == "LAND")
        {
           
            storyStarted = true;
            
            storyTeller.displayFirstPanel();
        }
     // Vector3(-70, 2, -42);
           if( SceneManager.GetActiveScene().name != "MainMenu"){
            SpawnPlayer();
           }
         
        if(NatronText != null && NatronText != null && NatronText != null) {
            NatronText.text = "Natron : " + CurrentNatron; OilText.text = "Öl : " + CurrentOil; HerbsText.text = "Kräuter : " + CurrentHerbs;

        }
if( SceneManager.GetActiveScene().name != "MainMenu"){ScoreText.text = "Score: " + Currentscore;
        LivesText.text = "Lives: " + lives;}
        
     //   NatronText.text = "Natron : " + CurrentNatron;OilText.text = "�l : " + CurrentOil;HerbsText.text = "Kr�uter : " + CurrentHerbs;

        //Instantiate(Palyerpf, new Vector3(-70, 2, -44), Quaternion.identity, plyerParentTrans);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void PyramidIsVisited()
    {
        if (!PyramidVisited) { PyramidVisited = true; }
    }public void LuxorIsVisited()
    {
        if (!LuxorVisited) { LuxorVisited = true; }
    }public void KarnakIsVisited()
    {
        if (!KarnakVisited) { KarnakVisited = true; }
    }
    public void SainiaIsVisited()
    {
        if (!SainaiVisited) { SainaiVisited = true;  }else Debug.Log(" ");
    }
    public bool wasLuxorVisited(){
        return LuxorVisited;
    }
    public bool wasKarnakVisited(){
        return KarnakVisited;
    }
    public bool wasPyramidsVisited(){
        return PyramidVisited;
    }
    public void IncreaseScore(int n)
    {
        Currentscore=+n;
        ScoreText.text = "Score: " + Currentscore;

    }
    private void UpdateLives()
    {
        lives--;
        LivesText.text = "Lives: " + lives;
    }
    public void playerdied()
    {
        diePos = myPlayer.transform.position;


        if (lives > 1)
        {
            
            Debug.Log("Player died");
            UpdateLives();
            Invoke("SpawnPlayer", 3f);
        }
        else
        {
            UpdateLives();
            ScoreText.text = "Final score: " + Currentscore;
            GameOver();
        }
        
    }
    private void SpawnPlayer()
    {
        
        GameObject Newplayer = (SceneManager.GetActiveScene().name == "Moses")? Instantiate(Palyerpf, ResPos, Quaternion.Euler(0, 255.259476f, 0), plyerParentTrans) : Instantiate(Palyerpf, ResPos, Quaternion.identity, plyerParentTrans);
        cam.setPlayer(Newplayer);   
        myPlayer = Newplayer.GetComponent<PlayerScript>() ;
       
    }
    
    public string getUsername()
    {
        Debug.Log("Second user"+ username);
        return username;
    }
    public void PauseButton()
    {
        if (isPaused)
        {
            PausePanel.SetActive(false);
            isPaused=false;
            Time.timeScale = 1f;
        }
        else
        {
            PausePanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        }
    }

    private void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void loadMainMenu()
    {
        Currentscore = 0;
        lives = 3;
        SceneManager.LoadScene("MainMenu");
        
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
    }public void loadLuxorPanel()
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
    }public void loadAnubisLuxorPanel()
    {
        AnubisLuxorPanel.SetActive(true);
    }
    public void CancelAnubisLuxor()
    {
        AnubisLuxorPanel.SetActive(false);
    }public void loadAnubisKarnakPanel()
    {
        AnubisKarnakPanel.SetActive(true);
    }
    public void CancelAnubisKarnak()
    {
        AnubisKarnakPanel.SetActive(false);
    }public void loadAnubisPyramidsPanel()
    {
        AnubisPyramidsPanel.SetActive(true);
    }
    public void CancelAnubisPyramids()
    {
        AnubisPyramidsPanel.SetActive(false);
    }
    public void loadSainaiQuestPanel()
    {
       SainaiQuestPanel.SetActive(true);
    }
    public void CancelSainaiQuest()
    {
        SainaiQuestPanel.SetActive(false);
    }
    public void SetNatron(int n)
    {
        CurrentNatron = CurrentNatron + n;
     NatronText.text = "Natron : " + (CurrentNatron);
    }
    public void SetOil( int n)
    {
        CurrentOil = CurrentOil + n;
        OilText.text = "Öl : " + (CurrentOil);
    }
    public void SetHerbs(int n)
    {
        CurrentHerbs = CurrentHerbs + n;
        HerbsText.text = "Kräuter : " + (CurrentHerbs);
    }
    public void SetFood(int n)
    {
        CurrentNatron = CurrentNatron + n;
     NatronText.text = "Essen : " + (CurrentNatron);
    }
    public void SetWater( int n)
    {
        CurrentOil = CurrentOil + n;
        OilText.text = "Wasser : " + (CurrentOil);
    }
    public void SetNewHerb(int n)
    {
        CurrentHerbs = CurrentHerbs + n;
        HerbsText.text = "Kräuter : " + (CurrentHerbs);
    }
    public int getNatron()
    {
        return CurrentNatron;
    }
    public int getOil()
    {
        return CurrentOil;
    }
    public int getHerbs()
    {
        return CurrentHerbs;
    }
    public void resetTools()
    {
        CurrentNatron = 0;
        CurrentOil = 0; 
        CurrentHerbs = 0;
        NatronText.text = "Natron : " + CurrentNatron; OilText.text = "Öl : " + CurrentOil; HerbsText.text = "Kräuter : " + CurrentHerbs;

    }
    public void resetToolsSinai()
    {
        CurrentNatron = 0;
        CurrentOil = 0; 
        CurrentHerbs = 0;
        NatronText.text = "Essen : " + CurrentNatron; OilText.text = "Wasser : " + CurrentOil; HerbsText.text = "Kräuter : " + CurrentHerbs;

    }
    public int getCurrentScore()
    {
        return Currentscore;
    }
    public void movingForward()
    {
        myPlayer.moveForward();
    }
    public void stopMovingForward()
    {
        myPlayer.stopMovingForward();
    }
    public void movingBackward()
    {
        myPlayer.moveBackward();
    }
    public void stopMovingBackward()
    {
        myPlayer.stopMovingBackward();
    }
    public void movingRight()
    {
        myPlayer.moveRight();
      //  myPlayer.rotateRight(); 
    }
    public void stopMovingRight()
    {
        myPlayer.stopMovinRight();
    //    myPlayer.stopRotatingRight();
    }
    public void movingLeft()
    {
        myPlayer.moveLeft();
      //  myPlayer.rotateLeft();
    }
    public void stopMovingLeft()
    {
        myPlayer.stopMovingLeft();
    //    myPlayer.stopRotatingLeft();
    }
    public void rotateRight()
    {
        myPlayer.rotateRight(); 
    }
    public void stopRotateRight()
    {
        myPlayer.stopRotatingRight();
    }
    public void rotateLeft()
    {
        myPlayer.rotateLeft();
    }
    public void stopRotateLeft()
    {
        myPlayer.stopRotatingLeft();
    } 
    public void displayMobileConntroller()
    {
        if (!MobileController.activeInHierarchy)
        {
            MobileController.SetActive(true);
        }
        else
        {
            MobileController.SetActive(false);  
        }
    }

    public bool hasAllSinai(){
        if(getOil() == getNatron() && getNatron() == getHerbs() && getHerbs() ==1)
    {
        return true;
    }
    return false;
    }
    public void closeWinPanel(){
        if (myAudioSource.isPlaying)
        {
            myAudioSource.Stop();
        }
        WinPanel.SetActive(false);
    }
    public void closeKarnakWelcomePanel(){
        Time.timeScale = 1f;
        KarnakWelcomePanel.SetActive(false);
    }
   public void closeLuxorWelcomePanel(){
        Time.timeScale = 1f;
        LuxorWelcomePanel.SetActive(false);
    }
    public void closePyramidsWelcomePanel(){
        Time.timeScale = 1f;
        PyramidsWelcomePanel.SetActive(false);
    }
   
   public void UpdateUserName()
    {
        if (!string.IsNullOrEmpty(userNameInput.text))
            username = userNameInput.text;
        else username = " ";
        Debug.Log(username);
    }
    

}
