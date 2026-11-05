using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject fantasmaPrefab;
    [SerializeField] private GameObject radio;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float spawnInterval = 50f;

    private List<GameObject> enemigosActivos = new List<GameObject>();
    
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, fantasmaPrefab));
    }

     private IEnumerator spawnEnemy(float interval, GameObject enemyPrefab)
    {
        yield return new WaitForSeconds(interval);
        GameObject nuevoEnemigo = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemigosActivos.Add(nuevoEnemigo);
        StartCoroutine(spawnEnemy(interval, enemyPrefab));
    }

    public void DesactivarEnemigos()
    {
        foreach (GameObject enemigo in enemigosActivos)
        {
            if (enemigo != null)
            {
                Destroy(enemigo);
            }
        }
        enemigosActivos.Clear();
    }
}