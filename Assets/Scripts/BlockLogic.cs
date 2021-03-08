using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Update()
    {
        transform.position = player.transform.position;
    }
}
