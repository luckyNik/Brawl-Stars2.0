using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class HeroMV : CanvasMV
{
    private UnitModel _model;

    private string _playerLogin = "Player";

    [Binding]
    public string PlayerLogin
    {
        get => _playerLogin;
        set
        {
            _playerLogin = value;
            OnPropertyChanged();
        }
    }

    public void Initialize(UnitModel model)
    {
        _model = model;
    }

    private void Update()
    {
        transform.position = _model.CurrentPosition;
    }
}