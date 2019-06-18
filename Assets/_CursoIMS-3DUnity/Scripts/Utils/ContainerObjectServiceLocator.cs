using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PvZInitial
{
  public class ContainerObjectServiceLocator : Singleton<ContainerObjectServiceLocator>
  {
    public static ContainerObjectServiceLocator Instance
    {
      get
      {
        return ((ContainerObjectServiceLocator)mInstance);
      }
      set
      {
        mInstance = value;
      }
    }

    public Transform managers;
    public Transform scenery;
    public Transform plants;
    public Transform zombies;
    public Transform projectiles;
    public Transform interactives;
    public new Transform camera;
    public Transform hud;
    public new Transform audio;


  }
}