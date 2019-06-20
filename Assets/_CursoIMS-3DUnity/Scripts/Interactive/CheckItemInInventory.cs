using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemChecked : UnityEvent<ItemSO> { }

public class CheckItemInInventory : MonoBehaviour
{
  public ItemSO itemToCheck;

  public ItemChecked itemChecked;
  public ItemChecked itemNotChecked;


  public void CheckItem(PlayerController playerController)
  {
    if (playerController.playerInventory.CheckItem(itemToCheck))
    {
      itemChecked?.Invoke(itemToCheck);
    }
    else
    {
      itemNotChecked?.Invoke(itemToCheck);
    }
  }
}
