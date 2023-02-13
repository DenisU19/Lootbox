using UnityEngine;

[System.Serializable]
public class ItemData 
{
    [SerializeField]
    private string _dropName;

    [SerializeField] 
    private string _dropDescription;

    [SerializeField]
    private float _dropWeight;

    [SerializeField]
    private Sprite _dropSprite;

    public string dropName => _dropName;

    public string dropDescription => _dropDescription;

    public float dropWeight => _dropWeight;

    public Sprite dropSprite => _dropSprite;

}
