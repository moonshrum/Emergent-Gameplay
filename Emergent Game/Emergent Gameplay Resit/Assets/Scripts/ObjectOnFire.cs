using UnityEngine;

public class ObjectOnFire : MonoBehaviour
{
    public bool IsOnFire = false;
    private float _timeOnFire;
    private float _maximumTimeOnFire = 5f;
    private void Update()
    {
        _timeOnFire += Time.deltaTime;
        if (_timeOnFire >= _maximumTimeOnFire)
        {
            GameObject firePrefab = transform.Find("Fire Prefab").gameObject;
            firePrefab.SetActive(false);
            GameObject burntSprite = firePrefab.transform.Find("Burnt Sprite").gameObject;
            if (GetComponent<Campfire>() != null)
            {
                burntSprite.SetActive(true);
            }
            Destroy(this);
        }
    }
}
