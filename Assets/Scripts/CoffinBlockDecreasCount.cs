using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinBlockDecreasCount : MonoBehaviour
{
    [SerializeField] private PlayerCoffinScript player;
    private bool numOfstacksDecreased = false;
    private void Awake()
    {
        player = FindObjectOfType<PlayerCoffinScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Detacher>())
        {
            if (!numOfstacksDecreased)
            {
                player.numOfStacks--;

                numOfstacksDecreased = true;
            }
        }
    }

}
