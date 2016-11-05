using UnityEngine;
using System.Collections;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using System.Threading;
using SocketIO;


public class QR : MonoBehaviour
{
	
	private Texture2D encoded;
	private GUIStyle style;
	private SocketIOComponent socket;



	void Start ()
	{ 
		style = new GUIStyle ();
		style.normal.textColor = Color.black;

		socket = GameObject.Find ("SocketIO").GetComponent<SocketIO.SocketIOComponent> ();
		socket.On ("connection", getSocketData);

	}

	void getSocketData (SocketIOEvent e)
	{
		Debug.Log ("in Debug");
		Debug.Log(e.data.GetField("QRCode").ToString());
		makeQR (e.data.GetField ("QRCode").ToString ());
	}
		
	void makeQR (string message)
	{
		encoded = new Texture2D (256, 256);  
		var color32 = Encode (message, encoded.width, encoded.height);  
		encoded.SetPixels32 (color32);  
		encoded.Apply (); 
	}
	// for generate qrcode
	private static Color32[] Encode (string textForEncoding, int width, int height)
	{  
		var writer = new BarcodeWriter {  
			Format = BarcodeFormat.QR_CODE,  
			Options = new QrCodeEncodingOptions {  
				Height = height,  
				Width = width  
					
			}  
		};  
		return writer.Write (textForEncoding);  
	}

	void OnGUI ()
	{  
		if (encoded != null) {
			GUI.DrawTexture (new Rect (140, 50, 256, 256), encoded);  
			GUI.Label (new Rect (160, 50, 100, 20), "Please scan the code with your mobile", style);
		}
	}
}
