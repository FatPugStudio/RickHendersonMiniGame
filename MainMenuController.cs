using System.Collections;
using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    private int playerId = 0;
    private Player player;

    private bool down;
    private bool up;
    private bool left;
    private bool right;
    private bool fire;
    private bool back;

    public GameObject mainMenu;
    public GameObject shipSelectionMenu;
    public GameObject deathMenu;
    public GameObject pauseMenu;
    public GameObject leaderboardsMenu;
    public GameObject optionsMenu;

    public SpriteRenderer selectedShipImage;
    public Sprite rickShip;
    public Sprite benShip;
    public Sprite thoraxxShip;

    bool startGameSelected;
    bool optionsSelected;
    bool quitSelected;
    bool leaderboardsSelected;
    bool rickSelected;
    bool benSelected;
    bool thoraxxSelected;

    //Colors

    public Color highlightedColor;
    public Color dimmedColor;

    //Main Menu

    // private Canvas mainMenuCanvasCanvas;
    // public GameObject mainMenuCanvas;
    public GameObject startGameButton;
    public GameObject leaderboardsButtonMainMenu;
    public GameObject optionsButton;
    public GameObject quitButton;

    //Ship Selection

    // private Canvas shipSelectionCanvasCanvas;
    // public GameObject shipSelectionCanvas;
    public GameObject pilotName;
    public GameObject movementSpeed;
    public GameObject rotationSpeed;
    public GameObject health;
    public GameObject ammo;
    public GameObject shieldDuration;

    //Death Menu

    // private Canvas deathMenuCanvasCanvas;
    // public GameObject deathMenuCanvas;
    public GameObject leaderboardsButtonDeathMenu;
    public GameObject restartButtonDeathMenu;
    public GameObject mainMenuButtonDeathMenu;

    //Pause Menu

    // private Canvas pauseMenuCanvasCanvas;
    //public GameObject pauseMenuCanvas;
    public GameObject resumeGameButton;
    public GameObject restartButtonPauseMenu;
    public GameObject optionsPauseButton;
    public GameObject mainMenuButtonPauseMenu;

    //Leaderboards

    // private Canvas leaderboardCanvasCanvas;

    //Options

    // private Canvas optionsCanvasCanvas;
    // public GameObject optionsCanvas;
    public GameObject volumeButton;
    public GameObject backgroundButton;

    //TMP

    private TextMeshProUGUI startGameButtonTMP;
    private TextMeshProUGUI leaderboardsButtonMainMenuTMP;
    private TextMeshProUGUI optionsButtonTMP;
    private TextMeshProUGUI quitButtonTMP;
    private TextMeshProUGUI pilotNameTMP;
    private TextMeshProUGUI movementSpeedTMP;
    private TextMeshProUGUI rotationSpeedTMP;
    private TextMeshProUGUI healthTMP;
    private TextMeshProUGUI ammoTMP;
    private TextMeshProUGUI shieldDurationTMP;
    private TextMeshProUGUI leaderboardsButtonDeathMenuTMP;
    private TextMeshProUGUI restartButtonDeathMenuTMP;
    private TextMeshProUGUI mainMenuButtonDeathMenuTMP;
    private TextMeshProUGUI resumeGameButtonTMP;
    private TextMeshProUGUI restartButtonPauseMenuTMP;
    private TextMeshProUGUI optionsPauseButtonTMP;
    private TextMeshProUGUI mainMenuButtonPauseMenuTMP;
    private TextMeshProUGUI volumeButtonTMP;
    private TextMeshProUGUI backgroundButtonTMP;

    void Awake ()

    {
        pauseMenu.SetActive (false);
        deathMenu.gameObject.SetActive (false);
        optionsMenu.gameObject.SetActive (false);
        shipSelectionMenu.gameObject.SetActive (false);
        leaderboardsMenu.gameObject.SetActive (false);
        shipSelectionMenu.gameObject.SetActive (false);
    }

    void Start()
    
    {
        startGameSelected = true;

        //Get PlayerId

        player = ReInput.players.GetPlayer (playerId);

        //Get canvas components

        // mainMenuCanvasCanvas = mainMenuCanvas.GetComponent<Canvas> ();
        // shipSelectionCanvasCanvas = shipSelectionCanvas.GetComponent<Canvas> ();
        // deathMenuCanvasCanvas = deathMenuCanvas.GetComponent<Canvas> ();
        // pauseMenuCanvasCanvas = pauseMenuCanvas.GetComponent<Canvas> ();
        // leaderboardCanvasCanvas = leaderboardsCanvas.GetComponent<Canvas> ();
        // optionsCanvasCanvas = optionsCanvas.GetComponent<Canvas> ();

        //Get TMP components

        startGameButtonTMP = startGameButton.GetComponent<TextMeshProUGUI> ();
        leaderboardsButtonMainMenuTMP = leaderboardsButtonMainMenu.GetComponent<TextMeshProUGUI> ();
        optionsButtonTMP = optionsButton.GetComponent<TextMeshProUGUI> ();
        quitButtonTMP = quitButton.GetComponent<TextMeshProUGUI> ();
        pilotNameTMP = pilotName.GetComponent<TextMeshProUGUI> ();
        movementSpeedTMP = movementSpeed.GetComponent<TextMeshProUGUI> ();
        rotationSpeedTMP = rotationSpeed.GetComponent<TextMeshProUGUI> ();
        healthTMP = health.GetComponent<TextMeshProUGUI> ();
        ammoTMP = ammo.GetComponent<TextMeshProUGUI> ();
        shieldDurationTMP = shieldDuration.GetComponent<TextMeshProUGUI> ();
        leaderboardsButtonDeathMenuTMP = leaderboardsButtonDeathMenu.GetComponent<TextMeshProUGUI> ();
        restartButtonDeathMenuTMP = restartButtonDeathMenu.GetComponent<TextMeshProUGUI> ();
        mainMenuButtonDeathMenuTMP = mainMenuButtonDeathMenu.GetComponent<TextMeshProUGUI> ();
        resumeGameButtonTMP = resumeGameButton.GetComponent<TextMeshProUGUI> ();
        restartButtonPauseMenuTMP = restartButtonPauseMenu.GetComponent<TextMeshProUGUI> ();
        optionsPauseButtonTMP = optionsPauseButton.GetComponent<TextMeshProUGUI> ();
        mainMenuButtonPauseMenuTMP = mainMenuButtonPauseMenu.GetComponent<TextMeshProUGUI> ();
        volumeButtonTMP = volumeButton.GetComponent<TextMeshProUGUI> ();
        backgroundButtonTMP = backgroundButton.GetComponent<TextMeshProUGUI> ();
        
        MainMenu ();

    }

    void MainMenu ()

    {

        //Disable all canvases except Main Menu Canvas

        // mainMenuCanvasCanvas.enabled = true;
        // shipSelectionCanvasCanvas.enabled = false;
        // deathMenuCanvasCanvas.enabled = false;
        // pauseMenuCanvasCanvas.enabled = false;
        // leaderboardCanvasCanvas.enabled = false;
        // optionsCanvasCanvas.enabled = false;

        // shipSelectionMenu.SetActive(false);
        // deathMenu.SetActive(false);
        // pauseMenu.SetActive(false);
        // leaderboardsMenu.SetActive(false);
        // optionsMenu.SetActive(false);

    }

    void Update ()

    {
        GetInput ();
        ProcessInput ();

    }

    public void GetInput ()

    {
        down = player.GetButtonDown ("Brake");
        up = player.GetButtonDown ("Boost");
        left = player.GetButtonDown ("Left");
        right = player.GetButtonDown ("Right");
        fire = player.GetButtonDown ("Fire");
        back = player.GetButtonDown ("Escape");
    }

    public void ProcessInput ()

    {

        if (down)

        {
            if (startGameSelected)

            {

                startGameSelected = false;
                quitSelected = false;
                optionsSelected = false;
                leaderboardsSelected = true;
                quitButtonTMP.color = dimmedColor;
                optionsButtonTMP.color = dimmedColor;
                startGameButtonTMP.color = dimmedColor;
                leaderboardsButtonMainMenuTMP.color = highlightedColor;
            } 
            
            else if (leaderboardsSelected)

            {
                startGameSelected = false;
                quitSelected = false;
                optionsSelected = true;
                leaderboardsSelected = false;
                quitButtonTMP.color = dimmedColor;
                optionsButtonTMP.color = highlightedColor;
                startGameButtonTMP.color = dimmedColor;
                leaderboardsButtonMainMenuTMP.color = dimmedColor;
            } 
            
            else if (optionsSelected)

            {
                startGameSelected = false;
                quitSelected = true;
                optionsSelected = false;
                leaderboardsSelected = false;
                quitButtonTMP.color = highlightedColor;
                optionsButtonTMP.color = dimmedColor;
                startGameButtonTMP.color = dimmedColor;
                leaderboardsButtonMainMenuTMP.color = dimmedColor;
            } 
            
            else if (quitSelected)

            {
                startGameSelected = true;
                quitSelected = false;
                optionsSelected = false;
                leaderboardsSelected = false;
                quitButtonTMP.color = dimmedColor;
                optionsButtonTMP.color = dimmedColor;
                startGameButtonTMP.color = highlightedColor;
                leaderboardsButtonMainMenuTMP.color = dimmedColor;
            }
        } 
        
        else if (up)

        {
            if (startGameSelected)

            {

                startGameSelected = false;
                quitSelected = true;
                optionsSelected = false;
                leaderboardsSelected = false;
                quitButtonTMP.color = highlightedColor;
                optionsButtonTMP.color = dimmedColor;
                startGameButtonTMP.color = dimmedColor;
                leaderboardsButtonMainMenuTMP.color = dimmedColor;
            } 
            
            else if (leaderboardsSelected)

            {
                startGameSelected = true;
                quitSelected = false;
                optionsSelected = false;
                leaderboardsSelected = false;
                quitButtonTMP.color = dimmedColor;
                optionsButtonTMP.color = dimmedColor;
                startGameButtonTMP.color = highlightedColor;
                leaderboardsButtonMainMenuTMP.color = dimmedColor;
            } 
            
            else if (optionsSelected)

            {
                startGameSelected = false;
                quitSelected = false;
                optionsSelected = false;
                leaderboardsSelected = true;
                quitButtonTMP.color = dimmedColor;
                optionsButtonTMP.color = dimmedColor;
                startGameButtonTMP.color = dimmedColor;
                leaderboardsButtonMainMenuTMP.color = highlightedColor;
            } 
            
            else if (quitSelected)

            {
                startGameSelected = false;
                quitSelected = false;
                optionsSelected = true;
                leaderboardsSelected = false;
                quitButtonTMP.color = dimmedColor;
                optionsButtonTMP.color = highlightedColor;
                startGameButtonTMP.color = dimmedColor;
                leaderboardsButtonMainMenuTMP.color = dimmedColor;
            }

        } 
        
        else if (fire)

        {
            if (startGameSelected)

            {
                shipSelectionMenu.SetActive (true);
                mainMenu.SetActive (false);
                rickSelected = true;
                benSelected = false;
                thoraxxSelected = false;
                selectedShipImage.sprite = rickShip;
                pilotNameTMP.SetText("RICK HENDERSON");
                Debug.Log("pilot text set");
                movementSpeedTMP.SetText("RICK MOVEMENT SPEED");
                Debug.Log("movement text set");
                rotationSpeedTMP.SetText("RICK ROTATION SPEED");
                Debug.Log("rotation text set");
                healthTMP.SetText("RICK HEALTH");
                Debug.Log("health text set");
                ammoTMP.SetText("RICK AMMO");
                shieldDurationTMP.SetText("RICK SHIELD DURATION");

            } 
            
            else if (leaderboardsSelected) 
            
            {
                leaderboardsMenu.SetActive (true);
                mainMenu.SetActive (false);
            } 
            
            else if (optionsSelected)

            {
                optionsMenu.SetActive (true);
                mainMenu.SetActive (false);
            } 
            
            else if (quitSelected)

            {
                Application.Quit ();
            }

        } 
        
        else if (back)

        {

        } 
        
        else if (left)

        {
            Debug.Log("left pressed");
            
            if (benSelected)

            {
                //If ben selected and press left, select thoraxx

                rickSelected = false;
                benSelected = false;
                thoraxxSelected = true;
                selectedShipImage.sprite = thoraxxShip;
                pilotNameTMP.SetText("THORAXX");
                movementSpeedTMP.SetText("THORAXX MOVEMENT SPEED");
                rotationSpeedTMP.SetText("THORAXX ROTATION SPEED");
                healthTMP.SetText("THORAXX HEALTH");
                ammoTMP.SetText("THORAXX AMMO");
                shieldDurationTMP.SetText("THORAXX SHIELD DURATION");
                

            }

            else if (rickSelected)

            {
                //if rick selected and press left, select ben

                rickSelected = false;
                benSelected = true;
                thoraxxSelected = false;
                selectedShipImage.sprite = benShip;
                pilotNameTMP.SetText("BEN X9");
                movementSpeedTMP.SetText("BEN MOVEMENT SPEED");
                rotationSpeedTMP.SetText("BEN ROTATION SPEED");
                healthTMP.SetText("BEN HEALTH");
                ammoTMP.SetText("BEN AMMO");
                shieldDurationTMP.SetText("BEN SHIELD DURATION");
            }

            else if (thoraxxSelected)


            {
                //if thoraxx selected and press left, select rick

                rickSelected = true;
                benSelected = false;
                thoraxxSelected = false;
                selectedShipImage.sprite = rickShip;
                pilotNameTMP.SetText("RICK HENDERSON");
                movementSpeedTMP.SetText("RICK MOVEMENT SPEED");
                rotationSpeedTMP.SetText("RICK ROTATION SPEED");
                healthTMP.SetText("RICK HEALTH");
                ammoTMP.SetText("RICK AMMO");
                shieldDurationTMP.SetText("RICK SHIELD DURATION");
            }
        } 
        
        else if (right) 
        
        {
            Debug.Log("right pressed");
            
            if (benSelected)

            {
                rickSelected = false;
                benSelected = true;
                thoraxxSelected = false;
                selectedShipImage.sprite = benShip;
                pilotNameTMP.SetText("BEN X9");
                movementSpeedTMP.SetText("BEN MOVEMENT SPEED");
                rotationSpeedTMP.SetText("BEN ROTATION SPEED");
                healthTMP.SetText("BEN HEALTH");
                ammoTMP.SetText("BEN AMMO");
                shieldDurationTMP.SetText("BEN SHIELD DURATION");

            }

            else if (rickSelected)

            {
                rickSelected = true;
                benSelected = false;
                thoraxxSelected = false;
                selectedShipImage.sprite = rickShip;
                pilotNameTMP.SetText("RICK HENDERSON");
                movementSpeedTMP.SetText("RICK MOVEMENT SPEED");
                rotationSpeedTMP.SetText("RICK ROTATION SPEED");
                healthTMP.SetText("RICK HEALTH");
                ammoTMP.SetText("RICK AMMO");
                shieldDurationTMP.SetText("RICK SHIELD DURATION");
            }

            else if (thoraxxSelected)

            {
                rickSelected = false;
                benSelected = false;
                thoraxxSelected = true;
                selectedShipImage.sprite = thoraxxShip;
                pilotNameTMP.SetText("THORAXX");
                movementSpeedTMP.SetText("THORAXX MOVEMENT SPEED");
                rotationSpeedTMP.SetText("THORAXX ROTATION SPEED");
                healthTMP.SetText("THORAXX HEALTH");
                ammoTMP.SetText("THORAXX AMMO");
                shieldDurationTMP.SetText("THORAXX SHIELD DURATION");
            }
        }

    }

}