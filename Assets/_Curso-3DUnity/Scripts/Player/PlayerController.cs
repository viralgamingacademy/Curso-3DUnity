using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
  public static PlayerController Instance
  {
    get
    {
      return ((PlayerController)mInstance);
    }
    set
    {
      mInstance = value;
    }
  }

  public PlayerInventory playerInventory;
  public Flashlight flashLight;

  public bool inventoryOpened;


  public override void Awake()
  {
    base.Awake();

    playerInventory = gameObject.GetComponentInChildren<PlayerInventory>();
    flashLight = gameObject.GetComponentInChildren<Flashlight>();
  }

  public void ActivateFlashlightGameObject()
  {
    if (flashLight)
    {
      flashLight.gameObject.SetActive(true);
    }
  }
}

