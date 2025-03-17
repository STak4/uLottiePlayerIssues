using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gilzoide.LottiePlayer
{
    [AddComponentMenu("UI/Custom Image Lottie Player")]
    public class CustomImageLottiePlayer : ImageLottiePlayer
    {
        public void SetAsset(LottieAnimationAsset asset)
        {
            _animationAsset = asset;
            RecreateAnimationIfNeeded();
        }
    }
}
