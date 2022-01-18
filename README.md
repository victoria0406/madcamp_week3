# 113 Escape_room
작동만 하면 되는것 아닐까요?  네
![reality_of_developer](https://user-images.githubusercontent.com/77565951/149667849-bca4690b-eb90-4e5e-930d-55c66f0f4784.gif)   

> 113호 방탈출

## Story
늦게까지 술을 마시고 113호에 갇힌 주인공   
어떻게 된 건지 기억이 나질 않는데 과연 탈출 할 수 있을까?
<details>
<summary>전체 스토리</summary>
<div markdown="1">

 자신을 귀찮게 하는 희종때문에 화가 난 병규
 희종을 불법감금을 한 사람으로 만들어 몰입캠프에서 쫓아내기 위해 술자리 이후 주인공을 가두고 희종이가 범인인 것처럼 꾸며내는 계획을 한다.
 그러나 계획을 허술하게 해서 주인공은 탈출한다. 병규는 그 사실을 모르고 자고 있는데 과연 그 이후는 어떻게 될까...
    
 
 *이 내용은 실화와 0.1%만 관련있음을 알려드립니다*
 

</div>
</details>   


## Game_Logic   
![gamelogic](https://user-images.githubusercontent.com/77565951/149778113-75bfa07e-9285-4b56-b92b-1b0d1acaa655.jpg)


## Game_Play

스크린 샷 + gif

## 개발환경
- unity 2020.3.25f(c#)
  * ARfoundation
  * ARcore
## Tech   
이미지 트랙킹
유니티 AR 

## 주요코드 설명

### 이미지 트래킹
  + 이미지를 학습시켜서 카메라로 특정 이미지를 인식하면 가상의 물체가 뜨도록 구현하였습니다. 기존의 AR Core에서 제공하는 라이브러리는 한 게임당 한 번씩만 사용할 수 있기 때문에 다중인식을 구현하기 위해서 다음과 같은 코드를 작성하여 각 물체마다 다른 오브젝트가 나타나도록 구현했습니다.

  ```
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTrackedMultiImageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[]    trackedPrefabs;//이미지를 인식했을 때 출력되는 프리팹 목록

    //이미지를 인식했을 때 출력되는 오브젝트 목록
    private Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        //AR Session Origin 오브젝트에 컴포넌트로 적용했을 때 사용 가능
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        //trackedPrefabs 배열에 있는 모든 프리팹을 Instantiate()로 생성한 후
        //spawnedObjects Dictionary에 저장, 비활성화
        //카메라에 이미지가 인식되면 이미지와 동일한 이름의 key에 있는 value 오브젝트를 출력
        foreach(GameObject prefab in trackedPrefabs)
        {
            GameObject clone = Instantiate(prefab);//오브젝트 생성
            clone.name = prefab.name;//생성한 오브젝트의 이름 설정
            clone.SetActive(false);//오브젝트 비활성화
            spawnedObjects.Add(clone.name, clone);//Dictionary에 오브젝트 저장
        }

    }
    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }
    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //카메라에 이미지가 인식되었을 때
        foreach(var trackedImage in eventArgs.added)
        {
            UpdateImage(trackedImage);
        }
        //카메라에 이미지가 인식되어 업데이트 되고 있을 때
        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateImage(trackedImage);
        }
        //인식되고 있는 이미지가 카메라에서 사라졌을 때
        foreach (var trackedImage in eventArgs.removed)
        {
            spawnedObjects[trackedImage.name].SetActive(false);
        }

    }
    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        GameObject trackedObject = spawnedObjects[name];
        //이미지의 추적상태가 추적중일때
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            trackedObject.transform.position = trackedImage.transform.position;
            trackedObject.transform.rotation = trackedImage.transform.rotation;
            trackedObject.SetActive(true);
        }
        else
        {
            trackedObject.SetActive(false);
        }
    }


}
  ```


## Developer

| devinfo | github |
| ------ | ------ |
| 박도윤 | [깃허브주소](https://github.com/victoria0406) |
| 박시형 | [깃허브주소](https://github.com/sihyeong671) |
| 이서진 | [깃허브주소](https://github.com/metamong-Hi) |

