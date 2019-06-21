using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyBinding
{
  public KeyCode key;
  public string triggerName;
}

[RequireComponent(typeof(Animator))]
public class KeyBindingToTrigger : MonoBehaviour
{

  public List<KeyBinding> keyBindings;


  private Animator animator;


  public void Awake()
  {
    animator = GetComponent<Animator>();

    if (animator == null)
    {
      enabled = false;
    }
  }
  
  void Update()
  {
    foreach (KeyBinding kb in keyBindings)
    {
      if (Input.GetKeyDown(kb.key))
      {
        animator.SetTrigger(kb.triggerName);
      }
    }
  }
}
