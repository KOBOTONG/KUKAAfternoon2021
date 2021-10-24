using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControllerRigidbody : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2f;
    public float rotspeed = 10f;
    float newRotY = 0;
    public Transform gunPosition;
    public GameObject prefebBullet;
    public float gunPower = 15f;
    public float guncooldown = 2f;
    public float gunCooldownCount = 0;
    public bool hasGun = false;
    public int bulletcount = 0;

    public int coinCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        if (horizontal > 0)
        {
            newRotY = 90;
        }
        else if (horizontal < 0)
        {
            newRotY = -90;
        }

        if (vertical > 0)
        {
            newRotY = 0;
        }
        else if (vertical < 0)
        {
            newRotY = 180;
        }

        rb.AddForce(horizontal, 0, vertical, ForceMode.VelocityChange);

        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRotY, 0),
                                               transform.rotation,
                                               Time.deltaTime * rotspeed
                                               );

    }
    private void Update()
    {
        gunCooldownCount += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && hasGun && gunCooldownCount >= guncooldown)
        {
            gunCooldownCount = 0;
            GameObject bullet = Instantiate(prefebBullet, gunPosition.position, gunPosition.rotation);      
            Rigidbody bRb = bullet.GetComponent<Rigidbody>();
            bRb.AddForce(transform.forward * gunPower, ForceMode.Impulse);
            Destroy(bullet, 2f);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Conllectable")
        {
            Destroy(collision.gameObject);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Conllectable")
        {
            Destroy(other.gameObject);
            coinCount++;
            
        }
        if (other.gameObject.name == "Gun")
        {
            print("Yea! i have gun");
            Destroy(other.gameObject);
            hasGun = true;
        }

    }

}
