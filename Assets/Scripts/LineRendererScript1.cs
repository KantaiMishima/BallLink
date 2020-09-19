using UnityEngine;
using System.Collections;

public class LineRendererScript1 : MonoBehaviour
{
    [SerializeField] ClickBall clickball;
    LineRenderer linerenderer;
    MeshCollider meshcollider;
    void Start()
    {
        //GetComponent<LineRenderer>().material.color = new Color(0f, 0f, 0f, 0f);
        linerenderer = GetComponent<LineRenderer>();
      
        linerenderer.enabled=false;

        meshcollider = GetComponent<MeshCollider>();

        Mesh mesh = new Mesh();
        linerenderer.BakeMesh(mesh, true);
        meshcollider.sharedMesh = mesh;

    }
    
    void Update()
    {
        
        GameObject cube_1 = clickball.getgameobject1();
        GameObject cube_2 = clickball.getgameobject2();
        if (cube_1 == null || cube_2 == null)
        {
            return;
        }
        //Debug.Log("b");
        linerenderer.enabled = true;
        linerenderer.SetPosition(0, cube_1.transform.position);
        linerenderer.SetPosition(1, cube_2.transform.position);
        Ray();
        /*
                meshcollider = GetComponent<MeshCollider>();

                Mesh mesh = new Mesh();
                linerenderer.BakeMesh(mesh, true);
                meshcollider.sharedMesh = mesh;
                */

    }

    private void OnTriggerEnter(Collider other)
    {
       
        
        

        if (other.gameObject.tag == "dot") 
        {
        Destroy(other.gameObject);

            Debug.Log("a");
        }
    }

    void Ray()
    {
        //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
        Ray ray = new Ray(clickball.getgameobject1().transform.position, clickball.getgameobject2().transform.position);

        //Rayが当たったオブジェクトの情報を入れる箱
        RaycastHit hit;

        //Rayの飛ばせる距離
        
       
        float distance = (clickball.getgameobject1().transform.position - clickball.getgameobject2().transform.position).magnitude;


        //もしRayにオブジェクトが衝突したら
        //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
        if (Physics.Raycast(ray, out hit, distance))
        {
            //Rayが当たったオブジェクトのtagがPlayerだったら
            if (hit.collider.tag == "dot")
            {
                Debug.Log("Rayがdotに当たった");
                Destroy(hit.transform.gameObject);
            }
        }
    }
}


/*
 * Failed to create Convex Mesh from source mesh "".
 * An internal unspecified error has occured that could mean the Quickhull algorithm found the input mesh topologically challenging. 
 * UnityEngine.MeshCollider:set_sharedMesh(Mesh)
*/



