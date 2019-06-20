using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public ItemSO item;

  public void ItemTaken(PlayerController playerInteracted)
  {
    Debug.Log($"El jugador {playerInteracted.gameObject.name} ha cogido el item {item.itemName}");
    bool hasBeenAdded = playerInteracted.playerInventory.AddItem(item);
    if (hasBeenAdded)
    {
      Debug.Log("Se ha añadido");
      // Como se ha cogido el objeto, nos destruimos
      Destroy(gameObject);
    }
    else
    {
      Debug.Log("El inventario estaba lleno. No se puede añadir");
    }
  }
}
