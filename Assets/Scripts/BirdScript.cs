using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;  // Reference (посилання) на компонент того ж Game Object, на якому скріпт
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BirdScript Start");
        // пошук компонента та одержання посилання на нього
        rigidBody = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rigidBody.AddForce(new Vector2(0, 300));
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            rigidBody.AddForce(new Vector2(100, 150));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidBody.AddForce(new Vector2(-100, 150));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidBody.AddForce(new Vector2(0, -50));
        }
    }
}
