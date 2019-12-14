using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool LeftHandContaminated;
    public bool RightHandContaminated;
    public CharacterControl chef;
    public List<FoodThrower> spawners;
}
