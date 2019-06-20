using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnColliderEvent : UnityEvent<Collision> { }
[System.Serializable]
public class OnTriggerEvent : UnityEvent<Collider> { }

public class ColliderEventInvoke : MonoBehaviour
{
  public OnColliderEvent onCollisionEnter;
  public OnColliderEvent onCollisionExit;
  public OnColliderEvent onCollisionStay;
  public OnTriggerEvent onTriggerEnter;
  public OnTriggerEvent onTriggerExit;
  public OnTriggerEvent onTriggerStay;

  private void OnCollisionEnter(Collision collision)
  {
    onCollisionEnter?.Invoke(collision);
  }
  private void OnCollisionExit(Collision collision)
  {
    onCollisionExit?.Invoke(collision);
  }
  private void OnCollisionStay(Collision collision)
  {
    onCollisionStay?.Invoke(collision);
  }
  private void OnTriggerEnter(Collider other)
  {
    onTriggerEnter?.Invoke(other);
  }
  private void OnTriggerExit(Collider other)
  {
    onTriggerExit?.Invoke(other);
  }
  private void OnTriggerStay(Collider other)
  {
    onTriggerStay?.Invoke(other);
  }
}
