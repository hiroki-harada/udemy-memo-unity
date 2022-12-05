# 資料
[Unity ゲーム開発：インディーゲームクリエイターが教える C#の基礎からゲームリリースまで【スタジオしまづ】](https://www.udemy.com/course/studio_shimazu_nfrpg/)


# メモ本文
# ~03. Unity のインストール
学習用にaws workspace 用意しようとアカウントは作成したが、もろもろのツールインストールが面倒だった

prawaki の環境で実施することにした


# 04. Unity の初期設定
Unity のインストールが完了したところから再開

バージョンは、動画では最新を選択といわれたが、動画に合わせて2019.1.0f2 を選択した

使用するエディタの設定などを行う、ただUnity のインストールが完了していない

とりあえず、動画だけ先に進める


# 05. VSCode のインストール
* 12/02 今日のゴール：セクション7開始 ~ 完了

プロジェクトの作成がまだなので、過去動画に戻って作成、この章自体は流し見する

プロジェクトを作成しようとすると、↓が出る
* failed to resolve project template com.unity.template.3d

もしかしたら、最新のLTS Unity を使用した方が良いかもしれないと思いつつ、原因を調べる

unity hub をダウングレードする方法があったが、その方法は取りたくないので、それ以外の解決策を探す

project のパスが長すぎるとエラーになる、とあったが、上記のエラー文と一致しない(decompressと表示されるらしい)

最新のLTS をインストールすることにした(2021.3.15f1)

インストール待ちの間、先の章を倍速で視聴しておく


# 07. Unity でゲームを作るには
このレッスンでは基本的に、スクリプトからオブジェクトを操作する

* GetComponent<T>
  - スクリプトをアタッチしているオブジェクトの T コンポーネントを取得する


# 08. 最新バージョンでの修正
Text オブジェクトが UI>Legacy>Text に配置変更になった


# 09. 表示される文字の変更
UI系のオブジェクトは、キャンバスオブジェクト配下に配置しないといけないみたい

Scene ビューは、developer 向け？

07 に習って、テキストを操作するときは、GetComponent<Text> (Text オブジェクトが返る)

Text コンポーネントの↓プロパティから操作できる
* text：テキストを操作
* new Color(r, b, g, a);


# 10. Image コンポーネントの操作
用語を以下のように統一
* オブジェクト：Unity エディタ上での名称
* コンポーネント：C# におけるクラス(GetComponent<T>など)
Image オブジェクトも、Canvas 配下に設置する

適当な画像を2枚用意することになった、ミミッキュの画像をDLしてきた

今回は、Assetts直下に画像を配置

画像をimageオブジェクトにアタッチするには、画像のTexture Type をsprite にする必要がある

リポジトリを作成していなかった、リポジトリの作成と初期プロジェクトをコミットしておく

初期状態で設定した画像を変更してみる
* Image.sprite にSpriteコンポーネントを突っ込む
* Image.color で画像カラーの変更もできる


# 11. HPバーの操作
09 で作成したスクリプトやオブジェクトは削除するみたい、なのでコミットもしなくていいかな。。

Slider オブジェクトを作成して、適当なスクリプトをアタッチ


# 12. 別オブジェクトの操作方法
他のオブジェクトのコンポーネントを取得する方法
* 操作したいオブジェクトをアタッチ
  * 例えば、Player オブジェクトにPlayerHP オブジェクトをアタッチする、など
* スクリプト側で、そのオブジェクトのプロパティとしてコンポーネントを取得する

```C#
public class Player : MonoBehaviour
{
  public GameObject hpGameObject;
  void Start()
  {
    hpGameObject.GetComponent<Text>().text = "50";
  }
}

// ↓でも同等の操作が可能
// 始めから、対象のオブジェクトを取り扱う型が分かっている場合？
{
  public Text hpText;
  void Start()
  {
    hpText.GetComponent<Text>().text = "50";
    hpText.text = "50";
  }
}
```


# 13. 演習
今までの復習をかねた演習

一旦動画を止めて、動画に出てきた成果物を作ることにした

演習問題は、5:15 辺りから表示
* Playerオブジェクトに付与したスクリプトを操作して、cube/Slider/Text オブジェクトを操作する
* Text を 100 -> 50 に変更する
* Slider. value を100 -> 50 に変更する
* cube を動かす

続きは、演習の答え合わせから(5:30~)


12/05 答え合わせ

別解
```C#
public class Player : MonoBehaviour
{
  // Playerオブジェクトの transform にアクセスする場合、transform から直接操作できる

  // public Transform player; ← 不要
  void Update()
  {
    // transform = GetComponent<Transform>(); ← 不要
    transform.position += new Vector3(0.3f, 0, 0);
  }
}

// ↓でも同等の操作が可能
{
  public GameObject hpGameObject;
  void Start()
  {
    // object 名から名前解決する
    GameObject.Find("HPSlider").GetComponent<Text>().text = "50";
  }
}
```


# 14. セクションのまとめ
次の章から、C#の基礎について学習
* 変数、if文、for文など。。


# 15. ショートカットキーの解説
レビューで、ショートカットキーを紹介して欲しいとあったため、追加したらしい


