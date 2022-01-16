using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonevent : MonoBehaviour
{
    // Start is called before the first frame update

    public Button bag_button;
    public GameObject bag_panel;
    private bool bag_active;


    public Button kyu_book_button;
    public Button not_kyu_book_button;


    public GameObject canvas;

    void Start()
    {
        bag_button.onClick.AddListener(Bag_click);
        bag_active = false;
        kyu_book_button.onClick.AddListener(find_book);
        not_kyu_book_button.onClick.AddListener(not_find_book);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Bag_click()
    {
        Debug.Log(bag_active);
        if (bag_active)
        {
            bag_panel.SetActive(false);
            bag_active = false;
        }
        else
        {
            bag_panel.SetActive(true);
            bag_active = true;
        }
        

    }

    void find_book()
    {
        kyu_book_button.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        string main_ment = "단서를 찾았습니다: 병규의 책이 사라짐";
        string sub_ment = "어제까지 있던 책이 사라졌네? 누가 들고간거지";
        canvas.transform.Find("main_ment").gameObject.SetActive(true);
        canvas.transform.Find("Script").gameObject.SetActive(true);
        canvas.transform.Find("main_ment").GetComponent<Text>().text = main_ment;
        canvas.transform.Find("Script").GetComponent<Text>().text = sub_ment;
        StartCoroutine(delete_ment());
    }

    void not_find_book()
    {
        string sub_ment = "여기가 아닌가봐";
        canvas.transform.Find("Script").gameObject.SetActive(true);
        canvas.transform.Find("Script").GetComponent<Text>().text = sub_ment;
        StartCoroutine(delete_ment());
    }

    IEnumerator delete_ment()
    {
        yield return new WaitForSeconds(1.0f);
        canvas.transform.Find("main_ment").gameObject.SetActive(false);
        canvas.transform.Find("Script").gameObject.SetActive(false);

    }
}
