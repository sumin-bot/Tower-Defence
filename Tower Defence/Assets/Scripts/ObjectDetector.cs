using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner towerSpawner;
    [SerializeField]
    private TowerDataViewer towerDataViewer;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        // "MainCamera" �±׸� ������ �ִ� ������Ʈ Ž�� �� Camera ������Ʈ ���� ����
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            // ī�޶� ��ġ���� ȭ���� ���콺 ��ġ�� �����ϴ� ���� ����
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // 2D ����͸� ���� 3D ������ ������Ʈ�� ���콺�� �����ϴ� ���
            // ������ �ε����� ������Ʈ�� �����ؼ� hit�� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // ������ �ε��� ������Ʈ�� �±װ� "Tile"�̸�
                if (hit.transform.CompareTag("Tile"))
                {
                    // Ÿ���� �����ϴ� SpawnTower() ȣ��
                    towerSpawner.SpawnTower(hit.transform);
                }
                // Ÿ���� �����ϸ� �ش� Ÿ�� ������ ����ϴ� Ÿ�� ����â On
                else if (hit.transform.CompareTag("Tower"))
                {
                    towerDataViewer.OnPanel(hit.transform);
                }
            }
        }
    }
}
