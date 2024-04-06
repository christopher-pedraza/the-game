using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContext : MonoBehaviour
{
    // Dictionary to store the words and their translations
    public static Dictionary<string, string> words = new Dictionary<string, string>();
    // Dictionary of undiscovered words and their current translations
    public static Dictionary<string, string> undiscoveredWords = new Dictionary<string, string>();
}
