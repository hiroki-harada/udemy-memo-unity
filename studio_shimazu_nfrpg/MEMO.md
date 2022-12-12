# 000. 資料
[Unity ゲーム開発：インディーゲームクリエイターが教える C#の基礎からゲームリリースまで【スタジオしまづ】](https://www.udemy.com/course/studio_shimazu_nfrpg/)


# ~003. Unity のインストール
* aws workspace に、諸々のツールインストールを実施


# 004. Unity の初期設定
* Unity のインストールが完了したところから再開
* バージョンは、動画では最新を選択といわれたが、動画に合わせて2019.1.0f2 を選択した
* 使用するエディタの設定などを行う、ただUnity のインストールが完了していない
* とりあえず、動画だけ先に進める


# 005. VSCode のインストール
* 12/02 今日のゴール：セクション7開始 ~ 完了

プロジェクトの作成がまだなので、過去動画に戻って作成、この章自体は流し見する

プロジェクトを作成しようとすると、↓が出る
* failed to resolve project template com.unity.template.3d

もしかしたら、最新のLTS Unity を使用した方が良いかもしれないと思いつつ、原因を調べる
* unity hub をダウングレードする方法があったが、その方法は取りたくないので、それ以外の解決策を探す
* project のパスが長すぎるとエラーになる、とあったが、上記のエラー文と一致しない(decompressと表示されるらしい)

最新のLTS をインストールすることにした(2021.3.15f1)
* インストール待ちの間、先の章を倍速で視聴しておく


# 007. Unity でゲームを作るには
このレッスンでは基本的に、スクリプトからオブジェクトを操作する

* GetComponent<T>
  - スクリプトをアタッチしているオブジェクトの T コンポーネントを取得する


# 008. 最新バージョンでの修正
Text オブジェクトが UI>Legacy>Text に配置変更になった


# 009. 表示される文字の変更
* UI系のオブジェクトは、キャンバスオブジェクト配下に配置しないといけないみたい
* Scene ビューは、developer 向け？

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
* C# 0におけるstring も参照型だが、`string.Equals()`が`==`をオーバーライドしている
* そのため`==`でも比較が可能
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
// C# 6 以降
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
* 通例、メソッド名は大文字始まり(Pascal 形式)
* microsoft も[推奨している](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/coding-style/coding-conventions)


# 028. 【演習】nからmまでの偶数の和を求める関数を作成せよ
.NET プロジェクト`ExerciseProject/`を作成して、そこに解答


# 029. 【演習】3のつく数字と3の倍数でアホになる演習問題
.NET プロジェクト`ExerciseProject/`に解答

12/06 答え合わせ


# 030. classの作成と利用方法
特筆事項なし

# 031. Propertyの作成と利用方法
C# におけるアクセス修飾子の仕様は下記の通り

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


# 078. (追加版)ノンフィールドRPGの基礎：はじめに
12/07 簡易的なターン制システムの作成を行う


# 079. 新規作成と画面サイズの設定
新規でプロジェクトを作成
* 2D, android or ios build support にしておく

プロジェクトの設定
* build settings から、android or ios にswitch platform
* Game ビューから、適当な画面サイズを選択する


# 080. ステージUIとボタンの作成
Text
* best fit をチェックすると、Min/Max size で良い感じの大きさになるのでオススメ

Button
* scene ビュー(左上)から拡大/縮小の操作にスイッチできる


# 081. ボタン入力による進行度の増加をログで実装
* 空オブジェクトにQuestManager スクリプトをアタッチ
* ボタンを押したときに発火させるメソッドを用意して、ログを吐かせる
  * Event System オブジェクトが存在している必要がある


# 082. 進行度の増加をUIに反映
* UIを管理するスクリプトを別で作成する
  * 上記スクリプトから、テキスト等を管理する方針
  * canvas にスクリプトをアタッチする
* UI管理canvasは、QuestManagerから管理する


# 083. Enemyに遭遇する実装
* 適当な配列を用意して、敵に遭遇した場合のログを出す
  * この時点では、arrayIndexOutOfBoundsException が発生するが、次で修正


# 084. クエストクリアしたらログを出す実装
* encountEnemyTable の上限に達したらクリアログを出す


# 085. AssetStoreから敵画像を取得
* AssetStoreから画像のインポートのみ


# 086. Enemy画像の出現を実装
* 画像を直接hierachyに配置できる？
* Assets/Prefabs を切って、プレハブを配置する


# 087. 進行ボタンの表示/非表示
* StageManager から、Button objectを操作する
* 表示/非表示の切り替えメソッドは、共通化できるが、ここではしない


# 088. Enemyのクリック検出
必要な手続き
* 当たり判定
* ray を検出するカメラ　<=??
* 発火させるメソッド

prefab の編集
* prefab > open prefab でprefab 本体にcollider などを付与できる
* EnemyManager を用意して、onclickメソッドを付与する
* prefab > eventTrigger に、onclick 処理として自分自身のonclickメソッドを登録し、発火させる


# 089. PlayerUIとEnemyUIの作成
* それぞれcanvas を用意する
  * PlayerUICanvas : HP, AT のテキスト
  * EnemyUICanvas : HP, Name のテキスト
* それぞれの canvas>text を更新するスクリプトを用意する


# 090. BattleManagerの作成
* name 変数は、オブジェクトの名称を格納した変数として登録されている？
  * **new** string name とする必要がある


# 091. PlayerとEnemyのステータスをUIに反映
* バトル結果をログ出力 -> UI に反映　に変更
* PlayerManager から、UIManager を操作する
* Enemy も同様



# 092. 対戦の初期設定と攻撃実装
* Attack() と　UpdateUI() を適当なメソッドでラップする
* PlayerManager に SetUp() を作成して、初期値の設定を行う
  * Enemy も同様


# 093. QuestManagerによるBattleの開始
* EncountEnemy() で生成した敵をSetUp()に渡す


# 094. Enemyをクリックしたときに攻撃を実装
* BattleManager 上で、Player.Attack() と Enemy.OnClck()をマッピングする
* Action でメソッドの受け渡しを行う


# 095. Enemyの撃破を実装
* Player/EnemyManager にHP 0 にする補正処理
* BattleManager にHPによる分岐を追加して、敵オブジェクトの破壊処理を実装


# 096. 撃破後にクエストに戻る処理の実装
* QuestManager にバトルが終了した際に、フィールド移動を再開する処理を追加
  * BattleManagerから呼び出すみたい
* EnemyUI の表示/非表示処理も追加


# 097. クエストクリアしたらシーンを切り替える実装
* クエストクリア/街に戻るボタンから、街のシーンに遷移する
  * SampleScene を Quest にリネーム
    * ついでに、Quest シーンで使用するスクリプトをScripts/Quest に移動
  * Town シーンを新規作成して、ビルド対象に追加

* SceneManager を作成、シーン読み込みを担当するメソッドを追加
  * 街に戻るボタンから発火させる
  * BattleManager のEndBattle からも実行するようにしていた
  * ＞ここは、進むボタンの非表示のほうが良いかも。。

---

* git 管理しているUnity Project でリネーム/移動するときの注意点
  * メタファイルに対しても、git mv する必要がある
  * 本ファイルとメタファイルを両方処理するまで、Unity Editor は表示させない
    * リネーム後の本ファイルに対する、メタファイルが新規作成されてしまうため


# 098. クエストクリアの演出
* クエストクリア～街に戻る、の間に演出を挟む
* タイトルシーンも作成する

* 小ネタ
  * コンポーネントの ⋮ から copy component でサイズや位置などの情報をまとめてコピーできる


# 099. ノンフィールドRPGの応用：背景画像の取得と設定
* Assets/Images に画像を配置する
  * qiita資料に添付のリンク先、フリー素材を使用
  * 森の画像だけリンク切れで取得できなかったので、[フリー素材を探して使用](https://www.ac-illust.com/main/search_result.php?word=%E6%B4%9E%E7%AA%9F)
* hierachy ビューにドラッグアンドドロップでscene に配置できる
* 拡大/縮小は、なるべくpixel per unit から行う

＞画像の解像度が荒くあまり綺麗にならなかったが、一旦このまま進める


# 100. UI画像の設定
* fantasy wooden ... を Assets store からDL

* Button > source image にAsset から画像を設定できる
* テキストの背景に画像を設定したい場合は、image でTextをラップして、image に画像を設定する
  * ＞各sceceでtextに画像をラップしていたが、prefabを作成したほうが簡単そう
  * ＞ボタン用とステータス等のテキスト表示用で、2パターンprefabを作ってみたい

* prefab に関数を登録する方法
  1. スクリプトをアタッチしたオブジェクトを対象のprefab にアタッチする
    * 通常のオブジェクトの設定方法を同じ
    * ボタンのonclick に、関数をアタッチしたオブジェクトを登録する、など
  2. EventListener を付与して、スクリプトをアタッチする
    * 088. Enemyのクリック検出を参考

画像の表示順番について
* order in layerが大きいほど、前面に表示される


# 101. ゲームクリア画像の設定
クエストクリア時の画像を取得(いらすとや)
* image > set native size で画像本来？のサイズで表示される


# 102. BGMのならし方
下記から素材を取得
* [BGM](https://maoudamashii.jokersounds.com/list/bgm10.html)
  * タイトル（ファンタジー14）
  * クエスト（ファンタジー09）
  * 対戦（ファンタジー12）

* [タウン（街24）](https://maoudamashii.jokersounds.com/list/game9.html)

* Audio Source オブジェクトを作成して、Audio clip プロパティに取得したBGMを設定する


# 103. SEのならし方
下記から素材を取得
  * [ボタン(button01a)](https://taira-komori.jpn.org/game01.html)
  * [攻撃（重打１）](https://taira-komori.jpn.org/attack01.html)
  * [ゲームクリア](https://maoudamashii.jokersounds.com/archives/game_maoudamashii_9_jingle09.html)

* Audio Source にスクリプトを設定して、そこからSEを操作
```C#
public AudioSource audioSourceSE; // SEのスピーカー
public AudioClip audioClip; // ならす素材

public void PlaySE()
{
  audioSourceSE.PlayOneShot(audioClip); // SEを一度だけならす
}
```
* ただ、シーンをまたぐタイミングでAudio Sourceは破壊？される
* 音を鳴らそうとしても、鳴らすオブジェクトがない


# 104. シングルトンの解説
* 103 を解決するために、オブジェクトをシーン間で共有する必要がある
* それをシングルトンで解決する
```C#
public static ClassName instance;
private void Awake()
{
  if (instance == null)
  {
    instance = this;
    DontDestroyOnLoad(this.gameObject);
  }
  else
  {
    Destroy(this.gameObject);
  }
}
```


# 105. シングルトンを使ったBGMのならし方
* 104 の方法を元に、BGM, SE の実装
* プロパティを配列で宣言すると、複数オブジェクトをアタッチできる
  * 今回は、SEを複数アタッチ


# 106. SEを各シーンに設定
* SEもManagerスクリプトを用意して管理するよう、鳴らし方を変更する
* ＞依存関係が複雑になってきているので、後でリファクタする


# 107. BGMの停止
* ちょっとした修正、クエストをクリアしたらBGMを止める
```C#
AudioSource.Stop();
```


# 108. コルーチンの実装
* 処理実行にラグを持たせるため、コルーチンを利用する
* ↓サンプル
```C#
private void Start()
{
  enemyUI.gameObject.SetActive(false);
  // IEnumerator を返すメソッドを、StartCoroutine の引数に渡す
  StartCoroutine(SampleCol());
}

// IEnumerator を返す
IEnumerator SampleCol()
{
  Debug.Log("コルーチン開始");
  yield return new WaitForSeconds(2f);
  Debug.Log("２秒経過");
}
```


# 109. コルーチンを使った攻撃の実装
* プレイヤーの攻撃から敵の攻撃まで、1秒ラグを持たせてみる
* プレイヤーの攻撃前に、コルーチンを一旦停止させる
  * ＞ボタン連打された場合、コルーチンが複数発火するとよくないらしい


# 110. DoTweenの導入
* DoTween のインポート
* ＞unity developer なら必ず使っている位、有名なasset らしい


# 111. ダメージアニメーションの実装
* 敵オブジェクトのtransformを振動させる
* プレイヤーオブジェクトについては、カメラを振動させる
```C#
using DG.Tweening;

// ↓に適当なパラメータを指定して、オブジェクトの振動制御
transform.DOShakePosition();
```


# 112. 敵を撃破したときの処理を遅らせる
* よりゲーム性をもたせるため、ちょっとした修正
* EndGame() も IEnumerator を返すようにする


