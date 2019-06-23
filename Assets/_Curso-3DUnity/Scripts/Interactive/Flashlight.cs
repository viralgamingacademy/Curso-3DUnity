using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(AudioSource))]
public class Flashlight : MonoBehaviour
{
  public ItemSO flashlightItem;
  public bool isOn;

  public AudioClip turnOn;
  public AudioClip turnOff;

  private PlayerController player;
  private AudioSource audioSource;
  private Light spotLight;


  void Start()
  {
    player = GetComponentInParent<PlayerController>();
    spotLight = GetComponent<Light>();
    audioSource = GetComponent<AudioSource>();

    TurnOff();
  }

  public bool CheckFlashlightInInventory()
  {
    return player.playerInventory.CheckItem(flashlightItem);
  }

  public void TurnOn()
  {
    spotLight.enabled = true;
    isOn = true;
    PlaySound(turnOn);
  }

  public void TurnOff()
  {
    spotLight.enabled = false;
    isOn = false;
    PlaySound(turnOff);
  }

  public void PlaySound(AudioClip audio)
  {
    audioSource.loop = false;
    audioSource.clip = audio;
    audioSource.Play();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.F))
    {
      if (isOn)
      {
        TurnOff();
      }
      else
      {
        TurnOn();
      }
    }
  }
}
