using UnityEngine;

public class CaseData : MonoBehaviour
{
    [SerializeField]
    private ItemData[] _commonItems;
    [SerializeField]
    private ItemData[] _rareItems;
    [SerializeField]
    private ItemData[] _uniqueItems;
    [SerializeField]
    private ItemData[] _mythicItems;
    [SerializeField]
    private ItemData[] _legendaryItems;

    private ItemData[][] _allRarityItems = new ItemData[5][];

    public ItemData[][] allRarityItems => _allRarityItems;
    public float _allItemsWeight { get; private set; }
    
    private void Awake()
    {
        _allRarityItems[0] = _commonItems;
        _allRarityItems[1] = _rareItems;
        _allRarityItems[2] = _uniqueItems;
        _allRarityItems[3] = _mythicItems;
        _allRarityItems[4] = _legendaryItems;

        for (int i = 0; i < _allRarityItems.GetLength(0); i++)
        {
            _allItemsWeight += allRarityItems[i][0].dropWeight;
        }
    }
}
