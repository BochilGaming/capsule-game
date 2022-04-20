using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] TerrainsName = {
        "Terrains/Terrain_1",
        "Terrains/Terrain_2",
        "Terrains/Terrain_3",
        "Terrains/Terrain_4",
        "Terrains/Terrain_5",
    };
    private List<Terrain> TerrainsTerrain = new List<Terrain>();
    private GameObject Capsule;
    private index Index;
    void Awake()
    {
        for (int i = 0; i < this.TerrainsName.Length; i++) this.TerrainsTerrain.Add(Resources.Load<Terrain>(this.TerrainsName[i]));
        this.Capsule = this.gameObject;
        this.Index = this.gameObject.GetComponent<index>();
        this.SpawnTerrain(null);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] TerrainsGameObjects = GameObject.FindGameObjectsWithTag("terrain");
        if (TerrainsGameObjects.Length < 3) this.SpawnTerrain(TerrainsGameObjects[TerrainsGameObjects.Length - 1].transform.position + new Vector3(500, 0, 0));
        TerrainsGameObjects = GameObject.FindGameObjectsWithTag("terrain");
        foreach (GameObject TerrainGameObject in TerrainsGameObjects) 
        {
            if (TerrainGameObject.transform.position.x < (this.Capsule.transform.position.x - 550)) Destroy(TerrainGameObject);
            TerrainGameObject.transform.position += new Vector3(-this.Index.Speed, 0, 0);
        }

    }

    void SpawnTerrain(Vector3? Position)
    {
        Terrain TerrainRandom = this.TerrainsTerrain[Random.Range(0, this.TerrainsName.Length)];
        Terrain NewTerrain = Instantiate(TerrainRandom, Position ?? new Vector3(0, 0, 0), Quaternion.identity);
        NewTerrain.gameObject.tag = "terrain";
    }
}
