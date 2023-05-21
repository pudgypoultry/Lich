using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerblin : BaseCard
{
    public static string ID = "Gerblin";

    private void Start()
    {
        
    }

    public override void Use()
    {
        Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z+2), Quaternion.identity);
    }

}