using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    [SerializeField] Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(this.gameObject.tag))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = mat;
            
        }
    }
}
