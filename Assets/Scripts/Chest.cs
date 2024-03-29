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
      GameManager.Instance.ShowText("+" + pesosAmount + " pesos", 25, Color.yellow, transform.position, Vector3.up * 25, 1f);
    }
  }
}
