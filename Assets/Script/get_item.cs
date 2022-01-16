using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class get_item : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public GameObject canvas;

    public GameObject content;

    private RaycastHit hit;
    private GameObject panel;
    float rotSpeed = 10f;

    string main_ment="";
    string sub_ment="";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) //�̰� ī�޶� �޶� �ȸ����ϱ� ����
            {
                Debug.Log("block");
                return;
            }
            else { 
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    string objectName = hit.collider.gameObject.name;
                    Debug.Log(objectName);
                    //hit.collider.gameObject.SetActive(false);
                    Destroy(hit.collider.gameObject);

                    //���� �����ۺ� ��Ʈ
                    if (objectName == "Glasses")
                    {
                        main_ment = "�Ȱ��� ȹ���߽��ϴ�";
                        sub_ment = "���� �Ȱ��� ã�Ҵ�. ������ �� ���̴±�";
                        content.transform.Find("B_glasses").gameObject.SetActive(true);
                    }
                    else if (objectName == "Box")
                    {
                        main_ment = "���ڸ� ȹ���߽��ϴ�";
                        sub_ment = "���ڸ� �����";
                        content.transform.Find("B_mag").gameObject.SetActive(true);
                    }
                    else if (objectName == "jang's_book")
                    {
                        main_ment = "�庴�Դ��� ������ �߰��ߴ�.";
                        sub_ment = "���� ���� �� �Ӹ�ī���� ���̴µ�? �����ϱ�?";
                        content.transform.Find("B_hid").gameObject.SetActive(true);
                    }
                    canvas.transform.Find("main_ment").gameObject.SetActive(true);
                    canvas.transform.Find("Script").gameObject.SetActive(true);
                    canvas.transform.Find("main_ment").GetComponent<Text>().text = main_ment;
                    canvas.transform.Find("Script").GetComponent<Text>().text = sub_ment;
                    StartCoroutine(delete_ment());
                }
            }
        }
    }

    IEnumerator delete_ment()
    {
        yield return new WaitForSeconds(1.0f);
        canvas.transform.Find("main_ment").gameObject.SetActive(false);
        canvas.transform.Find("Script").gameObject.SetActive(false);

    }
}
