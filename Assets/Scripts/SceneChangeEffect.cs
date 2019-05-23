using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class SceneChangeEffect : MonoBehaviour
{

    Vignette vignetteLayer;

    private bool passedOut; //生死確認
    private bool updateTimer = false;
    [SerializeField] private float effectTimer = 0.0f;
    [SerializeField] float timeSpeed = default; 
    private bool notYet; //passedOutフラグ

    void Start()
    {

        notYet = true;
        //レイヤー取得　忘れがち
        PostProcessVolume activeVolume = gameObject.GetComponent<PostProcessVolume>();
        activeVolume.profile.TryGetSettings(out vignetteLayer);

        updateTimer = true;
        effectTimer = 0.0f;
        vignetteLayer.enabled.value = true;
        //memo
        //vignetteLayer.intensity.value = 10f;
        
    }

    //徐々に変化させる
    void Update()
    {

        if (updateTimer == true)
        {
            effectTimer += Time.deltaTime * timeSpeed; //ここで調整
        }

        if (notYet)
        {

            if (!passedOut) //まだフェードアウト中
            {

                //vignetteLayer.enabled.value = true;

                //カラーチェンジの仕方が謎
                //vignetteLayer.color.value = #841717;

                vignetteLayer.intensity.value = (5f - effectTimer);
                //vignetteLayer.intensity.value -= effectTimer * 0.05f;　これだとStartで指定した値(n)無視して1fの状態へ変化

                if (vignetteLayer.intensity.value <= 0f)
                {
                    passedOut = true;
                }

            }
            if (passedOut) //フェードアウト終わった！処理止めるなら実行
            {

                //止める
                vignetteLayer.enabled.value = false;
                Debug.Log("passedOut loaded");
                notYet = false;
            }

        }       

    }
}