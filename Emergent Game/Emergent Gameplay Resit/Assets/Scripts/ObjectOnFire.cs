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
            GameObject burntSprite = transform.Find("Burnt Sprite").gameObject;
            if (GetComponent<Campfire>() == null)
            {
                if (GetComponent<ResourceMine>() != null)
                {
                    Destroy(GetComponent<ResourceMine>());
                }
                else if (GetComponent<ResourceDrop>() != null)
                {
                    Destroy(GetComponent<ResourceDrop>());
                }
                GetComponent<SpriteRenderer>().enabled = false;
                burntSprite.SetActive(true);
                GetComponent<BoxCollider2D>().enabled = false;
            }
            Invoke("RemoveAsh", 5f);
        }
    }
    private void RemoveAsh()
    {
        Destroy(this.gameObject);
    }
}
