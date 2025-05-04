using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private TowerTemplate towerTemplate;
    [SerializeField]
    private EnemySpawner enemySpawner; // 현재 맵에 존재하는 적 리스트 정보 얻기
    [SerializeField]
    private PlayerGold playerGold; // 타워 건설시 골드 감소를 위한 정보 얻기
    [SerializeField]
    private SystemTextViewer systemTextViewer; // 돈 부족, 건설 불가와 같은 시스템 메시지 출력

    public void SpawnTower(Transform tileTransform)
    {
        // 타워 건설 여부 확인
        // 1. 타워를 건설할 만큼 돈이 없으면 타워 건설 X
        if (towerTemplate.weapon[0].cost > playerGold.CurrentGold)
        {
            // 골드가 부족해서 타워 건설이 불가능하다고 출력
            systemTextViewer.PrintText(SystemType.Money);
            return;
        }
        
        Tile tile = tileTransform.GetComponent<Tile>();

        // 2. 현재 타일의 위치에 이미 타워가 건설되어 있으면 타워 건설 X
        if (tile.IsBuildTower == true)
        {
            // 현재 위치에 타워 건설이 불가능하다고 출력
            systemTextViewer.PrintText(SystemType.Build);
            return;
        }

        // 타워가 건설되어 있음으로 설정
        tile.IsBuildTower = true;
        // 타워 건설에 필요한 골드만큼 감소
        playerGold.CurrentGold -= towerTemplate.weapon[0].cost;
        // 선택한 타일의 위치에 타워 건설 (타일보다 z축 -1의 위치에 배치)
        Vector3 position = tileTransform.position + Vector3.back;
        GameObject clone = Instantiate(towerTemplate.towerPrefab, position, Quaternion.identity);
        // 타워 무기에 enemySpawner 정보 전달
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner, playerGold, tile);
    }
}
