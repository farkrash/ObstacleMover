using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinBlockDecreasCount : MonoBehaviour
{
    [SerializeField] private PlayerCoffinScript player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerCoffinScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Detacher>())
        {
            player.numOfStacks--;
            print(player.numOfStacks);
        }
    }

}
