# 000. 資料
[Unityゲーム開発入門：Unityインストラクターが教えるマリオ風2Dアクションゲームを作成する方法【スタジオしまづ】](https://www.udemy.com/course/studio_shimazu_sideview_action/)


# 001. はじめに
* なるべく最初から進めるのがオススメ
* セクション4 からなど、一部スキップして進めても可


# 042. Sec8 ゲームの作り方（マリオメーカーのようなステージ開発とプログラムの実装）: はじめに
* 疑問点や不明点は、Q&Aをチェック！


# 043. 追加動画(Unity2019.2以上) Tile Paletteの追加
* tile pallete が、package manager からのimport対象になっているらしい


# 044. 素材のインポートとマリオメーカーのようなステージ作成
* 初期設定
  * 2D
* 他設定
  * Asset store: Sunny Land
  * Hierarchy
    * 2D Object > Tilemap オブジェクトを追加
  * Window > 2D > Tile pallete
    * Asset/Tiles/ を切って tile を追加する

* ステージ作成
  * tile map ビューから、タイルを Tilemap に塗ることができる
  * tile が小さい場合は、tile > pixel per unit をtile Asset のサイズと一致させる

* ＞ VSCode で入力補完が聞かなかったため、下記設定を実施
* ＞ https://www.exceedsystem.net/2020/08/25/how-to-enable-intellisense-in-vscode-for-unity/


# 045. Playerの作成
* Assets/Animation を切って、animation を保存
  * Sunnyland/.../player/idle の idle を全てhierarchy に配置
    * ＞ぬるぬる動かすために、パラパラ漫画のコマが用意されてるみたい
* animation に下記追加
  * rigidbody：物理演算
    * gravity scale: 2
    * constrains
      * freeze rotation: z; z方向の回転を固定する
  * box collider：衝突判定


# 046. ステージに当たり判定を実装
* tile map　に下記追加
  * rigidbody
    * body type: static
  * collider
    * used by composite
      * チェックすると、連続するtile を1つのオブジェクトとしてcollider を付与する
  * composite collider 2D


# 047. Playerの移動
* Input.Getxxx による player 制御
```C#
// 方向キー押下の取得
// x > 0 : 十字キー右が押されている
float x = Input.GetAxis("Horizontal");
// 速度変更
rigidbody2D.velocity = new Vector2(Vx, Vy);

// 1 回/フレーム 呼ばれる
void Update() {}

// フレームレートに応じて呼ばれる、滑らかな処理をしたい場合に使う？
// デフォルトだと、50 calls per second
// https://docs.unity3d.com/ja/2021.2/ScriptReference/MonoBehaviour.FixedUpdate.html
void FixedUpdate() {}
```


# 048. ジャンプの実装
```C#
// ボタン押下時間だけ呼ばれる
input.Getkey();
// ボタンを押し込んだ回数だけ呼ばれる
input.GetkeyDown();

// 上方向に力を加えてジャンプさせる
rigidbody2D.AddForce(Vector2);
rigidbody2D.AddForce(Vector2.up * const);
```


# 049. 地面との当たり判定実装
* 衝突判定のため、tilemap にレイヤー追加
  * user layer の一番上に、Block を追加

```C#
// Vector 2つをplayer 下から下す
// それが地面と設置しているかで判定する
//
// not touched   touched
//   |___|
//    ↘ ↙         |___|
// ________________↘_↙______ ground

Vector3 leftStartPoint = transform.position - Vector3.right * 0.2f;
Vector3 rightStartPoint = transform.position + Vector3.right * 0.2f;
Vector3 endPoint = transform.position - Vector3.up * 0.1f;

// vector の描画
Debug.DrawLine(leftStartPoint, endPoint);
Debug.DrawLine(rightStartPoint, endPoint);

// 始点と終点を設定してそこに線を張り、コライダーがヒットした場合 true を返します
// https://docs.unity3d.com/ja/2018.4/ScriptReference/Physics.Linecast.html
return Physics2D.Linecast(leftStartPoint, endPoint, blockLayer)
    || Physics2D.Linecast(rightStartPoint, endPoint, blockLayer);
```

# 050. ゲームオーバーとゲームクリアの実装（当たり判定の検出）
* 適当なtag を付与した gameObject を作成
  * ゲームオーバーとゲームクリアのオブジェクト
  * is trigger を付与：接触/透過判定がしたいため
    * ＞ 衝突するオブジェクトのどちらか1方に is trigger が付いていると、すり抜けるみたい

```C#
OnCollisionEnter2D(Collision collision)
{
  if (collision.gameObject.tag == "tag") {}
}
```


# 051. ゲームオーバー時にテキストを表示する実装
* UI>Text を表示するようにする、設定の詳細は割愛

* game scene で文字が表示されなかったため、以下修正
  * Canvas
    * Render Mode: Screen Space – Camera or Overlay
    * Render Camera: Main Camera


# 052. リスタートの実装



# 053. トラップの実装



# 054. アイテムの実装



# 055. アイテム取得の実装



# 056. アイテム取得時のスコア更新の実装



# 057. 敵キャラクターの実装



# 058. 敵キャラクターの移動



# 059. 敵キャラクターの落下対策



# 060. 敵キャラクターへの攻撃実装



# 061. カメラの追従



# 062. カメラの境界設定



# 063. Playerが壁に引っかかるバグを修正



# 064. Runアニメーションの実装



# 065. Jumpアニメーションの実装



# 066. 敵撃破エッフェクトの実装



# 067. アニメーションの終了取得



# 068. 死亡アニメーションの実装



# 069. BGMとSEの実装



# 070.  ボーナスレクチャー
