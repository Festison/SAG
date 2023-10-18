using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // 카메라 매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    // 이 게임 내에서 게임매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    static public CameraManager instance;

    [Header ("카메라가 따라갈 대상")]
    public GameObject target; // 카메라가 따라갈 대상.

    [Header("카메라 속도")]
    public float moveSpeed; // 카메라가 얼마나 빠른 속도로
    private Vector3 targetPosition; // 대상의 현재 위치 

    [Header("카메라가 제한할 영역")]
    public Collider2D bound; // 콜라이더들이 들어갈 장소 

    // 박스 컬라이더 영역의 최소 최대 xyz값을 지님.
    private Vector3 minBound;
    private Vector3 maxBound;

    // 카메라의 반너비, 반높이 값을 지닐 변수.
    private float halfWidth;
    private float halfHeight;

    // 카메라의 반높이값을 구할 속성을 이용하기 위한 변수.
    private Camera theCamera;

    // Awake 는 일반적으로 게임이 시작되기 전에 호출 (start 보다 먼저 호출) 되며, 모든 오브젝트가 초기화되고 호출된다.
    // 따라서 GameObject.FindWithTag 를 이용해 해당 게임 오브젝트를 요처하거나 다른 오브젝트와 안전하게 상호작용기 가능하다.
    // [주의] : 각 게임 오브젝트의 Awake() 는 랜덤 순서로 실행되므로, 스크립트간의 참조(reference) 를 설정하기 위해 Awake 를 사용하고, 정보를 보내고 받는 경우에는 Start 를 사용해야 한다.

    private void Awake()
    {
        // 만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 CameraManager가 존재할 수도 있다.
        // 그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
        // 그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 CameraManager)를 삭제해준다.
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        // 이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
        else
        {
            // 씬 전환이 되더라도 파괴되지 않게 한다.
            // gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            // 나는 헷갈림 방지를 위해 this를 붙여준다.
            DontDestroyOnLoad(this.gameObject);

            instance = this;
        }
    }

    // Start() : Update 메소드가 처음 호출되기 바로 전에 한 번만 호출
    // Start 는 Behaviour 의 주기 동안에 한번만 호출된다.
    // Start() 는 Script Instance 로 활성화 된 경우에만 실행되는데, 이는 스크립트가 컴포넌트로 있을 때를 이야기한다. (GameObject 에 추가로 인스턴스가 되는 경우)

    void Start()
    {
        // 카메라 컴포넌트를 가져온다.
        theCamera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void Update()
    {

        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime); // 1초에 movespeed만큼 이동.

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);

        }
    }

    // 새로운 Collider를 넣어준다.
    public void SetBound(Collider2D newBound)
    {
        bound = newBound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }
}