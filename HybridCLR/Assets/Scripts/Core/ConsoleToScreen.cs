using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ConsoleToScreen : MonoBehaviour
    {
        private const int MaxLines = 50;
        private const int MaxLineLength = 120;
        private string _logStr = "";

        private readonly List<string> _lines = new();

        public int fontSize = 15;

        void OnEnable() { Application.logMessageReceived += Log; }
        void OnDisable() { Application.logMessageReceived -= Log; }

        private void Log(string logString, string stackTrace, LogType type)
        {
            foreach (var line in logString.Split('\n'))
            {
                if (line.Length <= MaxLineLength)
                {
                    _lines.Add(line);
                    continue;
                }
                var lineCount = line.Length / MaxLineLength + 1;
                for (var i = 0; i < lineCount; i++)
                {
                    _lines.Add((i + 1) * MaxLineLength <= line.Length
                        ? line.Substring(i * MaxLineLength, MaxLineLength)
                        : line.Substring(i * MaxLineLength, line.Length - i * MaxLineLength));
                }
            }
            if (_lines.Count > MaxLines)
            {
                _lines.RemoveRange(0, _lines.Count - MaxLines);
            }
            _logStr = string.Join("\n", _lines);
        }

        private void OnGUI()
        {
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
                new Vector3(Screen.width / 1200.0f, Screen.height / 800.0f, 1.0f));
            GUI.Label(new Rect(10, 10, 800, 370), _logStr, new GUIStyle() { fontSize = Math.Max(10, fontSize) });
        }
    }
}
