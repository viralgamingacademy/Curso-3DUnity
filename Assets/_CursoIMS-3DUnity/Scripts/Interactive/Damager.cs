using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class DamageDone : UnityEvent<Damageable> { }
public class Damager : MonoBehaviour
{
  public int damageDone;
  public Collider damageTrigger;
  public List<string> listDamageTags;

  public DamageDone DamageDoneEvent;

  public void PerformDamage(Damageable damageable)
  {
    if (listDamageTags.Contains(damageable.gameObject.tag))
    {
      damageable.TakeDamage(this);
    }
  }

  /*

  /// <summary>
  /// Esta es la funcion que nos avisa de que algo ha chocado con nosotros
  /// </summary>
  /// <param name="collision"></para>
  private void OnTriggerEnter(Collider collision)
  {

    //comprobamos si el trigger que ha activado el mensaje es el que ha chocado con el objeto
    //esto es necesario porque esta funcion se dispara con la conlision de cualquier trigger
    if (damageTrigger.IsTouching(collision))
    {
      // si el otro objeto (collision.gameobject) contine un tag al que le puedo hacer daño
      if (listDamageTags.Contains(collision.gameObject.tag))
      {
        //Cojemos el "Damageable" del objeto con el que chocamos
        Damageable collisionDamageable;
        collisionDamageable = collision.gameObject.GetComponent<Damageable>();
        // si realmente lo hemos podido coger
        if (collisionDamageable != null)
        {
          Debug.Log($"La entidad {gameObject.name} ha realizado {damageDone} puntos de daño a la entidad {collisionDamageable.gameObject}");


          DamageDoneEvent.Invoke(collisionDamageable);


          //le hacemos daño llamando a nuestro PerformDamage
          PerformDamage(collisionDamageable);
        }
      }
    }
  }
  */


}
