using System;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class CharacterAvatarMV : CanvasMV
{
    private int _id;
    private Sprite _avatar;
    private bool _isChosen;
    public event Action<CharacterAvatarMV> CharacterPicked;

    public int Id
    {
        get => _id;

        private set
        {
            _id = value;
        }
    }

    [Binding]
    public Sprite Avatar
    {
        get => _avatar;

        set
        {
            if (_avatar == value)
                return;

            _avatar = value;

            OnPropertyChanged();
        }
    }

    [Binding]
    public bool IsChosen
    {
        get => _isChosen;
        set
        {
            if (_isChosen == value)
                return;
            _isChosen = value;
            OnPropertyChanged();
        }
    }

    [Binding]
    public void OnCharacterPressed()
    {
        CharacterPicked?.Invoke(this);    
    }

    public void Initialize(int id)
    {
        Id = id;
    }
}
