using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] CactusNames = {
        // "CactusPack/Meshes/Cactus_Short_01",
        // "CactusPack/Meshes/Cactus_Short_02",
        // "CactusPack/Meshes/Cactus_Short_03",
        "CactusPack/Meshes/Cactus_Tall_01",
        "CactusPack/Meshes/Cactus_Tall_02",
        "CactusPack/Meshes/Cactus_Tall_03"
    };
    private List<GameObject> CactusGameObjects = new List<GameObject>();
    public float TimeBetweenSpawn = 1.5f;
    private float LastSpawn;
    private GameObject Capsule;
    private index Index;
    void Start()
    {
        for (int i = 0; i < this.CactusNames.Length; i++) this.CactusGameObjects.Add(Resources.Load<GameObject>(this.CactusNames[i]));
        this.Capsule = GameObject.FindGameObjectWithTag("capsule");
        this.Index = this.Capsule.GetComponent<index>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!this.Index.IsPlaying) return;
        float TimeBetweenSpawn = this.TimeBetweenSpawn - this.Index.Speed * 1.1f;
        if (Time.time - this.LastSpawn >= (TimeBetweenSpawn <= 0 ? 0.15f : TimeBetweenSpawn))
        {
            this.SpawnCactus();
            this.LastSpawn = Time.time;
        }
        GameObject[] CactusGameObjects = GameObject.FindGameObjectsWithTag("cactus");
        foreach (GameObject Cactus in CactusGameObjects)
        {
            if (Cactus.transform.position.x < (this.Capsule.transform.position.x - 10)) Destroy(Cactus);
            Cactus.transform.position += new Vector3(-this.Index.Speed, 0, 0);
        }
    }

    private void SpawnCactus()
    {
        GameObject CactusRandom = this.CactusGameObjects[Random.Range(0, this.CactusGameObjects.Count)];
        Vector3 CactusRandomPosition = new Vector3(Random.Range(this.Capsule.transform.position.x + 20, this.Capsule.transform.position.x + 50), 0.01f, Random.Range(this.Capsule.transform.position.z - 5, this.Capsule.transform.position.z + 5));
        GameObject NewCactus = GameObject.Instantiate(CactusRandom, CactusRandomPosition, Quaternion.identity);
        NewCactus.tag = "cactus";


        // Add boxcollider
        NewCactus.AddComponent<BoxCollider>();
        BoxCollider CactusCollider = NewCactus.GetComponent<BoxCollider>();

        // Add rigidbody
        NewCactus.AddComponent<Rigidbody>();
        Rigidbody CactusRigidbody = NewCactus.GetComponent<Rigidbody>();
        CactusRigidbody.angularDrag = 0;
        CactusRigidbody.useGravity = false;
        CactusRigidbody.isKinematic = true;
        CactusRigidbody.interpolation = RigidbodyInterpolation.Extrapolate;


    }

}
