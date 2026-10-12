using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class player : MonoBehaviour
{
    public bool canJump = false;
    public float speed = 5f;
    public float jumpForce = 300f;
    public Rigidbody rb;
    public int itemCollected = 0;
    public TextMeshProUGUI CollectedItemsText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
            canJump = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -speed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(speed, 0, 0));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("item"))
        {
            Debug.Log("Collision detected with item: " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }
    public void CollectItem()
    {
        itemCollected++;
        Debug.Log("Item collected! Total items: " + itemCollected);
    }
}