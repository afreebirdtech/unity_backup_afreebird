using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject ColumnPrefab;
    private GameObject[] columns;
    public int Columnnum = 10;
    private Vector2 location = new Vector2(-20f,-20f);
    private float timeSinceLastSpawn = 0f;
    private float spawnRate = 4f;
    private int currentcolumn = 0;
    public float Maxy = 3f;
    public float Miny = -1f;
    private float SpawnXposition = 2f;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[Columnnum];
        for (int i = 0; i < Columnnum; i++)
        {
            columns[i] = Instantiate(ColumnPrefab, location, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentcolumn >= Columnnum)
        {
            return;
        } 
        timeSinceLastSpawn += Time.deltaTime;
        if(FlappyGameController.instance.gameover == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float cury = Random.Range(Miny, Maxy);
            columns[currentcolumn].transform.position = new Vector2(SpawnXposition, cury);
            currentcolumn++;
        }
    }
}
