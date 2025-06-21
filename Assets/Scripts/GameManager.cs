using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManger : MonoBehaviour
{
    public Button startButton;
    public Image fadePanel; // 검은색 이미지 (전체 화면 덮는)
    public GameObject titleScreen;
    public GameObject inGameUI;
    public float fadeDuration = 1f;

    private Color originalColor;

    void Start()
    {
        originalColor = startButton.image.color;
        startButton.onClick.AddListener(OnStartButtonClicked);
        fadePanel.color = new Color(0, 0, 0, 0); // 처음에는 투명
        fadePanel.raycastTarget = false; // 버튼 막지 않게
    }

    public void OnStartButtonClicked()
    {
        Debug.Log("Start button clicked!");
        // 버튼 시각 효과 (살짝 어두워짐)
        startButton.image.DOColor(originalColor * 0.8f, 0.1f)
            .OnComplete(() =>
            {
                // 페이드 아웃 (검정 이미지 알파 0 → 1)
                fadePanel.DOFade(1f, fadeDuration).OnComplete(() =>
                {
                    // ✅ 타이틀 화면 숨김
                    titleScreen.SetActive(false);

                    // ✅ 인게임 UI 표시
                    inGameUI.SetActive(true);

                    // 페이드 인 (알파 1 → 0)
                    fadePanel.DOFade(0f, fadeDuration);
                });
            });
    }
}
