using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject cameraPivot;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    private float PowerupStrength = 15.0f;
    public GameObject PowerupIndicator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        cameraPivot = GameObject.Find("cameraPivot");

    }
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        
        playerRb.AddForce(cameraPivot.transform.forward * forwardInput * speed );
        
        PowerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            PowerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupcountDownRoutine());
        }

        IEnumerator PowerupcountDownRoutine()
        {
            yield return new WaitForSeconds(7);
            hasPowerup = false;
            PowerupIndicator.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
           
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * PowerupStrength, ForceMode.Impulse);
        }
    }
}
