using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameUI_Manager : MonoBehaviour
{
    public GameManager GM;
    public TMPro.TextMeshProUGUI CoinText;
    [FormerlySerializedAs("HealthSlider")] public Slider ExpSlider;
    public TextMeshProUGUI Text_Exp;
    public TextMeshProUGUI Text_MaxExp;
    public GameObject UI_Pause;
    public GameObject UI_GameOver;
    public GameObject UI_GameFinished;
    public ExperinceController ExperinceController;
    public Character Character;
    private float _trailLerpSpeed = 2f;

    public enum GameUI_State{
        GamePlay,Pause,GameOver,GameFinished,GameLevelUp
    }

    public GameUI_State currentState;

    private void Start()
    {
        Character = FindFirstObjectByType<Character>().GetComponent<Character>();
        ExperinceController = FindFirstObjectByType<ExperinceController>().GetComponent<ExperinceController>();
        if (ExperinceController != null)
        {
            UpdateUISlider();
        }
        else
        {
            Debug.LogError("ExperinceController is not assigned.");
        }
        SwitchUIState(GameUI_State.GamePlay);
    }

    void Update()
    {
        if (ExperinceController != null)
        {
            ExpSlider.value = Mathf.Lerp(ExpSlider.value,ExperinceController.CurrentExpPrecentage,Time.deltaTime * _trailLerpSpeed);
            CoinText.text = GM.playerCharacter.Coin.ToString();
            Text_Exp.text = $"{ExperinceController.CurrentExpPrecentage}/{ExperinceController.Character.GetExpToUpNextLevel()}";
        }
        if (Character.IsLevelup == true)
        {
            Debug.Log("update lv");
            ExpSlider.maxValue += (int)ExperinceController.MaxExpPrecentage;
            ExpSlider.value = 0;
            Debug.Log($"{ExpSlider.maxValue}===={ExpSlider.value}");
            Character.IsLevelup = false;
        }
    }

    private void UpdateUISlider()
    {
        if (ExperinceController != null)
        {
            ExpSlider.minValue = 0; 
            ExpSlider.maxValue = ExperinceController.MaxExpPrecentage;
        }
        else
        {
            Debug.LogError("ExperinceController is not assigned.");
        }
    }

    private IEnumerator DelayedPause(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 0;
    }

    private void SwitchUIState(GameUI_State state){
        UI_GameFinished.SetActive(false);
        UI_GameOver.SetActive(false);
        UI_Pause.SetActive(false);
        Time.timeScale = 1;

        switch(state){
            case GameUI_State.GamePlay:
                break;
            case GameUI_State.Pause:
                Time.timeScale = 0;
                UI_Pause.SetActive(true);
                break;
            case GameUI_State.GameOver:
                StartCoroutine(DelayedPause(2.5f));
                UI_GameOver.SetActive(true);
                break;
            case GameUI_State.GameFinished:
                StartCoroutine(DelayedPause(2.5f));
                UI_GameFinished.SetActive(true);
                break;
            case GameUI_State.GameLevelUp:
                break;
        }

        currentState = state;
    }

    public void TogglePauseUI(){
        if(currentState == GameUI_State.GamePlay)
            SwitchUIState(GameUI_State.Pause);
        else if(currentState == GameUI_State.Pause)
            SwitchUIState(GameUI_State.GamePlay);
    }

    public void Button_MainMenu(){
        GM.return_MainMenu();
    }

    public void Button_Restart(){
        GM.Restart();
    }

    public void show_GameOver(){
        SwitchUIState(GameUI_State.GameOver);
    }

    public void show_GameFinished(){
        SwitchUIState(GameUI_State.GameFinished);
    }
    public void show_GameLevelUp(){
        SwitchUIState(GameUI_State.GameLevelUp);
    }
}
