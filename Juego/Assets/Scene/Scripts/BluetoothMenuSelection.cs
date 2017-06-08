using UnityEngine;
using System.Collections;

public class BluetoothMenuSelection : MonoBehaviour {

	void ConnectionStateEvent(string state)
	{
		//Connection State event this is the result of the connection fire after you try to Connect
		switch (state)
		{
		case "STATE_CONNECTED":

			break;
		case "STATE_CONNECTING":

			break;
		case "UNABLE TO CONNECT":

			break;
		}
		Debug.Log(state);
		MenuSelection.Result = state;
	}
	void DoneSendingEvent(string writeMessage)
	{
		//Done sending the message event
		Debug.Log("writeMessage " + writeMessage);
		MenuSelection.Result = writeMessage;
	}
	void DoneReadingEvent(string readMessage)
	{
		//Done reading the message event
		Debug.Log("readMessage " + readMessage);
		MenuSelection.Read = readMessage;
	}
	void FoundZeroDeviceEvent()
	{
		//Event for the end of the search devices and there is zero device
		Debug.Log("FoundZeroDeviceEvent");
		MenuSelection.Result = "FoundZeroDeviceEvent";
	}
	void ScanFinishEvent()
	{
		//Event for the end of the current search
		Debug.Log("ScanFinishEvent");
		MenuSelection.Result = "ScanFinishEvent";
	}
	void FoundDeviceEvent(string Device)
	{
		//Event when the search find new device
		Debug.Log("FoundDeviceEvent");
		MenuSelection.Result = "FoundDeviceEvent";
		Bluetooth.Instance().MacAddresses.Add(Device);
	}
}
