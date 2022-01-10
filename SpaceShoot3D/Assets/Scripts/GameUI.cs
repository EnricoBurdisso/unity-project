using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject mainMenu;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject playerSpawnLocation;

    bool isDisplayed = true;


    void Start(){
      ShowMainMenu();
    }

    void OnEnable(){
      EventManager.onStartGame += ShowGameUI;
      EventManager.onPlayerDeath += ShowMainMenu;
    }

    void OnDisable(){
      EventManager.onStartGame -= ShowGameUI;
      EventManager.onPlayerDeath -= ShowMainMenu;
    }

    void ShowMainMenu(){
      mainMenu.SetActive(true);
      gameUI.SetActive(false);
    }

    void ShowGameUI(){
      mainMenu.SetActive(false);
      gameUI.SetActive(true);

      Instantiate(playerPrefab, playerSpawnLocation.transform.position, playerSpawnLocation.transform.rotation);
    }

  

    void HidePanel(){
      isDisplayed = !isDisplayed;
      //playButton.SetActive(isDisplayed);
    }

    public void PlayGameButton(){
      EventManager.StartGame();
    }
}
