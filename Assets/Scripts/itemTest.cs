using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DrugProp drug = (DrugProp)ItemPropFactory.Instance.CreateItemById(10);
            Debug.Log($"hp:{drug.hp} + mp:{drug.mp}");
        }
    }
}
