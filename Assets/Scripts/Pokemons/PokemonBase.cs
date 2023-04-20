using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName  = "Pokemon", menuName = "Pokemon/Create new pokemon")] 
public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    //[SerializeField] PokemonType type1;
    //[SerializeField] PokemonType type2;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;

    [SerializeField] int expYield;
    [SerializeField] GrowthRate growthRate;

    //[SerializeField] int spAttack;
    //[SerializeField] int spDefense;
    //[SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;

    public int GetExpForLevel(int level)
    {
        if(growthRate == GrowthRate.Fast)
        {
            return (level * level * level);
        }
        else if(growthRate== GrowthRate.Slow)
        {
            return 3 * (level * level * level) / 2;
        }
        return -1;
    }
    public GrowthRate GrowthRate { get { return growthRate; } } 
    public int ExpYield { get { return expYield; } }
    public string Name
    {
        get { return name; }
    }
    public string Description
    { get { return description; } }
    
    public Sprite FrontSprite
    { get { return frontSprite; } }
    public Sprite BackSprite
    { get { return backSprite; } }

    public int MaxHp
    { get { return maxHp; } }
     
    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }
    public List<LearnableMove> LearnableMoves { get { return learnableMoves; } }
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base { get { return moveBase; } }   
    public int Level { get { return level; } }

}

public enum GrowthRate
{
    Fast, Slow
}


