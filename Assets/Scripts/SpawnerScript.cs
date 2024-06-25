using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private GameObject addLivePrefab;

    private float spawnPeriod = 5f;     // кожні 5 секунди
    private float addLivePeriod = 15f;  // кожні 15 секунди
    private float timeLeft;
    private int inLive;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 0f;
        inLive = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = spawnPeriod;
            SpawnPipe();
            --inLive;
            if (inLive == 0)
            {
                AddLivePipe();
                inLive = Random.Range(1, 9);
            }
        }
    }
    private void SpawnPipe()
    {
        var pipe = GameObject.Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position + Vector3.up * Random.Range(-2f, 2f);
    }
    private void AddLivePipe()
    {
        var live = GameObject.Instantiate(addLivePrefab);
        live.transform.position = this.transform.position + Vector3.right * Random.Range(-5f, 5f);
    }
}
