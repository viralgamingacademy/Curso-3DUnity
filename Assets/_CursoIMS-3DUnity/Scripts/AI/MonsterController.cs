using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AIWander))]
[RequireComponent(typeof(AIChasePlayer))]

[System.Serializable]
public class OnPlayerEvent : UnityEvent<PlayerController> { }

public class MonsterController : MonoBehaviour
{
  // BUZÓN

  public OnPlayerEvent onPlayerSeen;
  public OnPlayerEvent onPlayerLost;

  public bool isWandering;
  public bool isChasingPlayer;

  public Vector3 lastKnownPosition;
  private Animator anim;
  private NavMeshAgent navMeshAgent;

  private AIWander aiWander;
  private AIChasePlayer aiChasePlayer;

  private PlayerController playerSeen;
  // FIN DEL BUZÓN

  void Start()
  {
    anim = GetComponent<Animator>();
    navMeshAgent = GetComponent<NavMeshAgent>();
    aiWander = GetComponent<AIWander>();
    aiChasePlayer = GetComponent<AIChasePlayer>();


    StartWandering();
  }

  private void LateUpdate()
  {
    float curSpeed = navMeshAgent.velocity.magnitude;

    if (curSpeed > 0)
    {
      anim.SetInteger("moving", 1); //walk
    }
    else
    {
      anim.SetInteger("moving", 0); // idle
    }
  }

  #region AI
  public void DisableAllAI()
  {
    aiWander.Disable();
    aiChasePlayer.Disable();
  }

  public void StartWandering()
  {
    Debug.Log("Monster wandering");
    isWandering = true;
    DisableAllAI();
    aiWander.Enable();

  }

  public void StopWandering()
  {
    Debug.Log("Monster stop wandering");
    isWandering = false;
    aiWander.Disable();
    navMeshAgent.velocity = Vector3.zero;
  }

  public void StartChasingPlayer()
  {
    Debug.Log("Monster chasing player");
    isChasingPlayer = true;
    DisableAllAI();
    aiChasePlayer.Enable(playerSeen);
  }

  public void StopChasingPlayer()
  {
    Debug.Log("Monster stop chasing player");
    isChasingPlayer = false;
    DisableAllAI();
    aiChasePlayer.Disable();
    navMeshAgent.velocity = Vector3.zero;
  }
  #endregion

  public void GoToPosition(Vector3 position)
  {
    navMeshAgent.SetDestination(position);
  }

  public void OnPlayerSeen(Collider player)
  {
    if (isChasingPlayer) return;

    if (player.tag == "Player")
    {
      playerSeen = player.GetComponent<PlayerController>();
      if (playerSeen != null)
      {
        Debug.Log("Player seen! DIEEEEEEEEEEEE");
        StopWandering();
        onPlayerSeen?.Invoke(playerSeen);
        StartCoroutine(CoOnPlayerSeen());
      }
    }
  }

  public void OnPlayerLost(Collider player)
  {
    if (player.tag == "Player")
    {
      Debug.Log("Player lost. Going to last spot");
      lastKnownPosition = playerSeen.transform.position;

      isChasingPlayer = false;
      playerSeen = null;

      onPlayerLost?.Invoke(playerSeen);
      StartCoroutine(CoOnPlayerLost(lastKnownPosition));
    }
  }

  IEnumerator CoOnPlayerSeen()
  {
    anim.SetInteger("moving", 8);
    Debug.Log("ROAAAAR");
    yield return new WaitForSeconds(2f);

    StartChasingPlayer();
  }

  IEnumerator CoOnPlayerLost(Vector3 lastPosition)
  {
    anim.SetInteger("moving", 18);
    Debug.Log("LOST");
    yield return new WaitForSeconds(2f);

    StartWandering();
  }
}
