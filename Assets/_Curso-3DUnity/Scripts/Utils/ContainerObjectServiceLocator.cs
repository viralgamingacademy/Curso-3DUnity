using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Transform manager;
    public Transform scenery;
   
    public Transform interactive;
    public new Transform camera;
    public Transform hud;
    public new Transform audio;


  }
