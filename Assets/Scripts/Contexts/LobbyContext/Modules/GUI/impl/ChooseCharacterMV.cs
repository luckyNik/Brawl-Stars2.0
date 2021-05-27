using UnityWeld.Binding;
using System.Collections.Generic;
using UnityEngine;

[Binding]
public class ChooseCharacterMV : CanvasMV
{
    private const string AvatarPrefabPath = "CharacterAvatarMV";

    private GameObject _avatarPrefab;
    private List<CharacterAvatarMV> _avatars = new List<CharacterAvatarMV>(5);
    private CharacterAvatarMV _chosenAvatar;

    [SerializeField] private Transform _content;

    [Inject] public IUnitDatabase UnitDatabase { get; set; }
    [Inject] public CharacterChoosenSignal CharacterChoosenSignal { get; set; }

    private GameObject AvatarPrefab
    {
        get
        {
            if (_avatarPrefab == null)
            {
                _avatarPrefab = Resources.Load<GameObject>(AvatarPrefabPath);

                if (_avatarPrefab == null)
                {
                    Debug.LogError($"Not found at {AvatarPrefabPath}");
                }
            }
            return _avatarPrefab;
        }
    }


    [PostConstruct]
    private void Initialize()
    {
        foreach (var config in UnitDatabase.UnitConfigurations)
        {
            var newAvatar = Instantiate(AvatarPrefab, _content);

            if(newAvatar.TryGetComponent(out CharacterAvatarMV avatarMV))
            {
                avatarMV.Initialize(config.Id);
                avatarMV.CharacterPicked += OnCharacterPicked;
                _avatars.Add(avatarMV);
            }
        }
    }

    [Binding]
    public void OnConfirmPressed()
    {
        CharacterChoosenSignal.Dispatch(_chosenAvatar.Id);
    }

    private void OnCharacterPicked(CharacterAvatarMV chosenAvatar)
    {
        if (_chosenAvatar)
        {
            _chosenAvatar.IsChosen = false;
        }
        _chosenAvatar = chosenAvatar;
        _chosenAvatar.IsChosen = true;
    }
}
