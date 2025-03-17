using System.Collections;
using System.Collections.Generic;
using Gilzoide.LottiePlayer;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RuntimeDemo : MonoBehaviour
{
    [Header("Lottie Player")] 
    [SerializeField] List<LottieAnimationAsset> animationAssets;
    [SerializeField] CustomImageLottiePlayer playerPrefab;
    
    [Header("View")]
    [SerializeField] ScrollRect lottieView;
    [SerializeField] TMP_Dropdown jsonDropdown;
    [SerializeField] Button addButton;
    [SerializeField] Button removeButton;
    [SerializeField] TMP_Text countText;

    private List<CustomImageLottiePlayer> _instances = new List<CustomImageLottiePlayer>();
    
    // Start is called before the first frame update
    void Start()
    {
        var options = new List<TMP_Dropdown.OptionData>();
        foreach (var asset in animationAssets)
        {
            options.Add(new TMP_Dropdown.OptionData(asset.name));
        }
        jsonDropdown.options = options;
        
        addButton.onClick.AddListener(Add);
        removeButton.onClick.AddListener(Remove);
    }
    
    private void Add()
    {
        var asset = animationAssets[jsonDropdown.value];

        var instance = Instantiate(playerPrefab, lottieView.content);
        instance.SetAsset(asset);
        instance.Play();
        _instances.Add(instance);
        OnUpdated();
    }

    private void Remove()
    {
        if(_instances.Count <= 0) return;
        var instance = _instances[^1];
        instance.Pause();
        GameObject.Destroy(instance.gameObject);
        _instances.RemoveAt(_instances.Count - 1);
        OnUpdated();
    }

    private void OnUpdated()
    {
        countText.text = _instances.Count.ToString();
    }
}
