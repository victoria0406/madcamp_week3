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
            if (EventSystem.current.IsPointerOverGameObject()) //이거 카메라가 달라서 안먹으니까 고쳐
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

                    //각각 아이템별 멘트
                    if (objectName == "Glasses")
                    {
                        main_ment = "안경을 획득했습니다";
                        sub_ment = "드디어 안경을 찾았다. 이제야 잘 보이는군";
                        content.transform.Find("B_glasses").gameObject.SetActive(true);
                    }
                    else if (objectName == "Box")
                    {
                        main_ment = "상자를 획득했습니다";
                        sub_ment = "상자를 흔들어보자";
                        content.transform.Find("B_mag").gameObject.SetActive(true);
                    }
                    else if (objectName == "jang's_book")
                    {
                        main_ment = "장병규님의 저서를 발견했다.";
                        sub_ment = "여기 조금 긴 머리카락이 보이는데? 누구일까?";
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
