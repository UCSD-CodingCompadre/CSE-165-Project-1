using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_Debugger : MonoBehaviour
{

    // Hold the dictionary for the debug logs
    Dictionary<string, string> DebugLogs = new Dictionary<string, string>();

    // Hold the text mesh pro for the text 
    public TextMeshProUGUI Display;

    /*
     * @brief On every frame log out the time
     * @param none
     * @return void
     */
    private void Update()
    {

        // Log out the current time elapsed
        Debug.Log("Time: " + Time.time);

        // Return
        return;
    }

    /*
     * @brief On script enabled fire the HandeLog method every time a log
     * message is received
     * @param none
     * @return void
     */
    void OnEnable()
    {

        // Attach the HandleLog method to every log received
        Application.logMessageReceived += HandleLog;

        // Return 
        return;
    }

    /*
     * @brief On script disabled remove the HandeLog method every time a log 
     * message is received
     * @param none
     * @return void
     */
    void OnDisable()
    {

        // Remove the HandleLog method from every log received
        Application.logMessageReceived -= HandleLog;

        // Return
        return;
    }

    /*
     * @brief Handle the parsing of the debug string
     * @param string logString the debug log message
     * string stackTrace the stack trace of the log messages
     * LogType type the type of log message
     * @return void
     */
    void HandleLog(string logString, string stackTrace, LogType type)
    {

        // Check if the LogType is a standard log
        if (type == LogType.Log)
        {

            // Hold the string split 
            string[] splitString = logString.Split(char.Parse(":"));

            // Hold the dictionary key for the debug log
            string debugKey = splitString[0];

            // Hold the dictionary value for the debug log
            string debugValue = splitString.Length > 1 ? splitString[1] : "";

            // Check if the dictionary contains the key
            if (DebugLogs.ContainsKey(debugKey))
            {

                // Set the new debug value for the key already in use
                DebugLogs[debugKey] = debugValue;
            }

            // Else add the new key and value pair to the dictionary
            else
            {

                // Add the new key and value pair
                DebugLogs.Add(debugKey, debugValue);
            }
        }

        // Hold the display text for the text mesh pro
        string displayText = "";

        // Loop through each key value pair of the debuglogs
        foreach (KeyValuePair<string, string> log in DebugLogs)
        {

            // Check if there is no value in the log
            if (log.Value == "")
            {

                // Add new line to the end of the text
                displayText += log.Key + "\n";
            }

            // Else add the value 
            else
            {

                // Append the log key and log value to the display and add a 
                // new line
                displayText += log.Key + ":" + log.Value + "\n";
            }
        }

        // Set the display text for the text mesh pro
        Display.text = displayText;

        // Return
        return;
    }
}
