using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UnityEventOnCollideOrCollision : MonoBehaviour
{
    
    public UnityEvent collide;
    public UnityEvent onCollision;
    public bool quit;
    public GameObject Box;
    public string year;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(year);
            if (quit == true)
            {
                Application.Quit(); 
            }
        }

    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        onCollision.Invoke();
        if (this.CompareTag("Red Box") && other.gameObject.CompareTag("Player"))
        {
            Box.GetComponent<Rigidbody2D>().mass = 1000;
        }
        if (this.CompareTag("Red Box") && other.gameObject.CompareTag("Michael"))
        {
            Box.GetComponent<Rigidbody2D>().mass = 0;
        }
    }
}
