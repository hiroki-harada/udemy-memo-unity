# 000. 資料
[Unity ゲーム開発：インディーゲームクリエイターが教える C#の基礎からゲームリリースまで【スタジオしまづ】](https://www.udemy.com/course/studio_shimazu_nfrpg/)


# ~003. Unity のインストール
学習用にaws workspace 用意しようとアカウントは作成したが、もろもろのツールインストールが面倒だった

prawaki の環境で実施することにした


# 004. Unity の初期設定
Unity のインストールが完了したところから再開

バージョンは、動画では最新を選択といわれたが、動画に合わせて2019.1.0f2 を選択した

使用するエディタの設定などを行う、ただUnity のインストールが完了していない

とりあえず、動画だけ先に進める


# 005. VSCode のインストール
* 12/02 今日のゴール：セクション7開始 ~ 完了

プロジェクトの作成がまだなので、過去動画に戻って作成、この章自体は流し見する

プロジェクトを作成しようとすると、↓が出る
* failed to resolve project template com.unity.template.3d

もしかしたら、最新のLTS Unity を使用した方が良いかもしれないと思いつつ、原因を調べる

unity hub をダウングレードする方法があったが、その方法は取りたくないので、それ以外の解決策を探す

project のパスが長すぎるとエラーになる、とあったが、上記のエラー文と一致しない(decompressと表示されるらしい)

最新のLTS をインストールすることにした(2021.3.15f1)

インストール待ちの間、先の章を倍速で視聴しておく


# 007. Unity でゲームを作るには
このレッスンでは基本的に、スクリプトからオブジェクトを操作する

* GetComponent<T>
  - スクリプトをアタッチしているオブジェクトの T コンポーネントを取得する


# 008. 最新バージョンでの修正
Text オブジェクトが UI>Legacy>Text に配置変更になった


# 009. 表示される文字の変更
UI系のオブジェクトは、キャンバスオブジェクト配下に配置しないといけないみたい

Scene ビューは、developer 向け？

07 に習って、テキストを操作するときは、GetComponent<Text> (Text オブジェクトが返る)

Text コンポーネントの↓プロパティから操作できる
* text：テキストを操作
* new Color(r, b, g, a);


# 010. Image コンポーネントの操作
用語を以下のように統一
* オブジェクト：Unity エディタ上での名称
* コンポーネント：C# 0におけるクラス(GetComponent<T>など)
Image オブジェクトも、Canvas 配下に設置する

適当な画像を2枚用意することになった、ミミッキュの画像をDLしてきた

今回は、Assetts直下に画像を配置

画像をimageオブジェクトにアタッチするには、画像のTexture Type をsprite にする必要がある

リポジトリを作成していなかった、リポジトリの作成と初期プロジェクトをコミットしておく

初期状態で設定した画像を変更してみる
* Image.sprite にSpriteコンポーネントを突っ込む
* Image.color で画像カラーの変更もできる


# 011. HPバーの操作
09 で作成したスクリプトやオブジェクトは削除するみたい、なのでコミットもしなくていいかな。。

Slider オブジェクトを作成して、適当なスクリプトをアタッチ


# 012. 別オブジェクトの操作方法
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


# 013. 演習
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


# 014. セクションのまとめ
次の章から、C#の基礎について学習
* 変数、if文、for文など。。


# 015. ショートカットキーの解説
レビューで、ショートカットキーを紹介して欲しいとあったため、追加したらしい


# 016. C# 0の基礎：始めに
演習課題が解けるなら、ここはスキップしてもOK


# 017. コンソールとコメントアウト
```C#
// コメント
Debug.Log("ログ出力、コンソールをクリックすると、該当のログ出力処理へコードジャンプできる");
```

# 018. 変数の宣言
特筆事項なし

# 019. 変数の型
C# 0におけるstring も参照型だが、`string.Equals()`が`==`をオーバーライドしている

そのため`==`でも比較が可能
```C#
string message = "Hello, World!";
Console.WriteLine(message.Equals("Hello, World!")); // True
Console.WriteLine(message == "Hello, World!"); // True
```
https://learn.microsoft.com/ja-jp/dotnet/csharp/language-reference/builtin-types/built-in-types

また、gitpod におけるC#プロジェクトの実行方法は、
```bash
dotnet biuld path/to/projectFolder # 0コンパイル
dotnet path/to/projectFolder/bin/Debug/net7.0/projectFolder.dll # 0実行
```
https://www.gitpod.io/docs/introduction/languages/dotnet

# 020. 数値の演算と演算子
特筆事項なし

# 021. 文字列の連結とフォーマット
```C#
// 以下はすべて同等
Debug.Log("Hello " + firstName + " " + familyName);
Debug.Log(string.Format("Hello {0} {1}", firstName, familyName));
// C# 06 以降
Debug.Log($"Hello {firstName} {familyName}");
```


# 022. if文
特筆事項なし

# 023. switch文と演習
特筆事項なし

# 024. 繰り返し処理 whileとfor
特筆事項なし

# 025. 配列の基礎と応用
java と殆ど変わらない
* 宣言方法もほぼ同じ
* インデックスは 0-origin


# 026. Listとforeach
```C#
// プリミティブを型に指定できる
List<int> numberList = new List<int>();
int n = 3;
while (n-- > 0) numberList.Add(n);
// foreach はpython に似ている
foreach (int number in numberList) {
  Console.WriteLine(number);
}
```


# 027. 関数（メソッド）の作成と応用
通例、メソッド名は大文字始まり(Pascal 形式)
microsoft も[推奨している](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/coding-style/coding-conventions)


# 028. 【演習】nからmまでの偶数の和を求める関数を作成せよ
.NET プロジェクト`ExerciseProject/`を作成して、そこに解答


# 029. 【演習】3のつく数字と3の倍数でアホになる演習問題
.NET プロジェクト`ExerciseProject/`に解答

12/06 答え合わせ


# 030. classの作成と利用方法
特筆事項なし

# 031. Propertyの作成と利用方法
C# 0におけるアクセス修飾子の仕様は下記の通り

|呼び出し元の場所 | public | protected internal | protected | internal | private protected | private / 修飾子なし |
|--|--|--|--|--|--|--|
|クラス内 | ✔️️ | ✔️ | ✔️ | ✔️ | ✔️ | ✔️|
|派生クラス (同じアセンブリ) | ✔️ | ✔️ | ✔️ | ✔️ | ✔️ | ❌|
|非派生クラス (同じアセンブリ) | ✔️ | ✔️ | ❌ | ✔️ | ❌ | ❌|
|派生クラス (異なるアセンブリ) | ✔️ | ✔️ | ✔️ | ❌ | ❌ | ❌|
|非派生クラス (異なるアセンブリ) | ✔️ | ❌ | ❌ | ❌ | ❌ | ❌|

参考
* [C# のクラス、構造体、レコードの概要>ユーザ補助](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/object-oriented/#accessibility)
* [アクセス修飾子](https://learn.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers)

また、アクセッサは下記のように定義し、用いる
```C#
public class SampleClass
{
  private string _name = "Hello";

  public string Name
  {
      get { return _name; }
      set { _name = value; }
  }

  // C# 6 以降
  // https://learn.microsoft.com/ja-jp/dotnet/csharp/whats-new/csharp-version-history#c-version-60
  public string Name { get; set; } = "Hello";
}

SampleClass a = new SampleClass();
// 'SampleClass._name' is inaccessible due to its protection level
Console.WriteLine(a._name);

Console.WriteLine(a.Name); // Hello
a.Name = "Bye";
Console.WriteLine(a.Name); // Bye
```


# 032. ノンフィールドRPGを作るための基礎8つのテクニック：はじめに
この章は、2Dのターン制？ゲームの開発を行うための前準備


# 033. シーンの移動
```C#
using UnityEngine.SceneManagement;

public class Sample : MonoBehaviour
{
  void Start()
  {
    SceneManager.LoadScene("Main");
  }
}
```


# 034. ボタン入力の取得
* 適当なオブジェクトに、実行したいメソッドを記載したスクリプトをアタッチ
* Button オブジェクトの On Click() プロパティに、オブジェクトをアタッチ、実行メソッドも指定する
  * Button オブジェクトにデフォルトでOn Click() プロパティが付与されている


# 035. タップ入力の取得
* 押した瞬間に発火する
  * ボタンは、押して離したときにonclickが発火する


# 036. オブジェクトの非表示/表示/破壊
```C#
// [SerializeField] を付与すると、inspector から操作可能になる
// public でもinspector から操作可能だが、他のオブジェクトから操作可能になるため、カプセル化の観点から良くない
[SerializeField] GameObject image;
public void OnClickButton()
{
    Debug.Log("ボタンが押されたちょ");
    image.SetActive(false); // trueなら表示
    Destroy(image); // 削除
}
```


# 037. スクリプト上でのコンポーネントの取得と利用
* 他のオブジェクトについているScriptを取得して実行する
```C#
public class TestScript : MonoBehaviour
{
  public void TestScriptText()
  {
    Debug.Log("TestScriptTextの実行");
  }
}

public class Presenter : MonoBehaviour
{
  [SerializeField] TestScript testScript;
  public void OnClickButton()
  {
    Debug.Log("ボタンが押されたちょ");
    testScript.TestScriptText();
  }
}
```


# 038. Textオブジェクトの取得と変更
スクリプト実行と同じ要領で実行できる
```C#
public class Presenter : MonoBehaviour
{
  [SerializeField] Text testText;
  public void OnClickButton()
  {
    Debug.Log("ボタンが押されたちょ");
    testText.text = "Shimazu";
  }
}
```


# 039. オブジェクトのプレファブ化
所謂テンプレート化
* hierachy に作成したオブジェクトを、Project ビューにドラッグアンドドロップ
* 自動的にプレハブになる


# 040. オブジェクトの生成と親要素の変更（InstantiateとSetParent）
スクリプトからオブジェクトを生成する方法
```C#
// canvas オブジェクトをアタッチ
[SerializeField] Transform parent;
// Unity エディタ上では、プレハブをアタッチする
[SerializeField] GameObject imagePrefab;
void Start()
{
  // Objectの生成
  GameObject image = Instantiate(imagePrefab);
  // 第二引数で、相対位置の指定をリセット
  // image は、Canvas を親要素に指定しないと表示されない
  image.transform.SetParent(parent, false);
}
```


# 041. セーブとロード（PlayerPrefsの利用）
* リビルドしても、データが永続的に保存される
* [レジストリ上に保存されるらしい](https://docs.unity3d.com/ja/2018.4/ScriptReference/PlayerPrefs.html)

```C#
// 保存
string x = "冒険の書";
PlayerPrefs.SetString("SAVE_DATA", x);
PlayerPrefs.Save();
// 取得
Debug.Log(PlayerPrefs.GetString("SAVE_DATA"));
// 削除
PlayerPrefs.DeleteKey("SAVE_DATA");
```


# 042. Json化（オブジェクトを文字列に変換）
```C#
// json 化したいオブジェクトに付与が必要
[Serializable]
public class PlayerModel
{
  // json化したいフィールドに付与
  [SerializeField]
  int hp;
  [SerializeField]
  int at;
  [SerializeField]
  int currentStage;
}

public class Presenter : MonoBehaviour
{
  void Start()
  {
    PlayerModel player = new PlayerModel();

    // object -> json
    string jsonplayer = JsonUtility.ToJson(player);
    Debug.Log(jsonplayer);

    // json -> object
    player = JsonUtility.FromJson<PlayerModel>(jsonplayer);
  }
}
```


# 043. （必須）追加版のお知らせ！
* セクション7(44-60)はスキップして、セクション10以降を進めてほしい
  * 応用が効かない部分があるから
* ただ、全く使われないテクニックという訳でもないらしい


# 073. 追加されたレクチャーの目的と解説
* セクション7は2019年5月ごろに作成した
  * ちょっと難易度が高かったらしい(オンラインサロン等での評判によると)
* セクション7の差し替えになる
* セクション12: フィールド移動など
* セクション13: BGMなどの演出


# 074 ターン制バトルの基礎 : 新規作成
* 2D でプロジェクトを作成する必要があったので、リポジトリも新規で用意した
* initial commit は空コミットにしておいた
* この章では、次章以降で実装する処理をざっと確認した


# 075. 攻撃の実装
* バトル管理、キャラ管理スクリプトをそれぞれ作成して、責務を分担
* 一旦Start() でAttack()を呼び出されるかの確認のみ


# 076. ボタン入力による攻撃の実装
* 上記を、ボタン操作で実行できるように修正


# 077. HPが0になった場合のリスタート
* 一時的な処理として、バトルが終了したら現在のシーンを再読み込みする実装
