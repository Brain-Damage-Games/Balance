using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 116.45f;
    public float waterHeight = 0f;

    Rigidbody rb;
    bool underwater;
    int floatersUnderWater;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        floatersUnderWater = 0;
        float diff = transform.position.y - waterHeight;

        if (diff < 0)
        {
             rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(diff), transform.position, ForceMode.Force);
             floatersUnderWater += 1;
            if (!underwater)
             {
                   underwater = true;
                SwitchState(true);
            }
        }

        
        if (underwater && floatersUnderWater==0)
        {
            underwater = false;
            SwitchState(false);
        }
    }
    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            rb.drag = underWaterDrag;
            rb.angularDrag = underWaterAngularDrag;
        }
        else
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }
    }
}
