using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private GameObject enemy;

    
    // Update is called once per frame
    void Update()
    {
       if (enemy == null) {
            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
            float scale = Random.Range(0.5f,5.0f);
            enemy.transform.localScale = new Vector3(1.0f, scale, 1.0f);




            Renderer renderer = enemy.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(Random.value, Random.value, Random.value);    
            }
       }
        Debug.DrawRay(enemy.transform.position, enemy.transform.forward * 5.0f, Color.red, 5.0f);
    }
}
