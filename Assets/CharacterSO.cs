
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterSO", menuName = "ScriptableObjects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
   [SerializeField] private int _level = 1;
   [SerializeField] private float _currentExp = 0.0f;
   [SerializeField] private float _expToUpNextLevel = 100f;
   
    
   public float GetExpToUpNextLevel()
   {
       return _expToUpNextLevel;
   }
    
   public void SetExpToUpNextLevel( float value)
   {
       _expToUpNextLevel += value;
   }
    public int GetCurrentLevel()
    {
        return _level;
    }
    
    public void SetLevelUp( int value)
    {
        _level += value;
    }
    
    public float GetCurrentExp()
    {
        return _currentExp;
    }
    
    public void SetCurrentExp( float value)
    {
        _currentExp += value;
    }
    
}
