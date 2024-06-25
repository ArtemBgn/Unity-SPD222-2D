using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
/*
[SerializeField]    - атрібут,що зазначає те, що значення для поля буде визначено через "редактор".
Translate           - переміщення на задані значення (ефект руху).
Time.deltaTime      - час, що пройшов від попереднього виклику методу.
Корекція на час (множення на Time.deltaTime) створює FPS-незалежність.
 */