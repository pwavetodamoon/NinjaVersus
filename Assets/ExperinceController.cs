using System;
using UnityEngine;

public class ExperinceController : MonoBehaviour
{
    private float MaxExp;
    private float CurrentExp;
    public CharacterSO Character;
    public float CurrentExpPrecentage
    {
        get
        {
            return (float)CurrentExp;
        }
    }
    public float MaxExpPrecentage
    {
        get
        {
            return (float)MaxExp;
        }
    }

    private void Start()
    {
        Character = GetComponent<Character>().PlayerCharacterSO;
        if (Character != null)
        {
            ResetExpInfomations();
        }
    }

    private void Update()
    {
            GetCurrentExpInfomations();
    }
    public void ResetExpInfomations()
    {
        CurrentExp = (float)Character.GetCurrentExp();
        MaxExp =  (float)Character.GetExpToUpNextLevel();
    }
    private void GetCurrentExpInfomations()
    {
        CurrentExp = (float)Character.GetCurrentExp();
    }
} 
