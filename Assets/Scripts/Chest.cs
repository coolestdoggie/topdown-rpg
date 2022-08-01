using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{
  [SerializeField] private Sprite emptyChest;
  [SerializeField] private int pesosAmount;

  protected override void OnCollect()
  {
    if (!collected)
    {
      collected = true;
      GetComponent<SpriteRenderer>().sprite = emptyChest;
    }
  }
}
