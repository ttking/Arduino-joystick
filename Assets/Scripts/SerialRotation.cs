using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class SerialRotation : MonoBehaviour {

	SerialPort stream = new SerialPort("COM3", 9600);
	float[] lastRot = {0,0,0};


	void Start () {
		stream.Open(); 
	}


	void Update () {
		string value = stream.ReadLine();
		string[] vec3 = value.Split(',');
		if(vec3[0] != "" && vec3[1] != "" && vec3[2] != "")
		{
			transform.Rotate(
				float.Parse(vec3[0])-lastRot[0],
				float.Parse(vec3[1])-lastRot[1],
				float.Parse(vec3[2])-lastRot[2],
				Space.Self
			);

			lastRot[0] = float.Parse(vec3[0]);
			lastRot[1] = float.Parse(vec3[1]);
			lastRot[2] = float.Parse(vec3[2]);
			stream.BaseStream.Flush();
		}
	}

	void OnGUI()
	{
		string newString = "Connected: " + transform.rotation.x + ", " + transform.rotation.y + ", " + transform.rotation.z;
		GUI.Label(new Rect(10,10,300,100), newString);

	}
}
