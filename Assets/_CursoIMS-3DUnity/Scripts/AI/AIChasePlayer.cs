using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MonsterController))]
[RequireComponent(typeof(NavMeshAgent))]
public class AIChasePlayer : MonoBehaviour
{
  // BUZON
  public PlayerController playerChased;

  private MonsterController monster;
  private NavMeshAgent agent;

  // FIN DEL BUZON

  #region Enablers
  private void OnEnable()
  {
    agent = GetComponent<NavMeshAgent>();
    monster = GetComponent<MonsterController>();
  }

  public void Enable(PlayerController _player)
  {
    playerChased = _player;
    enabled = true;
    OnEnable();
  }

  public void Disable()
  {
    enabled = false;
    playerChased = null;
  }
  #endregion

  private void Update()
  {
    if (playerChased)
    {
      monster.GoToPosition(playerChased.transform.position);
    }
  }

}
