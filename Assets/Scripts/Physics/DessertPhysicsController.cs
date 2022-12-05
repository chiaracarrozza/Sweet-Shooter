using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DessertPhysicsController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float forceMagnitude;

    [SerializeField] float rotSpeed;

    [SerializeField] float JumpForce;

    Vector3 totalForce = new Vector3();

    public Rigidbody Bullet;
    public float BulletSpeed;
    public float BulletLifeSpan;

    [SerializeField] GameOverandClearMenu menu;
    [SerializeField] Text GameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Character movement and roatation
        totalForce = Vector3.zero;

        if (Input.GetKey("w"))
        {
            totalForce += transform.forward * forceMagnitude; 
        }
        if (Input.GetKey("a"))
        {
            totalForce -= transform.right * forceMagnitude;
        }
        if (Input.GetKey("d"))
        {
            totalForce += transform.right * forceMagnitude;
        }

        if (Input.GetKey("s"))
        {
            totalForce -= transform.forward * forceMagnitude;
        }
        Vector3 targetDir = Vector3.Normalize(totalForce * Time.deltaTime);
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, rotSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        
        //Jumping
        if (Input.GetKeyDown("space"))
        {
            if (transform.position.y <= 2.2f)
            {

                rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

            }
        }

        //Shooting
        if (Input.GetMouseButtonDown(1))
        {
            Rigidbody clone;
            clone = Instantiate(Bullet, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * BulletSpeed);
            Destroy(clone.gameObject,BulletLifeSpan);

            
        }
        

        //Game Over
        if(transform.position.y<= -10)
        {
            GameOver.text = "You Lose!";
            menu.gameObject.SetActive(true);
        }

        

    }
    void FixedUpdate()
    {
        rb.AddForce(totalForce, ForceMode.Force);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Lemon"))
        {
            Debug.Log("Hit!");
            Destroy(other.gameObject);
            GameOver.text = "You Lose!";
            menu.gameObject.SetActive(true);

        }

        
    }

}
