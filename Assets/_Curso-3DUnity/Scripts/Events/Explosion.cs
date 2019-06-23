using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Damager))]
public class Explosion : MonoBehaviour
{
  public float explosionRadius;
  public float force;
  public float fuseTime;
  public float affectedRigidbodyDestroyTime;
  public AudioClip fuseSound;
  public AudioClip explosionSound;
  public GameObject explosionPrefab;

  private AudioSource audioSource;
  private Damager damager;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    damager = GetComponent<Damager>();
  }

  public void StartExplosion()
  {
    if (fuseSound)
    {
      audioSource.clip = fuseSound;
      audioSource.loop = true;
      audioSource.Play();
    }

    Invoke("Explode", fuseTime);
  }


  void Explode()
  {
    Debug.Log("Exploded!");

    if (explosionSound)
    {
      audioSource.clip = explosionSound;
      audioSource.loop = false;
      audioSource.Play();
    }

    if (explosionPrefab)
    {
      GameObject createdExplosion = Instantiate(explosionPrefab);
      createdExplosion.transform.position = gameObject.transform.position;
      Destroy(createdExplosion, 5.0f);
    }

    /// TO DO: Physics!!!
    
    /// END TO DO
    
    Destroy(gameObject, affectedRigidbodyDestroyTime);
  }
}

