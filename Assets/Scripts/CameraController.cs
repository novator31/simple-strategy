using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed;
    public float scrollSpeed;
    private Transform _transform;
    public bool scrooling;

    public float timer;
    public float maxTimer;
    Vector3 newYPos;
    float Y;
    public float newY;
    SmoothMouseLook MS;
	// Use this for initialization
	void Start () {
        _transform = transform;
        MS = GetComponent<SmoothMouseLook>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
       
    }

    void Move()
    {
       Y = Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetMouseButton(1))
        {
            float X = Input.GetAxis("Mouse X");
          
            float Z = Input.GetAxis("Mouse Y");

            _transform.Translate(new Vector3(X * speed, 0, Z * speed) * Time.deltaTime);
        }
        if(Y != 0)
        {
            if (!scrooling)
            {
                newYPos = new Vector3(transform.position.x, transform.position.y + newY * Mathf.Sign(Y), transform.position.z);
                scrooling = true;
                speed += 100 * Mathf.Sign(Y);
            }
        }
        if (scrooling)
        {
            if(timer < maxTimer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                scrooling = false;
                timer = 0;
            }
            float perc = timer / maxTimer;
            float dist = Vector3.Distance(transform.position, newYPos);
            if(dist < 0.2f)
            {
                scrooling = false;
                timer = 0;
            }
            transform.position = Vector3.Lerp(transform.position, newYPos , perc);
           
        }
    }
}
