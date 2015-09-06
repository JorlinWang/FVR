using UnityEngine;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System;

public class SeriaOrDeSeria {

	public static void SerialzeXML<T>(string path, T go){
		if (string.IsNullOrEmpty (path)) {
			StackFrame frame = new StackFrame(1);
			MethodBase method = frame.GetMethod();
			UnityEngine.Debug.Log(string.Format("The path param is null, from {0} class's {1} method, please check it.",
			                                    method.ReflectedType.Name, method.Name));
			return;
		}
		XmlSerializer xmls = new XmlSerializer (go.GetType());
		StringWriter sw = new StringWriter ();
		xmls.Serialize (sw, go);
		string str = sw.ToString ();
		str = str.Replace ("utf-16", "utf-8");
		byte[] bytes = System.Text.Encoding.UTF8.GetBytes (str);
		sw.Close ();
		FileStream fs;
		if (File.Exists (path)) {
			File.Delete (path);
		}
		fs = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
		fs.Write (bytes, 0, bytes.Length);
		fs.Close ();
		fs.Dispose ();
	}

	public static object DeSerialzeXML(string path, Type go) {
		if (string.IsNullOrEmpty (path) || !File.Exists(path)) {
			StackFrame frame = new StackFrame(1);
			MethodBase method = frame.GetMethod();
			UnityEngine.Debug.Log(string.Format("The path param is null or error, from {0} class's {1} method, please check it.",
			                                    method.ReflectedType.Name, method.Name));
			return null;
		}
		XmlSerializer xmls = new XmlSerializer (go);
		FileStream fs = File.Open (path, FileMode.Open);
		object temp = xmls.Deserialize (fs);
		fs.Close ();
		fs.Dispose ();
		return temp;
	}
}
