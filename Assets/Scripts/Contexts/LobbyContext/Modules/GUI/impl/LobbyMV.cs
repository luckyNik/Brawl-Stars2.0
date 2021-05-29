using UnityEngine;
using UnityWeld.Binding;
using strange.extensions.context.api;
using Photon.Pun;
using System;
using UnityEngine.SceneManagement;

[Binding]
public class LobbyMV : CanvasMV
{
    public static event Action PlayClicked;

    private const string playerPrefKeyName = "PlayerName";

    private string _playerName;

    private bool _isChoosePanelActive;

    private GameObject _currentHeroModel;
    private UnitsAnimationReferences _animationReferences;
    
    [Inject] public ILobbyStateProvider StateProvider { get; set; }
    [Inject] public IUnitDatabase UnitDatabase { get; set; }
    [Inject] public CharacterChoosenSignal CharacterChoosenSignal { get; set; }
    [Inject] public BattleSceneLoadedSignal BattleSceneLoadedSignal { get; set; }
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject Root { get; set; }

    [Binding]
    public string PlayerName
    {
        get => _playerName;

        set
        {
            if(_playerName == value)
            {
                return;
            }

            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Null or empty");
                return;
            }


            PhotonNetwork.NickName = _playerName;
            PlayerPrefs.SetString(playerPrefKeyName, _playerName);

            _playerName = value;

            Debug.Log("Player Name Changed to: " + _playerName);
            OnPropertyChanged();
        }
    }

    [Binding]
    public bool IsChoosePanelActive
    {
        get => _isChoosePanelActive;

        set
        {
            _isChoosePanelActive = value;

            OnPropertyChanged();
        }
    }

    [Binding]
    public void OnPlayClicked()
    {
        PlayClicked?.Invoke();
    }

    [Binding]
    public void ChangeHeroClicked() 
    {
        IsChoosePanelActive = !IsChoosePanelActive;
    }

    [PostConstruct]
    private void Initialize()
    {
        CharacterChoosenSignal.AddListener(OnNewCharacterChosen);

        _animationReferences = Resources.Load<UnitsAnimationReferences>("UnitsAnimationReferences");

        SpawnHero(0);

        SceneManager.sceneLoaded += (scene, loadingMode) =>
        {
            BattleSceneLoadedSignal.Dispatch(scene);
            SceneManager.SetActiveScene(scene);
        };
    }

    private void SpawnHero(int id)
    {
        GameObject characterPrefab = null;

        int skinId = UnitDatabase.Get(id).SkinId;

        foreach (var animationReference in _animationReferences.animationReferences)
        {
            if (animationReference.AnimID == skinId)
            {
                characterPrefab = animationReference.Model;
                break;
            }
        }

        if (characterPrefab)
        {
            Destroy(_currentHeroModel);

            _currentHeroModel = GameObject.Instantiate(characterPrefab, Root.transform);
            _currentHeroModel.transform.localScale = new Vector3(3, 3, 3);
            _currentHeroModel.transform.position = new Vector3(0, -2, 0);
        }
    }

    private void Start()
    {
        base.Start();
        IsChoosePanelActive = false;        
        PlayerName = StateProvider.Model.PlayerLogin;
    }

    private void OnNewCharacterChosen(int id)
    {
        IsChoosePanelActive = false;

        SpawnHero(id);
    }
}
