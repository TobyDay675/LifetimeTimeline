using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UnityEventOnCollideOrCollision : MonoBehaviour
{
    
    public UnityEvent collide;
    public UnityEvent onCollision;
    public bool MichaelBox;
    public GameObject Box;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && MichaelBox == false)
        {
            collide.Invoke();
        }

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && MichaelBox == false)
        onCollision.Invoke();
        if (this.CompareTag("Red Box") && other.gameObject.CompareTag("Player") && MichaelBox == true)
        {
            Box.GetComponent<Rigidbody2D>().mass = 1000;
        }
        if (this.CompareTag("Red Box") && other.gameObject.CompareTag("Michael") && MichaelBox == true)
        {
            Box.GetComponent<Rigidbody2D>().mass = 0;
        }
    }
}
