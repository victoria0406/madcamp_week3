using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start_script : MonoBehaviour
{
    public Text script;
    public Button next;

    int turn = 0;
    
    // Start is called before the first frame update

    string scriptl = "��? ���� �����?/�ͼ��� ����ε�?/��? �츮 ���̱����� �ٵ� �� ��ȥ�� ����?/�� �Ȱ��� ����־�?/�Ȱ��� ã�ƺ���/";

    string[] script_list;
    void Start()
    {
        next.onClick.AddListener(next_script);
        script_list = scriptl.Split('/');
        script.text = script_list[0];
        turn++;
    }
    // Update is called once per frame

    void next_script()
    {
        script.text = script_list[turn];
        turn++;
        if (turn == script_list.Length)
        {
            final_script();
        }
    }

    void final_script()
    {
        this.gameObject.SetActive(false);
    }
}
