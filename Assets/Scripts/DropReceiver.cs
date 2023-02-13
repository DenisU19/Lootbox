using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DropReceiver : MonoBehaviour
{
    [SerializeField]
    private DropMovement _dropMovement;
    [SerializeField]
    private CaseData _currentCaseData;
    [SerializeField]
    private GameObject _rewardPanel;
    [SerializeField]
    private GameObject _backgroundPanel;

    private Image _rewardIcon;
    private Text _rewardName;
    private Text _rewardDescription;
    private RaycastHit2D _raycastHit;

    public UnityEvent OnDropReceiveEvent;

    private void Awake()
    {
        _rewardIcon = _rewardPanel.transform.GetChild(0).GetComponent<Image>();
        _rewardName = _rewardPanel.transform.GetChild(1).GetComponent<Text>();
        _rewardDescription = _rewardPanel.transform.GetChild(2).GetComponent<Text>();
    }

    private void OnEnable()
    {
        _dropMovement.OnMovementStopedEvent.AddListener(AcceptReward);
    }

    private void AcceptReward()
    {
        if(_raycastHit = Physics2D.Raycast(transform.position, Vector2.down))
        {
            Image _currentDropImage = _raycastHit.collider.transform.GetComponent<Image>();

            for (int i = 0; i < _currentCaseData.allRarityItems.GetLength(0); i++)
            {
                for (int j = 0; j < _currentCaseData.allRarityItems[i].Length; j++)
                {
                    if(_currentDropImage.sprite == _currentCaseData.allRarityItems[i][j].dropSprite)
                    {
                        _rewardIcon.sprite = _currentCaseData.allRarityItems[i][j].dropSprite;
                        _rewardName.text = _currentCaseData.allRarityItems[i][j].dropName;
                        _rewardDescription.text = _currentCaseData.allRarityItems[i][j].dropDescription;
                        _backgroundPanel.SetActive(true);
                        _rewardPanel.SetActive(true);
                        OnDropReceiveEvent?.Invoke();
                        return;
                    } 
                }
            }
        }
        else
        {
            _dropMovement.GetSomeSpeed();
        }
    }

    private void OnDisable()
    {
        _dropMovement.OnMovementStopedEvent.RemoveListener(AcceptReward);
    }
}
