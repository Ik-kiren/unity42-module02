using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int maxHP = 5;
    public int currentHP;

    public int currentGold = 5;

    public TMP_Text rankLostText;
    public TMP_Text rankWonText;
    public List<GameObject> ennemies = new();
    public GameObject pauseMenu;
    public GameObject WonMenu;
    public GameObject LostMenu;

    string rank = "F";

    bool isGameRunning = true;
    public bool hasWon = false;
    public bool hasLost = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;
        }
    }

    public void TakeDamage(int hp)
    {
        currentHP -= hp;
        Debug.Log(currentHP);
        if (currentHP == 0)
        {
            isGameRunning = false;
            rankLostText.text = "F";
            hasLost = true;
            LostMenu.SetActive(true);
            Debug.Log("Game Over");
        }
    }

    public int GetHP()
    {
        return currentHP;
    }

    public bool gameRunning()
    {
        return (isGameRunning);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame(GameObject confirmObject)
    {
        confirmObject.SetActive(true);
    }
    
    public void ComfirmQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void NextLevel(SceneAsset scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
    }

    public void WonStage()
    {
        if (currentHP == maxHP)
            rank = "S";
        else if (currentHP < maxHP && currentHP > 3)
            rank = "A";
        else if (currentHP < 3 && currentHP > 0)
            rank = "B";
        rankWonText.text = rank;
        hasWon = true;
        WonMenu.SetActive(true);
    }

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                pauseMenu.transform.GetChild(2).gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
              
    }
}
