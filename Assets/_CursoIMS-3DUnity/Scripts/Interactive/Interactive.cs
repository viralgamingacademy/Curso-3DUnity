using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnPlayerInteracted : UnityEvent<PlayerController> { }



[RequireComponent(typeof(BoxCollider))]
public class Interactive : MonoBehaviour
{
  private BoxCollider mySphereCollider;

  private PlayerController playerEntered;
  public OnPlayerInteracted onPlayerInteracted;

  private void Awake()
  {
    mySphereCollider = GetComponent<BoxCollider>();
    mySphereCollider.isTrigger = true;
    enabled = false;
  }

  /// <summary>
  ///  cuando algo entra en nuestra área de influencia
  /// </summary>
  /// <param name="other"></param>
  private void OnTriggerEnter(Collider other)
  {
    // SI es el jugador (su TAG es Player)
    if (other.gameObject.CompareTag("Player"))
    {
      /// Ya sabemos que el que ha interactuado con nosotros
      /// es un "jugador". Vamos a confirmar que ese jugador
      /// tenga el componente "PlayerController", que lo 
      /// necesitamos para enviar el evento OnPlayerInteracted

      /// Del collider del objeto con el que hemos chocado,
      /// mira en su game object si hay un componente llamado
      /// PlayerController
      playerEntered = other.gameObject.GetComponent<PlayerController>();
      /// Comprobamos que efectivamente lo TENGA
      if (playerEntered != null)
      {
        enabled = true;

      }

    }
  }

  private void OnTriggerExit(Collider other)
  {
    // SI es el jugador (su TAG es Player)
    if (other.gameObject.CompareTag("Player"))
    {
      playerEntered = null;
      enabled = false;
    }
  }

  private void LateUpdate()
  {
    // SI estamos pulsando el botón que se corresponde con la
    // acción "A" (NO es el teclado en la tecla A, es el botón
    // A del mando de la XBOX)
    if (Input.GetButtonDown("A"))
    {
      /// El jugador ha entrado en nuestro área, nos hemos
      /// asegurado de que era realmente él, y ha pulsao
      /// el botón de acción (E en el teclado o la A en el mando)
      /// Así que lanzamos el evento
      onPlayerInteracted.Invoke(playerEntered);

    }
  }





}


