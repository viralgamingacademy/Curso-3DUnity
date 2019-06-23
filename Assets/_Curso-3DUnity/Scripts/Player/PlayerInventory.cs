using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnItemTaken : UnityEvent<ItemSO> { };




public class PlayerInventory : MonoBehaviour
{
  // BUZON
  public List<ItemSO> inventory;
  public int maxCapacity;

  public OnItemTaken onItemTaken;
  public OnItemTaken onItemCannotTake;
  // FIN DEL BUZON

  /// Añadimos un nuevo objeto al inventario
  public bool AddItem(ItemSO item)
  {
    /// Si el número de objectos en el inventario es MENOR
    /// que la capacidad, lo añadimos
    if (inventory.Count < maxCapacity)
    {
      inventory.Add(item);
      onItemTaken.Invoke(item);
      return true;
    }
    else
    {
      onItemCannotTake.Invoke(item);
      return false;
    }
  }

  /// Eliminamos UN objeto del inventario
  public bool RemoveItem(ItemSO item)
  {
    /// llamamos a la función "Remove" de las listas de C#
    /// que ESPECIFICAMENTE hace lo mismo que nosotros
    bool hasBeenRemoved = inventory.Remove(item);
    return hasBeenRemoved;
  }

  /// Comprobamos si un objeto está en el inventario
  public bool CheckItem(ItemSO item)
  {
    /// la función FIND devuelve la LISTA de objetos encontrados
    /// Nuestra idea es comprobar que hay más de 0 (es decir,
    /// tenemos el objeto en el inventario)
    bool hasBeenFound = inventory.Find(i => i == item) != null;

    return hasBeenFound;
  }

  /// <summary>
  /// Función para comprobar cuántos objetos tenemos de
  /// un tipo
  /// </summary>
  /// <param name="item"></param>
  /// <returns></returns>
  public int CheckNumberOfItems(ItemSO item)
  {
    return inventory.FindAll(i => i == item).Count;
  }
}
