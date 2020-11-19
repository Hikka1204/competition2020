public class UnityChanController : MonoBehaviour
{

    // スプライトレンダラーコンポーネントを入れる
    SpriteRenderer sr;

    void Start()
    {

        // スプライトレンダラーのコンポーネントを取得する
        this.sr = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (sr.flipX == true)
            {
                sr.flipX = false;
            }
            else if (sr.flipX == false)
            {
                sr.flipX = true;
            }

        }
    }
}