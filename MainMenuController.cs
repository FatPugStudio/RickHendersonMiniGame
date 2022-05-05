using System.Collections;
using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour

{
    //events & delegates

    public delegate void StartGame();
    public static event StartGame OnGameStart;
    
    // rewired
    
    private int playerId = 0;
    private Player player;
    private bool down = false;
    private bool up = false;
    private bool left = false;
    private bool right = false;
    private bool fire = false;
    private bool back = false;

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

    [SerializeField]
    private bool startGameSelected = false;
    [SerializeField]
    private bool optionsSelected = false;
    [SerializeField]
    private bool quitSelected = false;
    [SerializeField]
    private bool leaderboardsSelected = false;
    [SerializeField]
    private bool volumeSelected = false;
    [SerializeField]
    private bool backgroundSelected = false;
    [SerializeField]
    private bool rickSelected = false;
    [SerializeField]
    private bool benSelected = false;
    [SerializeField]
    private bool thoraxxSelected = false;

    public Color highlightedColor = Color.clear;
    public Color dimmedColor = Color.clear;

    public GameObject startGameButton;
    public GameObject leaderboardsButtonMainMenu;
    public GameObject optionsButton;
    public GameObject quitButton;
    public GameObject pilotName;
    public GameObject movementSpeed;
    public GameObject rotationSpeed;
    public GameObject health;
    public GameObject ammo;
    public GameObject shieldDuration;
    public GameObject leaderboardsButtonDeathMenu;
    public GameObject restartButtonDeathMenu;
    public GameObject mainMenuButtonDeathMenu;
    public GameObject resumeGameButton;
    public GameObject restartButtonPauseMenu;
    public GameObject optionsPauseButton;
    public GameObject mainMenuButtonPauseMenu;
    public GameObject volumeButton;
    public GameObject backgroundButton;

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

    private void Awake ()

    {
        pauseMenu.SetActive (false);
        deathMenu.gameObject.SetActive (false);
        optionsMenu.gameObject.SetActive (false);
        shipSelectionMenu.gameObject.SetActive (false);
        leaderboardsMenu.gameObject.SetActive (false);
        shipSelectionMenu.gameObject.SetActive (false);
    }

    private void Start ()

    {   
        startGameSelected = true;

        //Get PlayerId

        player = ReInput.players.GetPlayer (playerId);

        //Get canvas components

        //mainMenuCanvasCanvas = mainMenuCanvas.GetComponent<Canvas> ();
        //shipSelectionCanvasCanvas = shipSelectionCanvas.GetComponent<Canvas> ();
        //deathMenuCanvasCanvas = deathMenuCanvas.GetComponent<Canvas> ();
        //pauseMenuCanvasCanvas = pauseMenuCanvas.GetComponent<Canvas> ();
        //leaderboardCanvasCanvas = leaderboardsCanvas.GetComponent<Canvas> ();
        //optionsCanvasCanvas = optionsCanvas.GetComponent<Canvas> ();

        //Get TMP components

        startGameButtonTMP = startGameButton.GetComponent<TMPro.TextMeshProUGUI> ();
        leaderboardsButtonMainMenuTMP = leaderboardsButtonMainMenu.GetComponent<TMPro.TextMeshProUGUI> ();
        optionsButtonTMP = optionsButton.GetComponent<TMPro.TextMeshProUGUI> ();
        quitButtonTMP = quitButton.GetComponent<TMPro.TextMeshProUGUI> ();
        pilotNameTMP = pilotName.GetComponent<TMPro.TextMeshProUGUI> ();
        movementSpeedTMP = movementSpeed.GetComponent<TMPro.TextMeshProUGUI> ();
        rotationSpeedTMP = rotationSpeed.GetComponent<TMPro.TextMeshProUGUI> ();
        healthTMP = health.GetComponent<TMPro.TextMeshProUGUI> ();
        ammoTMP = ammo.GetComponent<TMPro.TextMeshProUGUI> ();
        shieldDurationTMP = shieldDuration.GetComponent<TMPro.TextMeshProUGUI> ();
        leaderboardsButtonDeathMenuTMP = leaderboardsButtonDeathMenu.GetComponent<TMPro.TextMeshProUGUI> ();
        restartButtonDeathMenuTMP = restartButtonDeathMenu.GetComponent<TMPro.TextMeshProUGUI> ();
        mainMenuButtonDeathMenuTMP = mainMenuButtonDeathMenu.GetComponent<TMPro.TextMeshProUGUI> ();
        resumeGameButtonTMP = resumeGameButton.GetComponent<TMPro.TextMeshProUGUI> ();
        restartButtonPauseMenuTMP = restartButtonPauseMenu.GetComponent<TMPro.TextMeshProUGUI> ();
        optionsPauseButtonTMP = optionsPauseButton.GetComponent<TMPro.TextMeshProUGUI> ();
        mainMenuButtonPauseMenuTMP = mainMenuButtonPauseMenu.GetComponent<TMPro.TextMeshProUGUI> ();
        volumeButtonTMP = volumeButton.GetComponent<TMPro.TextMeshProUGUI> ();
        backgroundButtonTMP = backgroundButton.GetComponent<TMPro.TextMeshProUGUI> ();

        MainMenu ();
    }

    private void MainMenu ()

    {

    }

    private void Update ()

    {
        GetInput ();
        ProcessInput ();
    }

    void GetInput ()

    {
        // if (GlobalsManager.gameState != GameState.Game)

        // {
            
        down = player.GetButtonDown ("Brake");
        up = player.GetButtonDown ("Boost");
        left = player.GetButtonDown ("Left");
        right = player.GetButtonDown ("Right");
        fire = player.GetButtonDown ("Fire");
        back = player.GetButtonDown ("Escape");
        
        // }

    }

    void ProcessInput () 
    
    {
        
        if (GlobalsManager.gameState != GameState.Game)
        
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

            else if (volumeSelected)

            {
                volumeSelected = false;
                backgroundSelected = true;
                volumeButtonTMP.color = dimmedColor;
                backgroundButtonTMP.color = highlightedColor;
            }

            else if (backgroundSelected)

            {
                backgroundSelected = false;
                volumeSelected = true;
                volumeButtonTMP.color = highlightedColor;
                backgroundButtonTMP.color = dimmedColor;
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

            else if (volumeSelected)

            {
                volumeSelected = false;
                backgroundSelected = true;
                volumeButtonTMP.color = dimmedColor;
                backgroundButtonTMP.color = highlightedColor;
            }

            else if (backgroundSelected)

            {
                backgroundSelected = false;
                volumeSelected = true;
                volumeButtonTMP.color = highlightedColor;
                backgroundButtonTMP.color = dimmedColor;
            }
        } 
        
        else if (fire)

        {
            if (startGameSelected)

            {
                startGameSelected = false;
                shipSelectionMenu.SetActive (true);
                mainMenu.SetActive (false);
                rickSelected = true;
                benSelected = false;
                thoraxxSelected = false;
                selectedShipImage.sprite = rickShip;
                pilotNameTMP.SetText ("RICK HENDERSON", false);
                Debug.Log ("pilot text set");
                movementSpeedTMP.SetText ("RICK MOVEMENT SPEED", false);
                Debug.Log ("movement text set");
                rotationSpeedTMP.SetText ("RICK ROTATION SPEED", false);
                Debug.Log ("rotation text set");
                healthTMP.SetText ("RICK HEALTH", false);
                Debug.Log ("health text set");
                ammoTMP.SetText ("RICK AMMO", false);
                shieldDurationTMP.SetText ("RICK SHIELD DURATION", false);

            } 
            
            else if (leaderboardsSelected)

            {
                GlobalsManager.gameState = GameState.Leaderboards;
                leaderboardsMenu.SetActive (true);
                mainMenu.SetActive (false);
            } 
            
            else if (optionsSelected) 
            
            {
                GlobalsManager.gameState = GameState.OptionsMenu;
                optionsMenu.SetActive (true);
                mainMenu.SetActive (false);
                volumeButtonTMP.color = highlightedColor;
                volumeSelected = true;
                optionsSelected = false;
            } 
            
            else if (quitSelected)

            {
                Application.Quit ();

            }

            else if (rickSelected || benSelected || thoraxxSelected)
            
            {
                rickSelected = false;
                benSelected = false;
                thoraxxSelected = false;

                GlobalsManager.gameState = GameState.Game;
                shipSelectionMenu.SetActive(false);                
                
                //send OnGameStart event to subscribers

                if (OnGameStart != null)
                
                {
                    OnGameStart();
                }
            }

        } 
        
        else if (left)

        {
            if (benSelected)

            {
                //If ben selected and press left, select thoraxx

                GlobalsManager.shipSelected = ShipSelected.Ben;
                rickSelected = false;
                benSelected = false;
                thoraxxSelected = true;
                selectedShipImage.sprite = thoraxxShip;
                pilotNameTMP.SetText ("THORAXX", false);
                movementSpeedTMP.SetText ("THORAXX MOVEMENT SPEED", false);
                rotationSpeedTMP.SetText ("THORAXX ROTATION SPEED", false);
                healthTMP.SetText ("THORAXX HEALTH", false);
                ammoTMP.SetText ("THORAXX AMMO", false);
                shieldDurationTMP.SetText ("THORAXX SHIELD DURATION", false);
            } 
            
            else if (rickSelected)

            {
                //if rick selected and press left, select ben

                GlobalsManager.shipSelected = ShipSelected.Rick;
                rickSelected = false;
                benSelected = true;
                thoraxxSelected = false;
                selectedShipImage.sprite = benShip;
                pilotNameTMP.SetText ("BEN X9", false);
                movementSpeedTMP.SetText ("BEN MOVEMENT SPEED", false);
                rotationSpeedTMP.SetText ("BEN ROTATION SPEED", false);
                healthTMP.SetText ("BEN HEALTH", false);
                ammoTMP.SetText ("BEN AMMO", false);
                shieldDurationTMP.SetText ("BEN SHIELD DURATION", false);
            } 
            
            else if (thoraxxSelected)

            {
                //if thoraxx selected and press left, select rick

                GlobalsManager.shipSelected = ShipSelected.Thoraxx;
                rickSelected = true;
                benSelected = false;
                thoraxxSelected = false;
                selectedShipImage.sprite = rickShip;
                pilotNameTMP.SetText ("RICK HENDERSON", false);
                movementSpeedTMP.SetText ("RICK MOVEMENT SPEED", false);
                rotationSpeedTMP.SetText ("RICK ROTATION SPEED", false);
                healthTMP.SetText ("RICK HEALTH", false);
                ammoTMP.SetText ("RICK AMMO", false);
                shieldDurationTMP.SetText ("RICK SHIELD DURATION", false);
            }

        } 
        
        else if (right)

        {
            if (benSelected)

            {
                //if ben selected and press right, select rick

                GlobalsManager.shipSelected = ShipSelected.Ben;
                rickSelected = true;
                benSelected = false;
                thoraxxSelected = false;
                selectedShipImage.sprite = rickShip;
                pilotNameTMP.SetText ("RICK HENDERSON", false);
                movementSpeedTMP.SetText ("RICK MOVEMENT SPEED", false);
                rotationSpeedTMP.SetText ("RICK ROTATION SPEED", false);
                healthTMP.SetText ("RICK HEALTH", false);
                ammoTMP.SetText ("RICK AMMO", false);
                shieldDurationTMP.SetText ("RICK SHIELD DURATION", false);

            } 
            
            else if (rickSelected)

            {
                //if rick selected and press right, select thoraxx

                GlobalsManager.shipSelected = ShipSelected.Ben;
                rickSelected = false;
                benSelected = false;
                thoraxxSelected = true;
                selectedShipImage.sprite = thoraxxShip;
                pilotNameTMP.SetText ("THORAXX", false);
                movementSpeedTMP.SetText ("THORAXX MOVEMENT SPEED", false);
                rotationSpeedTMP.SetText ("THORAXX ROTATION SPEED", false);
                healthTMP.SetText ("THORAXX HEALTH", false);
                ammoTMP.SetText ("THORAXX AMMO", false);
                shieldDurationTMP.SetText ("THORAXX SHIELD DURATION", false);

            } 
            
            else if (thoraxxSelected)

            {
                //if thoraxx selected and press right, select ben

                GlobalsManager.shipSelected = ShipSelected.Thoraxx;
                benSelected = true;
                thoraxxSelected = false;
                selectedShipImage.sprite = benShip;
                pilotNameTMP.SetText ("BEN X9", false);
                movementSpeedTMP.SetText ("BEN MOVEMENT SPEED", false);
                rotationSpeedTMP.SetText ("BEN ROTATION SPEED", false);
                healthTMP.SetText ("BEN HEALTH", false);
                ammoTMP.SetText ("BEN AMMO", false);
                shieldDurationTMP.SetText ("BEN SHIELD DURATION", false);
            }
        }

        else if (back)

        {
            if (GlobalsManager.gameState == GameState.PauseMenu)

            {
                GlobalsManager.gameState = GameState.Game;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }

            else if (GlobalsManager.gameState == GameState.OptionsMenu)

            {
                GlobalsManager.gameState = GameState.MainMenu;
                optionsMenu.SetActive(false);
                mainMenu.SetActive(true);
            }

            else if (GlobalsManager.gameState == GameState.ShipSelection)

            {
                GlobalsManager.gameState = GameState.MainMenu;
                shipSelectionMenu.SetActive(false);
                mainMenu.SetActive(true);
            }

            else if (GlobalsManager.gameState == GameState.Leaderboards)

            {
                GlobalsManager.gameState = GameState.MainMenu;
                leaderboardsMenu.SetActive(false);
                mainMenu.SetActive(true);
            }

            // else if (GlobalsManager.gameState == GameState.Game)

            // {
            //     GlobalsManager.gameState = GameState.PauseMenu;
            //     pauseMenu.SetActive(true);
            //     Time.timeScale = 0;
            // }

        }

    }
        else if (GlobalsManager.gameState == GameState.Game)

        {
            if (back)
            
            {
                GlobalsManager.gameState = GameState.PauseMenu;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }

            
        }
    }

}
