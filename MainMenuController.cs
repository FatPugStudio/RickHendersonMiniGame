using System.Collections;
using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour

{
    // rewired

    private int playerId = 0; // player id
    private Player player; // rewired player
    private bool down = false; // button down
    private bool up = false; // button up
    private bool left = false; // button left
    private bool right = false; // button right
    private bool fire = false; // button fire
    private bool back = false; // button back

    //Menu Game Objects

    public GameObject mainMenu;
    public GameObject shipSelectionMenu;
    public GameObject deathMenu;
    public GameObject pauseMenu;
    public GameObject leaderboardsMenu;
    public GameObject optionsMenu;

    [SerializeField] public SpriteRenderer selectedShipImage;

    public Sprite rickShip; // Rick's ship
    public Sprite benShip; // Ben's ship
    public Sprite thoraxxShip; // Thoraxx's ship

    //Main Menu
    [SerializeField] private bool startGameSelected = false; // start game selected
    [SerializeField] private bool optionsSelected = false; // options selected
    [SerializeField] private bool quitSelected = false; // quit selected
    [SerializeField] private bool leaderboardsSelected = false; // leaderboards selected

    //Main Menu Options
    [SerializeField] private bool volumeSelected = false; // volume selected
    [SerializeField] private bool backgroundSelected = false; // background selected

    //Pause Menu Options
    [SerializeField] private bool resumeSelected = false; // resume selected
    [SerializeField] private bool restartPauseMenuSelected = false; // restart selected
    [SerializeField] private bool optionsPauseMenuSelected = false; // options selected
    [SerializeField] private bool mainMenuPauseMenuSelected = false; // main menu selected

    //Death Menu Options

    [SerializeField] private bool restartDeathMenuSelected; // restart selected
    [SerializeField] private bool leaderboardsDeathMenuSelected; // leaderboards selected
    [SerializeField] private bool mainMenuDeathMenuSelected; // main menu selected

    //Ship Selection
    [SerializeField] private bool rickSelected = false;
    [SerializeField] private bool benSelected = false;
    [SerializeField] private bool thoraxxSelected = false;

    //Menu Colors
    public Color highlightedColor = Color.clear;
    public Color dimmedColor = Color.clear;

    //Main Menu Buttons
    public GameObject startGameButton;
    public GameObject leaderboardsButtonMainMenu;
    public GameObject optionsButton;
    public GameObject quitButton;

    //Ship Selection Items
    public GameObject pilotName;
    public GameObject movementSpeed;
    public GameObject rotationSpeed;
    public GameObject health;
    public GameObject ammo;
    public GameObject shieldDuration;

    //Death Menu Buttons
    public GameObject leaderboardsButtonDeathMenu;
    public GameObject restartButtonDeathMenu;
    public GameObject mainMenuButtonDeathMenu;
    public GameObject resumeGameButton;

    //Pause Menu Buttons
    public GameObject restartButtonPauseMenu;
    public GameObject optionsPauseButton;
    public GameObject mainMenuButtonPauseMenu;
    public GameObject volumeButton;
    public GameObject backgroundButton;

    //Options Menu Buttons

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

    public static int bombs;

    private void Awake()

    {
        pauseMenu.SetActive(false); // set pause menu to false
        deathMenu.gameObject.SetActive(false); // set death menu to false
        optionsMenu.gameObject.SetActive(false); // set options menu to false
        shipSelectionMenu.gameObject.SetActive(false); // set ship selection menu to false
        leaderboardsMenu.gameObject.SetActive(false); // set leaderboards menu to false
        shipSelectionMenu.gameObject.SetActive(false); // set ship selection menu to false
        EventManager.OnGamePauseEvent += GamePause; // add event listener
    }

    private void Start()

    {
        startGameSelected = true;

        //Get PlayerId

        player = ReInput.players.GetPlayer(playerId); // Get the Rewired Player object for this player.

        //Get TMP components

        startGameButtonTMP = startGameButton.GetComponent<TMPro.TextMeshProUGUI>();
        leaderboardsButtonMainMenuTMP = leaderboardsButtonMainMenu.GetComponent<TMPro.TextMeshProUGUI>();
        optionsButtonTMP = optionsButton.GetComponent<TMPro.TextMeshProUGUI>();
        quitButtonTMP = quitButton.GetComponent<TMPro.TextMeshProUGUI>();
        pilotNameTMP = pilotName.GetComponent<TMPro.TextMeshProUGUI>();
        movementSpeedTMP = movementSpeed.GetComponent<TMPro.TextMeshProUGUI>();
        rotationSpeedTMP = rotationSpeed.GetComponent<TMPro.TextMeshProUGUI>();
        healthTMP = health.GetComponent<TMPro.TextMeshProUGUI>();
        ammoTMP = ammo.GetComponent<TMPro.TextMeshProUGUI>();
        shieldDurationTMP = shieldDuration.GetComponent<TMPro.TextMeshProUGUI>();
        leaderboardsButtonDeathMenuTMP = leaderboardsButtonDeathMenu.GetComponent<TMPro.TextMeshProUGUI>();
        restartButtonDeathMenuTMP = restartButtonDeathMenu.GetComponent<TMPro.TextMeshProUGUI>();
        mainMenuButtonDeathMenuTMP = mainMenuButtonDeathMenu.GetComponent<TMPro.TextMeshProUGUI>();
        resumeGameButtonTMP = resumeGameButton.GetComponent<TMPro.TextMeshProUGUI>();
        restartButtonPauseMenuTMP = restartButtonPauseMenu.GetComponent<TMPro.TextMeshProUGUI>();
        optionsPauseButtonTMP = optionsPauseButton.GetComponent<TMPro.TextMeshProUGUI>();
        mainMenuButtonPauseMenuTMP = mainMenuButtonPauseMenu.GetComponent<TMPro.TextMeshProUGUI>();
        volumeButtonTMP = volumeButton.GetComponent<TMPro.TextMeshProUGUI>();
        backgroundButtonTMP = backgroundButton.GetComponent<TMPro.TextMeshProUGUI>();

        MainMenu();
    }

    private void OnEnable()

    {
        selectedShipImage.enabled = false; // set selected ship image to false
    }

    private void MainMenu()

    {

    }

    void GamePause()

    {

    }

    private void Update()

    {

        GetInput();
        ProcessInput(); // greška
    }

    void GetInput()

    {

        down = player.GetButtonDown("Brake"); // get brake button
        up = player.GetButtonDown("Boost"); // get boost button
        left = player.GetButtonDown("Left"); // get left button
        right = player.GetButtonDown("Right"); // get right button
        fire = player.GetButtonDown("Fire"); // get fire button
        back = player.GetButtonDown("Escape"); // get escape button

    }

    void ProcessInput()

    {

        #region Main Menu

        if (GlobalsManager.gameState == GameState.MainMenu)

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
                    GlobalsManager.gameState = GameState.ShipSelection;
                    startGameSelected = false;
                    selectedShipImage.enabled = true;
                    rickSelected = true;
                    benSelected = false;
                    thoraxxSelected = false;

                    //Set stats
                    selectedShipImage.sprite = rickShip;
                    pilotNameTMP.SetText("RICK HENDERSON", false);
                    movementSpeedTMP.SetText("RICK MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText("RICK ROTATION SPEED", false);
                    healthTMP.SetText("RICK HEALTH", false);
                    ammoTMP.SetText("RICK AMMO", false);
                    shieldDurationTMP.SetText("RICK SHIELD DURATION", false);
                    GlobalsManager.bombs = 2;

                    //Activate Menu Elements
                    mainMenu.SetActive(false);
                    shipSelectionMenu.SetActive(true);

                }

                else if (leaderboardsSelected)

                {
                    GlobalsManager.gameState = GameState.Leaderboards;

                    //Activate Menu Elements
                    leaderboardsMenu.SetActive(true);
                    mainMenu.SetActive(false);
                }

                else if (optionsSelected)

                {
                    GlobalsManager.gameState = GameState.OptionsMenu;

                    //Activate Menu Elements
                    optionsMenu.SetActive(true);
                    mainMenu.SetActive(false);

                    volumeButtonTMP.color = highlightedColor;
                    volumeSelected = true;
                    optionsSelected = false;
                }

                else if (quitSelected)

                {
                    Application.Quit();
                }

            }

        }

        #endregion

        #region Options Menu

        else if (GlobalsManager.gameState == GameState.OptionsMenu)

        {
            GlobalsManager.gameState = GameState.MainMenu;

            //Activate Menu Elements
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);

            //uradi gore dole levo desno i back
        }

        #endregion

        #region Ship Selection Menu

        else if (GlobalsManager.gameState == GameState.ShipSelection)

        {
            if (left)

            {

                if (benSelected)

                {
                    //If ben selected and press left, select thoraxx

                    GlobalsManager.shipSelected = ShipSelected.Thoraxx;
                    rickSelected = false;
                    benSelected = false;
                    thoraxxSelected = true;
                    selectedShipImage.sprite = thoraxxShip;
                    pilotNameTMP.SetText("THORAXX", false);
                    movementSpeedTMP.SetText("THORAXX MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText("THORAXX ROTATION SPEED", false);
                    healthTMP.SetText("THORAXX HEALTH", false);
                    ammoTMP.SetText("THORAXX AMMO", false);
                    shieldDurationTMP.SetText("THORAXX SHIELD DURATION", false);
                    GlobalsManager.bombs = 3;

                }

                else if (rickSelected)

                {
                    //if rick selected and press left, select ben

                    GlobalsManager.shipSelected = ShipSelected.Ben;
                    rickSelected = false;
                    benSelected = true;
                    thoraxxSelected = false;
                    selectedShipImage.sprite = benShip;
                    pilotNameTMP.SetText("BEN X9", false);
                    movementSpeedTMP.SetText("BEN MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText("BEN ROTATION SPEED", false);
                    healthTMP.SetText("BEN HEALTH", false);
                    ammoTMP.SetText("BEN AMMO", false);
                    shieldDurationTMP.SetText("BEN SHIELD DURATION", false);
                    GlobalsManager.bombs = 1;
                }

                else if (thoraxxSelected)

                {
                    //if thoraxx selected and press left, select rick

                    GlobalsManager.shipSelected = ShipSelected.Rick;
                    rickSelected = true;
                    benSelected = false;
                    thoraxxSelected = false;
                    selectedShipImage.sprite = rickShip;
                    pilotNameTMP.SetText("RICK HENDERSON", false);
                    movementSpeedTMP.SetText("RICK MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText("RICK ROTATION SPEED", false);
                    healthTMP.SetText("RICK HEALTH", false);
                    ammoTMP.SetText("RICK AMMO", false);
                    shieldDurationTMP.SetText("RICK SHIELD DURATION", false);
                    GlobalsManager.bombs = 2;
                }
            }

            else if (right)

            {
                if (benSelected)

                {
                    //if ben selected and press right, select rick

                    GlobalsManager.shipSelected = ShipSelected.Rick;
                    rickSelected = true;
                    benSelected = false;
                    thoraxxSelected = false;
                    selectedShipImage.sprite = rickShip;
                    pilotNameTMP.SetText("RICK HENDERSON", false);
                    movementSpeedTMP.SetText("RICK MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText("RICK ROTATION SPEED", false);
                    healthTMP.SetText("RICK HEALTH", false);
                    ammoTMP.SetText("RICK AMMO", false);
                    shieldDurationTMP.SetText("RICK SHIELD DURATION", false);
                    GlobalsManager.bombs = 2;
                }

                else if (rickSelected)

                {
                    //if rick selected and press right, select thoraxx

                    GlobalsManager.shipSelected = ShipSelected.Thoraxx;
                    rickSelected = false;
                    benSelected = false;
                    thoraxxSelected = true;
                    selectedShipImage.sprite = thoraxxShip;
                    pilotNameTMP.SetText("THORAXX", false);
                    movementSpeedTMP.SetText("THORAXX MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText("THORAXX ROTATION SPEED", false);
                    healthTMP.SetText("THORAXX HEALTH", false);
                    ammoTMP.SetText("THORAXX AMMO", false);
                    shieldDurationTMP.SetText("THORAXX SHIELD DURATION", false);
                    Debug.LogError("Ship Selected is " + GlobalsManager.shipSelected);
                    GlobalsManager.bombs = 3;
                }

                else if (thoraxxSelected)

                {
                    //if thoraxx selected and press right, select ben

                    GlobalsManager.shipSelected = ShipSelected.Ben;
                    benSelected = true;
                    thoraxxSelected = false;
                    selectedShipImage.sprite = benShip;
                    pilotNameTMP.SetText("BEN X9", false);
                    movementSpeedTMP.SetText("BEN MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText("BEN ROTATION SPEED", false);
                    healthTMP.SetText("BEN HEALTH", false);
                    ammoTMP.SetText("BEN AMMO", false);
                    shieldDurationTMP.SetText("BEN SHIELD DURATION", false);
                    Debug.LogError("Ship Selected is " + GlobalsManager.shipSelected);
                    GlobalsManager.bombs = 1;
                }
            }

            else if (fire)

            {
                GlobalsManager.gameState = GameState.Game;
                shipSelectionMenu.SetActive(false);
                EventManager.OnGameStartEventBroadcast();
            }

            else if (back)

            {
                GlobalsManager.gameState = GameState.MainMenu;
                shipSelectionMenu.SetActive(false);
                mainMenu.SetActive(true);
            }

        }

        #endregion

        #region Leaderboards

        else if (GlobalsManager.gameState == GameState.Leaderboards)

        {
            leaderboardsMenu.SetActive(false);
            mainMenu.SetActive(true);

            if (back)

            {
                leaderboardsMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
        }

        #endregion

        #region Pause Menu

        else if (GlobalsManager.gameState == GameState.PauseMenu)

        {

            if (up)

            {

                if (resumeSelected)

                {
                    mainMenuButtonPauseMenuTMP.color = highlightedColor;
                    resumeGameButtonTMP.color = dimmedColor;
                    mainMenuPauseMenuSelected = true;
                    resumeSelected = false;
                }

                else if (restartPauseMenuSelected)

                {
                    resumeGameButtonTMP.color = highlightedColor;
                    restartButtonPauseMenuTMP.color = dimmedColor;
                    resumeSelected = true;
                    restartPauseMenuSelected = false;
                }

                else if (optionsPauseMenuSelected)

                {
                    restartButtonPauseMenuTMP.color = highlightedColor;
                    optionsPauseButtonTMP.color = dimmedColor;
                    restartPauseMenuSelected = true;
                    optionsPauseMenuSelected = false;
                }

                else if (mainMenuPauseMenuSelected)

                {
                    optionsPauseButtonTMP.color = highlightedColor;
                    mainMenuButtonPauseMenuTMP.color = dimmedColor;
                    optionsPauseMenuSelected = true;
                    mainMenuPauseMenuSelected = false;
                }
            }

            if (down)

            {
                if (resumeSelected)

                {
                    resumeGameButtonTMP.color = dimmedColor;
                    restartButtonPauseMenuTMP.color = highlightedColor;
                    restartPauseMenuSelected = true;
                    resumeSelected = false;

                }

                else if (restartPauseMenuSelected)

                {
                    restartButtonPauseMenuTMP.color = dimmedColor;
                    optionsPauseButtonTMP.color = highlightedColor;
                    optionsPauseMenuSelected = true;
                    restartPauseMenuSelected = false;
                }

                else if (optionsPauseMenuSelected)

                {
                    optionsPauseButtonTMP.color = dimmedColor;
                    mainMenuButtonPauseMenuTMP.color = highlightedColor;
                    mainMenuPauseMenuSelected = true;
                    optionsPauseMenuSelected = false;
                }

                else if (mainMenuPauseMenuSelected)

                {
                    mainMenuButtonPauseMenuTMP.color = dimmedColor;
                    resumeGameButtonTMP.color = highlightedColor;
                    mainMenuPauseMenuSelected = false;
                    resumeSelected = true;
                }
            }

            if (back)

            {
                resumeGameButtonTMP.color = dimmedColor;
                restartButtonPauseMenuTMP.color = dimmedColor;
                optionsPauseButtonTMP.color = dimmedColor;
                mainMenuButtonPauseMenuTMP.color = dimmedColor;

                resumeSelected = false;
                restartPauseMenuSelected = false;
                optionsPauseMenuSelected = false;
                mainMenuPauseMenuSelected = false;

                EventManager.OnGameResumeEventBroadcast();
                pauseMenu.SetActive(false);
                GlobalsManager.gameState = GameState.Game;
                Time.timeScale = 1;
            }

            if (fire)

            {
                if (resumeSelected)

                {
                    resumeGameButtonTMP.color = dimmedColor;
                    restartButtonPauseMenuTMP.color = dimmedColor;
                    optionsPauseButtonTMP.color = dimmedColor;
                    mainMenuButtonPauseMenuTMP.color = dimmedColor;

                    resumeSelected = false;
                    restartPauseMenuSelected = false;
                    optionsPauseMenuSelected = false;
                    mainMenuPauseMenuSelected = false;

                    EventManager.OnGameResumeEventBroadcast();
                    pauseMenu.SetActive(false);
                    GlobalsManager.gameState = GameState.Game;
                    Time.timeScale = 1;

                }

                else if (restartPauseMenuSelected)

                {
                    resumeGameButtonTMP.color = dimmedColor;
                    restartButtonPauseMenuTMP.color = dimmedColor;
                    optionsPauseButtonTMP.color = dimmedColor;
                    mainMenuButtonPauseMenuTMP.color = dimmedColor;

                    resumeSelected = false;
                    restartPauseMenuSelected = false;
                    optionsPauseMenuSelected = false;
                    mainMenuPauseMenuSelected = false;

                    EventManager.OnGameRestartEventBroadcast();
                    pauseMenu.SetActive(false);
                    GlobalsManager.gameState = GameState.Game;
                    Time.timeScale = 1;

                    //reset health
                    //reset ammo
                    //reset guns
                    //reset active pickups
                    //reset arrays
                    //reset shield

                }

                else if (optionsPauseMenuSelected)

                {
                    //go to options
                }

                else if (mainMenuPauseMenuSelected)

                {
                    mainMenuButtonPauseMenuTMP.color = dimmedColor;

                    selectedShipImage.enabled = false;
                    EventManager.OnDespawnEverythingEventBroadcast();
                    EventManager.OnBackToMainMenuEventBroadcast();
                    pauseMenu.SetActive(false);
                    mainMenu.SetActive(true);
                    GlobalsManager.gameState = GameState.MainMenu;
                    Time.timeScale = 1;
                    Start();
                }
            }

        }

        #endregion

        #region Game

        else if (GlobalsManager.gameState == GameState.Game)

        {
            if (back)

            {
                EventManager.OnGamePauseEventBroadcast();
                pauseMenu.SetActive(true);
                GlobalsManager.gameState = GameState.PauseMenu;
                Time.timeScale = 0;
                resumeGameButtonTMP.color = highlightedColor;
                resumeSelected = true;
            }

        }

        else if (GlobalsManager.gameState == GameState.DeathMenu)

        {

        }

        else if (GlobalsManager.gameState == GameState.ShipSelection)

        {
            if (back)

            {
                startGameSelected = true;
                selectedShipImage.enabled = false;
                GlobalsManager.gameState = GameState.MainMenu;
                shipSelectionMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
        }

        #endregion

    }
}
