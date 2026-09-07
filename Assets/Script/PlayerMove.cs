using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 5f; // Speed of the player movement
    [SerializeField] float rotateSpeed = 120f; // Speed of the player rotation
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        Debug.Log("Collision happened."+collision.gameObject.name);
        if (collision.collider.CompareTag("Tree"));
        {
            Debug.Log("Hitting Obstacle");

        }
    }
}
