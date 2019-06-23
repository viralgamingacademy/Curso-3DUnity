using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnSimpleEvent : UnityEvent { }


public class EventInvoke : MonoBehaviour
{
  public OnSimpleEvent eventToInvoke;

  public void Invoke()
  {
    if (eventToInvoke != null) eventToInvoke.Invoke();   
  }

}
