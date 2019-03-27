using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {


    public static GameManager instance = null;

    [SerializeField] private GameObject MainMenu;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;

    public bool PlayerActive() {
         return playerActive;  
    }

    public bool GameOver() {
         return gameOver;  
    }

    public bool GameStarted() {
        return gameStarted;
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(MainMenu);

    }

    // Use this for initialization
    void Start () {
        PlayerStartedGame();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayerCollided() {
        gameOver = true;
        playerActive = false;
    }

    public void PlayerStartedGame() {
        playerActive = true;
    }

    public void EnterGame() {
        MainMenu.SetActive(false);
        gameStarted = true;
    }

    public void Restart() {
        MainMenu.SetActive(true);
        gameOver = false;
        Start();
    }
}
