using UnityEngine;

[CreateAssetMenu]
public class TowerTemplate : ScriptableObject
{
    public GameObject towerPrefab; // 타워 생성을 위한 프리팹
    public GameObject followTowerPrefab; // 임시 타워 프리팹
    public Weapon[] weapon; // 레벨별 타워(무기) 정보

    [System.Serializable]
    public struct Weapon
    {
        public Sprite sprite; // 보여지는 타워 이미지 (UI)
        public float damage; // 공격력
        public float slow; // 감속 퍼센트
        public float buff; // 공격력 증가율
        public float rate; // 공격 속도
        public float range; // 공격 범위
        public int cost; // 필요 골드
        public int sell; // 타워 판매 시 획득 골드
    }
}
