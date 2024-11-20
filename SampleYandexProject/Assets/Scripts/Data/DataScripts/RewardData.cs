using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RewardData", menuName = "ScriptableObjects/RewardData", order = 1)]
public class RewardData : ScriptableObject
{
    public List<Rewards> rewards;
}
