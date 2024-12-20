using UnityEngine;

public class NavigationSystem : MonoBehaviour
{
    
    public Transform arrow;
    public GameObject player;
    public LocationSO locationSO;
    private Vector3 targetPosition;


    public Camera mainCamera;

    public GameObject cargoOffice;

    private float initialArrowAngle; 

    void Start()
    {
        
        initialArrowAngle = arrow.rotation.eulerAngles.z;
    }

    void Update()
{
    if (arrow != null && player != null && mainCamera != null)
    {
        
        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(player.transform.position);
        Vector3 targetScreenPos = mainCamera.WorldToScreenPoint(targetPosition);

        
        Vector3 direction = (targetScreenPos - playerScreenPos).normalized;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        float finalAngle = angle + initialArrowAngle;

        
        arrow.rotation = Quaternion.Euler(0, 0, finalAngle-125);
    }
    

   
}

   
    public void SetTarget(Package cargo)
    {
        if (cargo == null) return;

        Package cargoPackage = cargo.gameObject.GetComponent<Package>();
        if (cargoPackage == null) return;

        
        LocationType locationType = cargoPackage.cargoSO.locationType;
        if (locationSO.predefinedCoordinates.TryGetValue(locationType, out Vector3 predefinedPosition))
        {
            targetPosition = predefinedPosition;
            Debug.Log("Target Position Updated: " + targetPosition);
        }
        else
        {
            Debug.LogWarning("Target position not found for location type: " + locationType);
        }
    }

   
    public void SetDynamicTarget(Vector3 newTargetPosition)
    {
        targetPosition = newTargetPosition;
        Debug.Log("Dynamic Target Position Updated: " + targetPosition);
    }
}
