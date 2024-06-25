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
[SerializeField]    - ������,�� ������� ��, �� �������� ��� ���� ���� ��������� ����� "��������".
Translate           - ���������� �� ����� �������� (����� ����).
Time.deltaTime      - ���, �� ������� �� ������������ ������� ������.
�������� �� ��� (�������� �� Time.deltaTime) ������� FPS-�����������.
 */