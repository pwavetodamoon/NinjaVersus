using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ObjectPooler ObjectPooler;
    public GameUI_Manager gameUI_Manager;
    public Character playerCharacter;
    private bool gameOver;
    private void Awake() {
        playerCharacter = GameObject.FindWithTag("Player").GetComponent<Character>();
    }
    private void GameOver(){
        gameUI_Manager.show_GameOver();
    }
    public void GameFinished(){
        gameUI_Manager.show_GameFinished();
    }
    public void GameLevelUp(){
        gameUI_Manager.show_GameLevelUp();
    }
    void Update()
    {
        if(gameOver)
            return;
        
        if(playerCharacter.CurrentState == Character.CharacterState.Dead){
            gameOver = true;
            GameOver();
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            gameUI_Manager.TogglePauseUI();
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameObject pooledObject = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledObject != null)
            {
                pooledObject.transform.position = transform.position;
                pooledObject.transform.rotation = transform.rotation;
                pooledObject.SetActive(true);
            }
        }
    }

    public void return_MainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
