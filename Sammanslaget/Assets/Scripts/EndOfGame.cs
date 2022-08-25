using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndOfGame : MonoBehaviour
{
    [SerializeField] TMP_Text pointsEndOfGame;
    [SerializeField] MenuManager menuManager;

        private void Start()
    {
        GameStats.OnHealthChangedEvent += CheckEndOfGame;
    }

    void CheckEndOfGame(int points)
    {
        if(GameStats.GetHealth <= 0)
        {
            menuManager.Pause();
            menuManager.OpenGameOverScreenImage();
            pointsEndOfGame.text = GameStats.GetPoints.ToString();
            GameStats.ResetGameStats();
        }
    }
    void OnDestroy()
    {
        GameStats.OnHealthChangedEvent -= CheckEndOfGame;
    }
}
