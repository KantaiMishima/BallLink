using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 pos = new Vector3(0f,0f,0f);
    Vector3 rot = new Vector3(0f, 0f, 0f);
    [SerializeField] float speed = 1.0f;
    Rigidbody rb;
  
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f,0f,1f);
        //pos.x = Random.Range(-2.5f, 2.5f);
        //pos.y = 1f;
        //pos.z = Random.Range(-2.5f, 2.5f);
        rot.x = 0;
        rot.y = Random.Range(0f,360f);
        rot.z = 0;
        //transform.position = pos;
        transform.Rotate(rot);
        //Quaternion.Euler(Random.Range(0f, 360f), 0, 0);


        

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, 0.01f);
        rb.velocity =this.transform.forward * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            this.transform.LookAt(this.transform.position - this.transform.forward);
        }
    }
}
