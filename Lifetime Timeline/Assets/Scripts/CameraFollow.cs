using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 offset;
    public float camVelocitySpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vel = target.GetComponent<Rigidbody2D>().velocity.x;
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3((vel / camVelocitySpeed), 0), Time.fixedDeltaTime * speed) + offset;
    }
}
