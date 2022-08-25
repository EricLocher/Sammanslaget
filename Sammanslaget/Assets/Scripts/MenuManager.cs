using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject startScreen,
                                rulesStart,
                                rulesInGame,
                                rulesGameOver,
                                gameOverScreen;

    [SerializeField] AudioListener audiolistener;
    [SerializeField] Sprite speakerOn,
                            speakerOff;

    [SerializeField] Image speakerIcon;

    public bool isPaused;
    public bool soundOn = true;

    private void Start()
    {
        Pause();
    }

    public void TurnSoundOnOff()
    {
        if (soundOn)
        {
            audiolistener.enabled = false;
            soundOn = false;
            speakerIcon.sprite = speakerOff;
        }
        else if (!soundOn)
        {
            audiolistener.enabled = true;
            soundOn = true;
            speakerIcon.sprite = speakerOn;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public void OpenRulesStartImage()
    {
        rulesStart.SetActive(true);
    }
    public void CloseRulesStartImage()
    {
        rulesStart.SetActive(false);
    }
    public void OpenRulesInGameImage()
    {
        rulesInGame.SetActive(true);
    }
    public void CloseRulesInGameImage()
    {
        rulesInGame.SetActive(false);
    }
    public void OpenRulesGameOverImage()
    {
        rulesGameOver.SetActive(true);
    }
    public void CloseRulesGameOverImage()
    {
        rulesGameOver.SetActive(false);
    }
    public void OpenStartScreenImage()
    {
        startScreen.SetActive(true);
    }
    public void CloseStartScreenImage()
    {
        startScreen.SetActive(false);
    }
    public void OpenGameOverScreenImage()
    {
        gameOverScreen.SetActive(true);
    }
    public void CloseGameOverScreenImage()
    {
        gameOverScreen.SetActive(false);
    }

}
