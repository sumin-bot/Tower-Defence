using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner; // ���� �ʿ� �����ϴ� �� ����Ʈ ���� ���

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        // Ÿ�� �Ǽ� ���� Ȯ�� (Ÿ���� �Ǽ��Ǿ� ���� ���)
        if (tile.IsBuildTower == true)
        {
            return;
        }

        // Ÿ���� �Ǽ��Ǿ� ���� ���� ���
        tile.IsBuildTower = true;
        
        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        // Ÿ�� ���⿡ enemySpawner ���� ����
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
    }
}
