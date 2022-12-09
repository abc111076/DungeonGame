using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LogColor
{
    aqua = 0,
    fuchsia,
    lime,
    olive,
    orignge,
    teal
}

public class DebugUtility
{
    public static void DebugLogWithTag(string tag, string log, LogColor color = LogColor.aqua)
    {
        string s_color = color.ToString();
        Debug.Log("<color=orange>" + tag + "</color>" + " === " + "<color=" + s_color + ">" + log + "</color>");
        //Debug.Log("This is " + "<color=aqua>" + "Sample Message 1" + "</color>" + ".\n" +
        //          "This is " + "<color=black>" + "Sample Message 2" + "</color>" + ".\n" +
        //          "This is " + "<color=blue>" + "Sample Message 3" + "</color>" + ".\n" +
        //          "This is " + "<color=brown>" + "Sample Message 4" + "</color>" + ".\n" +
        //          "This is " + "<color=darkblue>" + "Sample Message 5" + "</color>" + ".\n" +
        //          "This is " + "<color=fuchsia>" + "Sample Message 6" + "</color>" + ".\n" +
        //          "This is " + "<color=green>" + "Sample Message 7" + "</color>" + ".\n" +
        //          "This is " + "<color=lightblue>" + "Sample Message 8" + "</color>" + ".\n" +
        //          "This is " + "<color=lime>" + "Sample Message 9" + "</color>" + ".\n" +
        //          "This is " + "<color=magenta>" + "Sample Message 10" + "</color>" + ".\n" +
        //          "This is " + "<color=maroon>" + "Sample Message 11" + "</color>" + ".\n" +
        //          "This is " + "<color=navy>" + "Sample Message 12" + "</color>" + ".\n" +
        //          "This is " + "<color=olive>" + "Sample Message 13" + "</color>" + ".\n" +
        //          "This is " + "<color=orange>" + "Sample Message 14" + "</color>" + ".\n" +
        //          "This is " + "<color=purple>" + "Sample Message 15" + "</color>" + ".\n" +
        //          "This is " + "<color=red>" + "Sample Message 16" + "</color>" + ".\n" +
        //          "This is " + "<color=silver>" + "Sample Message 17" + "</color>" + ".\n" +
        //          "This is " + "<color=teal>" + "Sample Message 18" + "</color>" + ".\n" +
        //          "This is " + "<color=white>" + "Sample Message 19" + "</color>" + ".\n" +
        //          "This is " + "<color=yellow>" + "Sample Message 20" + "</color>" + ".\n");
    }
}
