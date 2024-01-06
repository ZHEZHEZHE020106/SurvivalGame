using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloner : MonoBehaviour
{
    public static EnemyCloner instance { get; set; } 

    public List<GameObject> EnemyClonerLocation;
    public GameObject Enemy;
    private float WaitTime = 240.0f;
    public GameObject EnemyClone;
    IEnumerator CloneEnemy()
    {
        
        if (!MainMenu.Instance.EasyMode)
        {
            WaitTime = WaitTime / 2;
        }
        while (true)
        {
            yield return new WaitForSeconds(WaitTime);
            GameObject e = Instantiate(Enemy.gameObject,EnemyClonerLocation[Random.Range(0, EnemyClonerLocation.Count)].transform.position,Quaternion.identity);
            e.transform.SetParent(EnemyClone.transform);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(CloneEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
