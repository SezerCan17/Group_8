using UnityEngine;

public class NavigationSystem : MonoBehaviour
{
    public Transform arrow;
    public GameObject player;
    public LocationSO locationSO;
    private Vector3 targetPosition;

    public Camera mainCamera;

    private float initialArrowAngle; // Başlangıçtaki ok açısını tutacak değişken

    void Start()
    {
        // Başlangıçta arrow'un sol üste baktığını varsayalım
        initialArrowAngle = arrow.rotation.eulerAngles.z;
    }

    void Update()
{
    if (arrow != null && player != null && mainCamera != null)
    {
        // Oyuncu ve hedef pozisyonlarının ekran koordinatlarını alıyoruz
        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(player.transform.position);
        Vector3 targetScreenPos = mainCamera.WorldToScreenPoint(targetPosition);

        // Yönü hesaplıyoruz
        Vector3 direction = (targetScreenPos - playerScreenPos).normalized;

        // Yön açısını hesaplıyoruz
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Arrow'un rotasını ayarlarken, başlangıçtaki açıyı ekliyoruz
        float finalAngle = angle + initialArrowAngle;

        // Okun doğru rotada dönmesini sağlıyoruz
        arrow.rotation = Quaternion.Euler(0, 0, finalAngle-125);
    }
}

    // Hedef belirleme fonksiyonu
    public void SetTarget(Package cargo)
    {
        if (cargo == null) return;

        Package cargoPackage = cargo.gameObject.GetComponent<Package>();
        if (cargoPackage == null) return;

        // Hedef pozisyonu, Scriptable Object'ten al
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

    // Dinamik hedef belirleme fonksiyonu
    public void SetDynamicTarget(Vector3 newTargetPosition)
    {
        targetPosition = newTargetPosition;
        Debug.Log("Dynamic Target Position Updated: " + targetPosition);
    }
}
