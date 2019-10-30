using UnityEngine;

public class ObjectOnFire : MonoBehaviour
{
    private float _timeOnFire;
    private float _maximumTimeOnFire = 5f;
    private void Update()
    {
        _timeOnFire += Time.deltaTime;
        Debug.Log(_timeOnFire);
        if (_timeOnFire >= _maximumTimeOnFire)
        {
            transform.Find("Fire Prefab").gameObject.SetActive(false);
            GameObject burntSprite = transform.Find("Burnt Sprite").gameObject;
            burntSprite.SetActive(true);
            Debug.Log(GetComponent<ResourceDrop>());
            if (GetComponent<ResourceDrop>() != null)
            {
                burntSprite.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
            }
            //enabled = false;
        }
    }
}
