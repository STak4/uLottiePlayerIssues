using System.Collections;
using System.Collections.Generic;
using Gilzoide.LottiePlayer;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CrashDemo : MonoBehaviour
{
    [Header("Lottie Player")]
    //[SerializeField] List<LottieAnimationAsset> animationAssets;
    [SerializeField] List<ImageLottiePlayer> lottiePlayerPrefabs;
    
    [Header("View")]
    [SerializeField] ScrollRect lottieView;
    [SerializeField] TMP_Dropdown jsonDropdown;
    [SerializeField] Button addButton;
    [SerializeField] Button removeButton;
    [SerializeField] TMP_Text countText;

    private List<ImageLottiePlayer> _instances = new List<ImageLottiePlayer>();
    
    // Start is called before the first frame update
    void Start()
    {
        var options = new List<TMP_Dropdown.OptionData>();
        foreach (var asset in lottiePlayerPrefabs)
        {
            options.Add(new TMP_Dropdown.OptionData(asset.name));
        }
        jsonDropdown.options = options;
        
        addButton.onClick.AddListener(Add);
        removeButton.onClick.AddListener(Remove);
    }
    
    private void Add()
    {
        // var json = jsonDropdown.options[jsonDropdown.value].text;
        // var asset = Resources.Load(json, typeof(LottieAnimationAsset));
        var prefab = lottiePlayerPrefabs[jsonDropdown.value];
        
        var instance = Instantiate(prefab, lottieView.content) as ImageLottiePlayer;
        _instances.Add(instance);
        OnUpdated();
    }

    private void Remove()
    {
        if(_instances.Count <= 0) return;
        var instance = _instances[^1];
        GameObject.Destroy(instance.gameObject);
        _instances.RemoveAt(_instances.Count - 1);
        OnUpdated();
    }

    private void OnUpdated()
    {
        countText.text = _instances.Count.ToString();
    }
}
