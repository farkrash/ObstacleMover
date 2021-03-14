using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinBlockDecreasCount : MonoBehaviour
{
    [SerializeField] private PlayerScript player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Detacher>())
        {
            player.numOfBlocks--;
            print(player.numOfBlocks);
        }
    }

}
