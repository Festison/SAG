using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // ī�޶� �Ŵ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    // �� ���� ������ ���ӸŴ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    static public CameraManager instance;

    [Header ("ī�޶� ���� ���")]
    public GameObject target; // ī�޶� ���� ���.

    [Header("ī�޶� �ӵ�")]
    public float moveSpeed; // ī�޶� �󸶳� ���� �ӵ���
    private Vector3 targetPosition; // ����� ���� ��ġ 

    [Header("ī�޶� ������ ����")]
    public Collider2D bound; // �ݶ��̴����� �� ��� 

    // �ڽ� �ö��̴� ������ �ּ� �ִ� xyz���� ����.
    private Vector3 minBound;
    private Vector3 maxBound;

    // ī�޶��� �ݳʺ�, �ݳ��� ���� ���� ����.
    private float halfWidth;
    private float halfHeight;

    // ī�޶��� �ݳ��̰��� ���� �Ӽ��� �̿��ϱ� ���� ����.
    private Camera theCamera;

    // Awake �� �Ϲ������� ������ ���۵Ǳ� ���� ȣ�� (start ���� ���� ȣ��) �Ǹ�, ��� ������Ʈ�� �ʱ�ȭ�ǰ� ȣ��ȴ�.
    // ���� GameObject.FindWithTag �� �̿��� �ش� ���� ������Ʈ�� ��ó�ϰų� �ٸ� ������Ʈ�� �����ϰ� ��ȣ�ۿ�� �����ϴ�.
    // [����] : �� ���� ������Ʈ�� Awake() �� ���� ������ ����ǹǷ�, ��ũ��Ʈ���� ����(reference) �� �����ϱ� ���� Awake �� ����ϰ�, ������ ������ �޴� ��쿡�� Start �� ����ؾ� �Ѵ�.

    private void Awake()
    {
        // ���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� CameraManager�� ������ ���� �ִ�.
        // �׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
        // �׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� CameraManager)�� �������ش�.
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        // �� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
        else
        {
            // �� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            // gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            // ���� �򰥸� ������ ���� this�� �ٿ��ش�.
            DontDestroyOnLoad(this.gameObject);

            instance = this;
        }
    }

    // Start() : Update �޼ҵ尡 ó�� ȣ��Ǳ� �ٷ� ���� �� ���� ȣ��
    // Start �� Behaviour �� �ֱ� ���ȿ� �ѹ��� ȣ��ȴ�.
    // Start() �� Script Instance �� Ȱ��ȭ �� ��쿡�� ����Ǵµ�, �̴� ��ũ��Ʈ�� ������Ʈ�� ���� ���� �̾߱��Ѵ�. (GameObject �� �߰��� �ν��Ͻ��� �Ǵ� ���)

    void Start()
    {
        // ī�޶� ������Ʈ�� �����´�.
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

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime); // 1�ʿ� movespeed��ŭ �̵�.

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);

        }
    }

    // ���ο� Collider�� �־��ش�.
    public void SetBound(Collider2D newBound)
    {
        bound = newBound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }
}