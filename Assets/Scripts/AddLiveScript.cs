using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLiveScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
