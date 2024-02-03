using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DecorReverseController : MonoBehaviour
{
    public GameObject platform;
    private DecorReverser _decorReverser;
    
    void Start()
    {
        _decorReverser = platform.GetComponent<DecorReverser>();
    } 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _decorReverser.ReverseDecor(other.GameObject());
        }
    }
}
