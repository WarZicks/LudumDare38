using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    [SerializeField] private EndWayCollision _linkedEndWay;
    private ParticleSystem _particles;
    private Light _light;

    private void Awake()
    {
        _particles = GetComponentInChildren<ParticleSystem>();
        _light = GetComponentInChildren<Light>();
    }

    private void Start()
    {
        _linkedEndWay.onTriggerEndWay += () => CheckMyEndWay();

        _particles.playOnAwake = false;
        _particles.Stop();

        _light.gameObject.SetActive(false);
    }

    private void CheckMyEndWay()
    {
        if (_linkedEndWay.activated)
            LightOn();  
        else
            LightOff();
    }

    private void LightOn()
    {
        _particles.Play();
        _light.gameObject.SetActive(true);
    }

    private void LightOff()
    {
        _particles.Stop();
        _light.gameObject.SetActive(false);
    }
}
