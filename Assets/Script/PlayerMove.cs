using UnityEngine;

public class PlayerMove : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 5f; // Speed of the player movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // This to - or + 1 for the x
        float y = Input.GetAxis("Vertical"); // This to - or + 1 for the y
        Vector3 Move = new Vector3(x, y, 0f);
        transform.Translate(Move * moveSpeed*Time.deltaTime);

    }
}
