using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "Bomb";
        }
    }

    public Sprite _Image;
    public Sprite Image
    {
        get { return _Image; }
    }

    public void OnPickup()
    {      
        gameObject.SetActive(false);   
    }

    public void OnDrop()
    {
      
    }

    
}
