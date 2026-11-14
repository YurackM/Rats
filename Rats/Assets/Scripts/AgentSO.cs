using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/AgentSO", order = 1)]
public class AgentSO : ScriptableObject
{
    public List<Agent> agents;
    public Agent ratKing;
}
