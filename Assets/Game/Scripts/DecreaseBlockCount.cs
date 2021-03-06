using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseBlockCount : MonoBehaviour
{
    [SerializeField] private PlayerScript player;
    private bool numOfstacksDecreased = false;
    private void Awake()
    {
        player = FindObjectOfType<PlayerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DetacherBeach>())
        {
            if (!numOfstacksDecreased)
            {
                player.numOfStacks--;

                numOfstacksDecreased = true;
            }
        }
    }

}
