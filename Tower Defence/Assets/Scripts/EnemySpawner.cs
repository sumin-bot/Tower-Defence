using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; // �� ������
    [SerializeField]
    private float spawnTime; // �� ���� �ֱ�
    [SerializeField]
    private Transform[] wayPoints; // ���� ���������� �̵� ���
    private List<Enemy> enemyList; // ���� �ʿ� �����ϴ� ��� ���� ����

    public List<Enemy> EnemyList => enemyList;

    private void Awake()
    {
        // �� ����Ʈ �޸� �Ҵ�
        enemyList = new List<Enemy>();
        // �� ���� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab); // �� ������Ʈ ����
            Enemy enemy = clone.GetComponent<Enemy>(); // ��� ������ ���� Enemy ������Ʈ

            enemy.Setup(this, wayPoints); // wayPoints ������ �Ű������� Setup() ȣ��
            enemyList.Add(enemy); // ����Ʈ�� ��� ������ �� ���� ����

            yield return new WaitForSeconds(spawnTime); // spawnTime �ð� ���� ���
        }
    }

    public void DestroyEnemy(Enemy enemy)
    {
        // ����Ʈ���� ����ϴ� �� ���� ����
        enemyList.Remove(enemy);
        // �� ������Ʈ ����
        Destroy(enemy.gameObject);
    }
}
