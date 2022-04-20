using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsule : MonoBehaviour
{
    private float lastChangePosition = 0;
    private GameObject Capsule;
    private Rigidbody CapsuleRB;
    private index Index;
    public float CameraDistance = 15;
    // Start is called before the first frame update
    void Start()
    {
        this.Capsule = this.gameObject;
        this.CapsuleRB = this.Capsule.GetComponent<Rigidbody>();
        this.Index = this.Capsule.GetComponent<index>();
        this.CameraDistance = Mathf.RoundToInt(Vector3.Distance(this.Capsule.transform.position, Camera.main.transform.position));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 CapsulePosition = this.Capsule.transform.position;

        // Move gameobject 
        float MovePosition = -100;
        if (Input.GetKey(KeyCode.LeftArrow) && CapsulePosition.z <= 405) MovePosition = 1.5f;
        if (Input.GetKey(KeyCode.RightArrow) && CapsulePosition.z >= 395) MovePosition = -1.5f;
        if (MovePosition != -100) this.Capsule.transform.position = Vector3.Lerp(CapsulePosition, new Vector3(CapsulePosition.x, CapsulePosition.y, CapsulePosition.z + MovePosition), Time.fixedDeltaTime * this.Index.ChangePosition);

        if (Input.GetKey(KeyCode.Space) && Mathf.Round(CapsulePosition.y) == 2)
        {
            Vector3 Velocity = new Vector3(0, (this.CapsuleRB.drag + this.CapsuleRB.mass) / 1.5f, 0 );
            Debug.Log(Velocity);
            this.CapsuleRB.velocity = Velocity;
        }

        // Move camera
        Vector3 CameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(CapsulePosition.x - this.CameraDistance, CameraPosition.y, CameraPosition.z);

        if (GameObject.FindGameObjectsWithTag("capsule").Length == 0) this.Index.IsPlaying = false;
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (!this.Index.IsPlaying) return;
        GameObject OtherGameObject = Other.gameObject;
        if (OtherGameObject.tag == "cactus") this.Index.GameOver(OtherGameObject, this.Capsule);
    }
}
