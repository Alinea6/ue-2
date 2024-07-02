using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class DamageTriggerScript : MonoBehaviour
{
    private PlayerController _controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _controller.KillPlayer();
    }
}
