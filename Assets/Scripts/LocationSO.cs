using UnityEngine;

[CreateAssetMenu(fileName = "NewLocation", menuName = "Location")]
public class LocationSO : ScriptableObject
{
    public string locationName;  
    public Vector3 coordinates; 
}
