using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] string xz;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Ball")
        {
            Vector3 rotation = collision.transform.forward;
            if (xz == "x")
            {
                rotation.x *= -1;
            }
            if (xz == "z")
            {
                rotation.z *= -1;
            }
            collision.transform.LookAt(collision.transform.position + rotation);
        }
    }
}