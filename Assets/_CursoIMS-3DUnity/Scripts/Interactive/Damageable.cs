using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// clase que implementa eventos con parametros
/// </summary>
[System.Serializable]
public class DamageReceived : UnityEvent<int , int> { }
[System.Serializable]
public class HealthSet : UnityEvent<int> { }

public class Damageable : MonoBehaviour
{
  //vida actual
  public int curHealth;
  //vida máxima
  public int maxHealth;
  //indica que el damageable a fenecido
  public bool isDead = false;


  public DamageReceived damageReceived;

  // evento para cuando no tenemos parametros
  //public UnityEvent EventHealth = new UnityEvent();

  public HealthSet healthSet;



  //inicialización de la variables
  private void Start()
  {
    // ponemos el nuestra vida al máximo al principio
    curHealth = maxHealth;
    //establecemos que NO hemos muerto
    isDead = false;

    healthSet.Invoke(curHealth);

  }


  /// <summary>
  /// A esta funcion se le llama cuando nos van ha hacer daño
  /// el encargado de llamarla es el Damager
  /// </summary>
  /// <param name="damager"></param>
  public void TakeDamage(Damager damager)
  {
    Debug.Log($"Me ha pegado {damager.gameObject}");
    //del damager nos restara la vida que diga su damageDone
    curHealth -= damager.damageDone;


    //llamada al unity event 
    damageReceived.Invoke(damager.damageDone, curHealth);

    //Comprobamos si hemos muerto
    if (curHealth <= 0)
    {
      Die();
    }
  }
  //fuencion que se llama cuendo mueres
  private void Die()
  {
    Debug.Log($"la entidad {this.name} ha muerto");
    // elimina el gameobject
    Destroy(this.gameObject);
  }
}
