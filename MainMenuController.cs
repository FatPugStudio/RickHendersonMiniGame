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

    public delegate void StartGame ();
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

    //Menu Game Objects

    public GameObject mainMenu;
    public GameObject shipSelectionMenu;
    public GameObject deathMenu;
    public GameObject pauseMenu;
    public GameObject leaderboardsMenu;
    public GameObject optionsMenu;

    [SerializeField] public SpriteRenderer selectedShipImage;

    public Sprite rickShip;
    public Sprite benShip;
    public Sprite thoraxxShip;

    //Main Menu
    [SerializeField] private bool startGameSelected = false;
    [SerializeField] private bool optionsSelected = false;
    [SerializeField] private bool quitSelected = false;
    [SerializeField] private bool leaderboardsSelected = false;

    //Main Menu Options
    [SerializeField] private bool volumeSelected = false;
    [SerializeField] private bool backgroundSelected = false;

    //Pause Menu Options
    [SerializeField] private bool resumeSelected = false;
    [SerializeField] private bool restartPauseMenuSelected = false;
    [SerializeField] private bool optionsPauseMenuSelected = false;
    [SerializeField] private bool mainMenuPauseMenuSelected = false;

    //Death Menu Options

    [SerializeField] private bool restartDeathMenuSelected;
    [SerializeField] private bool leaderboardsDeathMenuSelected;
    [SerializeField] private bool mainMenuDeathMenuSelected;

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

    private void OnEnable ()

    {
        selectedShipImage.enabled = false;
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

        down = player.GetButtonDown ("Brake");
        up = player.GetButtonDown ("Boost");
        left = player.GetButtonDown ("Left");
        right = player.GetButtonDown ("Right");
        fire = player.GetButtonDown ("Fire");
        back = player.GetButtonDown ("Escape");

    }

    void ProcessInput ()

    {

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
                    pilotNameTMP.SetText ("RICK HENDERSON", false);
                    movementSpeedTMP.SetText ("RICK MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText ("RICK ROTATION SPEED", false);
                    healthTMP.SetText ("RICK HEALTH", false);
                    ammoTMP.SetText ("RICK AMMO", false);
                    shieldDurationTMP.SetText ("RICK SHIELD DURATION", false);

                    //Activate Menu Elements
                    mainMenu.SetActive (false);
                    shipSelectionMenu.SetActive (true);

                }

                else if (leaderboardsSelected)

                {
                    GlobalsManager.gameState = GameState.Leaderboards;

                    //Activate Menu Elements
                    leaderboardsMenu.SetActive (true);
                    mainMenu.SetActive (false);
                }

                else if (optionsSelected)

                {
                    GlobalsManager.gameState = GameState.OptionsMenu;

                    //Activate Menu Elements
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

            }

        }

        #region Options Menu

        else if (GlobalsManager.gameState == GameState.OptionsMenu)

        {
            GlobalsManager.gameState = GameState.MainMenu;

            //Activate Menu Elements
            optionsMenu.SetActive (false);
            mainMenu.SetActive (true);

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

                    GlobalsManager.shipSelected = ShipSelected.Ben;
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

                    GlobalsManager.shipSelected = ShipSelected.Rick;
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

                    GlobalsManager.shipSelected = ShipSelected.Rick;
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

                    GlobalsManager.shipSelected = ShipSelected.Thoraxx;
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
                    Debug.LogError ("Ship Selected is " + GlobalsManager.shipSelected);

                }

                else if (thoraxxSelected)

                {
                    //if thoraxx selected and press right, select ben

                    GlobalsManager.shipSelected = ShipSelected.Ben;
                    benSelected = true;
                    thoraxxSelected = false;
                    selectedShipImage.sprite = benShip;
                    pilotNameTMP.SetText ("BEN X9", false);
                    movementSpeedTMP.SetText ("BEN MOVEMENT SPEED", false);
                    rotationSpeedTMP.SetText ("BEN ROTATION SPEED", false);
                    healthTMP.SetText ("BEN HEALTH", false);
                    ammoTMP.SetText ("BEN AMMO", false);
                    shieldDurationTMP.SetText ("BEN SHIELD DURATION", false);
                    Debug.LogError ("Ship Selected is " + GlobalsManager.shipSelected);
                }
            }

            else if (fire)

            {
                GlobalsManager.gameState = GameState.Game;
                shipSelectionMenu.SetActive (false);

                if (OnGameStart != null)

                {
                    OnGameStart ();
                }
            }

            else if (back)

            {
                GlobalsManager.gameState = GameState.MainMenu;
                shipSelectionMenu.SetActive (false);
                mainMenu.SetActive (true);
            }

        }

        #endregion

        #region Leaderboards

        else if (GlobalsManager.gameState == GameState.Leaderboards)

        {
            leaderboardsMenu.SetActive (false);
            mainMenu.SetActive (true);

            if (back)

            {
                leaderboardsMenu.SetActive (false);
                mainMenu.SetActive (true);
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

                pauseMenu.SetActive (false);
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

                    pauseMenu.SetActive (false);
                    GlobalsManager.gameState = GameState.Game;
                    Time.timeScale = 1;

                }

                else if (restartPauseMenuSelected)

                {
                    //despawn everything
                    //disable pause menu
                    //set state to game
                    //scale time to 1
                    //set player position
                    //set player rotation
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
                    EventManager.DespawnEverythingEvent ();
                    //despawn everything
                    //disable pause menu
                    //enable main menu
                    //set state to main menu
                    //scale time to 1
                }
            }

        }

        #endregion

        #region Game

        else if (GlobalsManager.gameState == GameState.Game)

        {
            if (back)

            {
                pauseMenu.SetActive (true);
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
                shipSelectionMenu.SetActive (false);
                mainMenu.SetActive (true);
            }
        }

        #endregion

    }
}
