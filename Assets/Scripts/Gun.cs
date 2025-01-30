using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private Transform _bulletPivot;
        
    [SerializeField]
    private Animator _weaponAnimator;

    [SerializeField]
    private int _maxBulletsNumber = 50;

    [SerializeField]
    private int _cartridgeBulletsNumber = 10;
    private int _totalBulletsNumber = 0;
    private int _currentBulletsNumber = 0;

    private Text _bulletText;
    public void Shoot()
    {
        GameObject.Instantiate(_bullet, _bulletPivot.position,  _bulletPivot.rotation);
        _weaponAnimator.Play("Shoot", -1, 0f);
        _currentBulletsNumber --;
        UpdateBulletsText();
    }

    public void PickUpWeapon()
    {
        _totalBulletsNumber = _maxBulletsNumber;
        _currentBulletsNumber = _cartridgeBulletsNumber;
        _weaponAnimator.Play("GetWeapon");
    }

    public void Reload()
    {
        if (_totalBulletsNumber >= _cartridgeBulletsNumber)
        {
            _currentBulletsNumber = _cartridgeBulletsNumber;
        }

        else if (_totalBulletsNumber > 0)
        {
            _currentBulletsNumber = _totalBulletsNumber;
        }

        _totalBulletsNumber -= _currentBulletsNumber;
        UpdateBulletsText();

    }

    public void UpdateBulletsText()
    {
        if (_bulletText == null)
        {
            _bulletText = GameObject.Find("BulletText").GetComponent<Text>();
        }

        _bulletText.text = _currentBulletsNumber + "/" + _totalBulletsNumber;

    }
}
