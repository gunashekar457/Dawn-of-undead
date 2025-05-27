using System.Collections;
using System.Collections.Generic;
using code;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager instance;
    GameState gamestate;

    [Header("Player")]
    public GameObject player;

    [Header("Interactable GameObjects")]
    public GameObject radioTower;

    [Space(10)]
    [Header("Variables")]
    public int radioPartsCollected = 0;
    public int callCount = 0;

    [Space(10)]
    [Header("UI")]
    public TMP_Text radioPartsCollect_Txt;
    public GameObject radioTowerWaypoint_UI;
    public GameObject[] radios;
    public TMP_Text startText_UI;
    public Button startNextButton;
    public TMP_Text gotoRadioTower_UI;
    public TMP_Text gotoHelipad_UI;
    public GameObject gameOverPanel;

    [Space(10)]
    [Header("Scripts")]
    public Mouse_Movement mouseMovement;
    public Enemy enemyScript;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        EnableGameState(GameState.Start);
        startNextButton.onClick.AddListener(() => EnableGameState(GameState.CollectRadioParts));
    }
    private void Update()
    {
        if (radioPartsCollected == 4 && callCount<1)
        {
            callCount++;
            EnableGameState(GameState.GoToRadioTower);
        }
       
    }

    public void EnableGameState(GameState index)
    {
        gamestate = index;
        switch (gamestate)
        {
            case GameState.Start:
                mouseMovement.cursorEnabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                startText_UI.gameObject.SetActive(true);
                break;

            case GameState.CollectRadioParts:
                enemyScript.canSpawn = true;
                mouseMovement.cursorEnabled = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                startText_UI.transform.parent.gameObject.SetActive(false);

                radioPartsCollect_Txt.transform.parent.gameObject.SetActive(true);
                for (int i = 0; i < 4; i++)
                {
                    radios[i].SetActive(true);
                }
                break;

            case GameState.GoToRadioTower:
                gotoRadioTower_UI.transform.parent.gameObject.SetActive(true);
                radios[4].SetActive(true);

                radioTowerWaypoint_UI.SetActive(true);
                StartCoroutine(DisableTextAfterDelay(3f, gotoRadioTower_UI));
                radioTower.GetComponent<MeshCollider>().enabled = true;
                break;

            case GameState.AtRadioTower:
                radios[4].SetActive(false);

                mouseMovement.cursorEnabled = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                radioTower.GetComponent<MeshCollider>().enabled = false;
                SceneManager.LoadScene("MiniGame", LoadSceneMode.Additive);
                break;

            case GameState.GoToHelipad:
                SceneManager.UnloadSceneAsync("MiniGame");

                mouseMovement.cursorEnabled = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                radios[5].SetActive(true);
                gotoHelipad_UI.transform.parent.gameObject.SetActive(true);
                StartCoroutine(DisableTextAfterDelay(3f, gotoHelipad_UI));
                break;
        }
    }
    public void Interact()
    {
        radioPartsCollected++;
        radioPartsCollect_Txt.text = radioPartsCollected + "/4";

        if(radioPartsCollected == 4)
        {
            gamestate = GameState.GoToRadioTower;
        }
    }

    public void GameOver()
    {
        mouseMovement.cursorEnabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        gameOverPanel.SetActive(true);
    }


    IEnumerator DisableTextAfterDelay(float time, TMP_Text txt)
    {
        yield return new WaitForSeconds(time);

         txt.transform.parent.gameObject.SetActive(false);
    }

    
}
