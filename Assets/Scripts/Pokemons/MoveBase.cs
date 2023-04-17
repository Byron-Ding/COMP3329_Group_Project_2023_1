using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move",menuName = "Pokemon/Create new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int power;
    [SerializeField] int accuracy; 

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int Power { get { return power; } }

    public int Accuracy { get { return accuracy;} }


        
}
