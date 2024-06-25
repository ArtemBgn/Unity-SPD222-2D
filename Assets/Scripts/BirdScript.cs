using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI passedLabel;
    [SerializeField]
    private GameObject alert;
    [SerializeField]
    private TMPro.TextMeshProUGUI alertLabel;
    [SerializeField]
    private int lives;
    [SerializeField]
    private TMPro.TextMeshProUGUI alertLabel1;

    private Rigidbody2D rigidBody;  // Reference (посилання) на компонент того ж Game Object, на якому скріпт
    private int score;
    private bool needClear;
    private bool heartClear;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BirdScript Start");
        // пошук компонента та одержання посилання на нього
        rigidBody = GetComponent<Rigidbody2D> ();
        score = 0;
        needClear = false;
        heartClear = false;
        HideAlert();
        HeartAlert();
        lives = 5;
        //alert = ;
        //alertLabel = ;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            rigidBody.AddForce(new Vector2(0, 300) * Time.timeScale);
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            rigidBody.AddForce(new Vector2(100, 150) * Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            rigidBody.AddForce(new Vector2(-100, 150) * Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            rigidBody.AddForce(new Vector2(0, -50) * Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(alert.active)
            {
                HideAlert();
            }
            else
            {
                ShowAlert("Paused!");
            }
        }
    }

    //Подія, що виникає при перетені коллайдерів-тригерів    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Collision!! " + other.gameObject.name);
            needClear = true;
            --lives;

            if ( lives < 1 )
            {
                ShowAlert($"GAME OVER!!!\nВаш результатт: {score}");
                score = 0;
                lives = 5;
                passedLabel.text = score.ToString("D3");
            }
            else
            {
                ShowAlert("OOOOPS!");
            }
            
            Debug.Log("Lives: " + lives.ToString());
            alertLabel1.text = lives.ToString();
        }
    }
    // Подія, що виникає при роз'єднанні колайдерів-тригерів
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pass"))
        {
            Debug.Log("+1");
            score++;
            passedLabel.text = score.ToString("D3");
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            GameObject.Destroy(other.gameObject);
            lives++;
            Debug.Log("Lives: " + lives.ToString());
            alertLabel1.text = lives.ToString();
        }
    }
    private void ShowAlert(string message)
    {
        alert.SetActive(true);
        alertLabel.text = message;
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void HideAlert()
    {
        alert.SetActive(false);
        Time.timeScale = 1f;
        if(needClear)
        {
            foreach(var pipe in GameObject.FindGameObjectsWithTag("Pass"))
            {
                GameObject.Destroy(pipe);
            }
            needClear = false;
        }
    }
    public void HeartAlert()
    {
        //alert.SetActive(false);
        Time.timeScale = 1f;
        if(heartClear)
        {
            foreach (var live in GameObject.FindGameObjectsWithTag("Heart"))
            {
                GameObject.Destroy(live);
            }
            heartClear = false;
        }
    }
}
