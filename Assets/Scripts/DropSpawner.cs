using UnityEngine;
using UnityEngine.UI;

public class DropSpawner : MonoBehaviour
{
    [SerializeField]
    private CaseData _currentCaseData;
    [SerializeField]
    private DropReceiver _dropReceiver;
    [SerializeField]
    private GameObject _dropScroller;

    private Image[] _dropImage;
    private float _currentItemDropChance;
    private Vector3 _startScrollPosition;

    private void OnEnable()
    {
        _dropReceiver.OnDropReceiveEvent.AddListener(DropImageCreator);
        DropImageCreator();
    }

    private void Awake()
    {
        _startScrollPosition = transform.position;

        _dropImage = new Image[_dropScroller.transform.childCount];

        for (int i = 0; i < _dropScroller.transform.childCount; i++)
        {
            _dropImage[i] = _dropScroller.transform.GetChild(i).GetComponent<Image>();
        }
    }
    public void DropImageCreator()
    {
        transform.position = _startScrollPosition;

        for (int i = 0; i < _dropImage.Length; i++)
        {
            SetDropImage(_dropImage[i]);
        }
    }

    public void SetDropImage(Image currentImageSlot)
    {
        _currentItemDropChance = Random.Range(0f, _currentCaseData._allItemsWeight);

        for (int i = 0; i < _currentCaseData.allRarityItems.GetLength(0); i++)
        {
            _currentItemDropChance -= _currentCaseData.allRarityItems[i][0].dropWeight;

            if (_currentItemDropChance <= 0)
            {
                int _randomImageNumber = Random.Range(0, _currentCaseData.allRarityItems[i].Length);
                currentImageSlot.sprite = _currentCaseData.allRarityItems[i][_randomImageNumber].dropSprite;
                break;
            }
        }
    }

    private void OnDisable()
    {
        _dropReceiver.OnDropReceiveEvent.RemoveListener(DropImageCreator);
    }
}
