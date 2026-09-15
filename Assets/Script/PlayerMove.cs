using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 5f; // Speed of the player movement
    [SerializeField] float rotateSpeed = 120f; // Speed of the player rotation
    bool hasPackage = false;
    SpriteRenderer PlayerRender;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRender = GetComponent<SpriteRenderer>();

        Debug.Log("Player Sprite Renderer: " + PlayerRender);
    }


    // Update is called once per frame
    void Update()
    {
        //Rotation of player when pressing Q
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime); 
        }
        { 
            if(Input.GetKey(KeyCode.E))
         transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
        }
       
        float x = Input.GetAxis("Horizontal"); // This to - or + 1 for the x
        float y = Input.GetAxis("Vertical"); // This to - or + 1 for the y
        Vector3 Move = new Vector3(x, y, 0f);
        //transform.Rotate(0f, 0.4f, 0f); // Rotate the player around the y-axis
        transform.Translate(Move * moveSpeed*Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision happened." + collision.gameObject.name);

        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Grabbing Package");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // PICK UP PACKAGE
        if (other.CompareTag("Package") && hasPackage == false)
        {
            hasPackage = true;

            Debug.Log("Picked up the package.");

            // Change Player color
            PlayerRender.color = Color.red;

            // Destroy the package
            Destroy(other.gameObject);
        }

        // DELIVER PACKAGE
        if (other.CompareTag("Customer") && hasPackage == true)
        {
            hasPackage = false;

            // Return Player to original color
            PlayerRender.color = Color.white;

            // Print delivery message
            Debug.Log("Package delivered!");
        }
    }
}