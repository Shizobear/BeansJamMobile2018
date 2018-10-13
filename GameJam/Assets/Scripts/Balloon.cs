using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    public float shakeSpeed;
    public bool direction = false;
    private int counter = 0;
	public int counterMax;
    // Update is called once per frame
    void Update()
    {
        if (counter < counterMax && direction == false)
        {
            transform.position = transform.position + new Vector3(1 * shakeSpeed * Time.deltaTime, 0f);
            counter++;
        }
        else if(direction == false)
        {
            direction = true;
        }

        if (direction == true && counter > 0)
        {
            transform.position = transform.position + new Vector3(1 * -shakeSpeed * Time.deltaTime, 0f);
            counter--;
        } else if(counter == 0) {
			direction = false;
		}
    }
}
