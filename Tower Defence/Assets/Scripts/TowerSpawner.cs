using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private int towerBuildGold = 50; // Ÿ�� �Ǽ��� ���Ǵ� ���
    [SerializeField]
    private EnemySpawner enemySpawner; // ���� �ʿ� �����ϴ� �� ����Ʈ ���� ���
    [SerializeField]
    private PlayerGold playerGold; // Ÿ�� �Ǽ��� ��� ���Ҹ� ���� ���� ���

    public void SpawnTower(Transform tileTransform)
    {
        // Ÿ�� �Ǽ� ���� Ȯ��
        // 1. Ÿ���� �Ǽ��� ��ŭ ���� ������ Ÿ�� �Ǽ� X
        if (towerBuildGold > playerGold.CurrentGold)
        {
            return;
        }
        
        Tile tile = tileTransform.GetComponent<Tile>();

        // 2. ���� Ÿ���� ��ġ�� �̹� Ÿ���� �Ǽ��Ǿ� ������ Ÿ�� �Ǽ� X
        if (tile.IsBuildTower == true)
        {
            return;
        }

        // Ÿ���� �Ǽ��Ǿ� �������� ����
        tile.IsBuildTower = true;
        // Ÿ�� �Ǽ��� �ʿ��� ��常ŭ ����
        playerGold.CurrentGold -= towerBuildGold;
        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ� (Ÿ�Ϻ��� z�� -1�� ��ġ�� ��ġ)
        Vector3 position = tileTransform.position + Vector3.back;
        GameObject clone = Instantiate(towerPrefab, position, Quaternion.identity);
        // Ÿ�� ���⿡ enemySpawner ���� ����
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
    }
}
