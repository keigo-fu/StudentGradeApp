
# 07. C#基礎知識

## 1. この資料の目的

この資料では、学生成績管理アプリの開発で使用したC#の基本的な文法や構文を整理する。

今回の開発では、学生情報の登録・表示・検索・編集・削除に加えて、JSON形式によるデータ保存・読み込みを実装した。

その過程で、クラス、プロパティ、メソッド、条件分岐、繰り返し処理、リスト、例外処理など、C#の基本的な仕組みを使用した。

今後ASP.NET Coreを利用したWebアプリを開発する際にも、これらの知識が必要になる。

## 2. 変数とデータ型

変数とは、プログラムで使用するデータを格納するためのものである。

C#では、変数を宣言する際にデータ型を指定する。

```csharp
string name = "山田太郎";
int mathScore = 80;
double average = 80.0;
bool found = false;
```

| データ型 | 意味             | 使用例         |
| -------- | ---------------- | -------------- |
| string   | 文字列           | 学生の名前     |
| int      | 整数             | 各科目の点数   |
| double   | 小数を扱える数値 | 平均点         |
| bool     | trueまたはfalse  | 検索結果の判定 |

今回のアプリでは、名前をstring型、点数をint型、平均点をdouble型で管理している。

## 3. クラスとオブジェクト

### クラスとは

クラスとは、データや処理をまとめるための設計図である。

今回のアプリでは、学生情報を管理するためにStudentクラスを作成した。

```csharp
class Student
{
    public string Name { get; set; } = "";
    public int MathScore { get; set; }
    public int EnglishScore { get; set; }
    public int JapaneseScore { get; set; }

    public double GetAverage()
    {
        return (MathScore + EnglishScore + JapaneseScore) / 3.0;
    }
}
```

Studentクラスには、学生の名前、各科目の点数、平均点を計算する処理をまとめている。

### オブジェクトとは

オブジェクトとは、クラスをもとに作成した実体である。

```csharp
Student student = new Student();
```

このコードでは、Studentクラスをもとに新しい学生オブジェクトを作成している。

### クラスを使用する理由

学生情報を管理するためのデータと処理をまとめられるため、プログラムの構造を整理しやすくなる。

また、学生ごとに異なるオブジェクトを作成できる。

## 4. プロパティ

プロパティとは、クラスが持つデータにアクセスするための仕組みである。

```csharp
public string Name { get; set; } = "";
```

| 部分   | 意味                           |
| ------ | ------------------------------ |
| public | クラスの外部からアクセスできる |
| string | 文字列型                       |
| Name   | プロパティ名                   |
| get    | 値を取得する                   |
| set    | 値を設定する                   |
| = ""   | 初期値を空文字列にする         |

例えば、次のように値を設定できる。

```csharp
student.Name = "山田太郎";
student.MathScore = 80;
```

また、値を取得することもできる。

```csharp
Console.WriteLine(student.Name);
```

## 5. メソッド

メソッドとは、特定の処理をまとめたものである。

今回のアプリでは、機能ごとにメソッドを分けて実装した。

| メソッド        | 役割                   |
| --------------- | ---------------------- |
| Main()          | アプリ全体の処理を管理 |
| AddStudent()    | 学生情報の登録         |
| ShowStudents()  | 学生情報の表示         |
| SearchStudent() | 学生情報の検索         |
| EditStudent()   | 学生情報の編集         |
| DeleteStudent() | 学生情報の削除         |
| GetScore()      | 点数の入力と検証       |
| SaveStudents()  | 学生情報の保存         |
| LoadStudents()  | 学生情報の読み込み     |
| GetAverage()    | 平均点の計算           |

例えば、平均点を計算するメソッドは以下のとおり。

```csharp
public double GetAverage()
{
    return (MathScore + EnglishScore + JapaneseScore) / 3.0;
}
```

メソッドに処理を分けることで、Main()にすべての処理を書く必要がなくなり、プログラムを理解・修正しやすくなる。

## 6. staticとvoid

### static

staticは、クラス自体に属するメンバーを定義するために使用する。

今回のProgramクラスでは、Main()や各機能のメソッドをstaticとして定義している。

```csharp
static void Main()
{
    // アプリの処理
}
```

Main()は、アプリケーションの実行開始時に呼び出されるエントリーポイントである。

### void

voidは、メソッドが値を返さないことを表す。

```csharp
static void ShowStudents()
{
    Console.WriteLine("学生情報を表示します。");
}
```

一方、GetAverage()は計算結果を返すため、戻り値の型としてdoubleを指定している。

```csharp
public double GetAverage()
{
    return 80.0;
}
```

## 7. 条件分岐：ifとswitch

条件分岐とは、条件に応じて実行する処理を変える仕組みである。

### if文

```csharp
if (students.Count == 0)
{
    Console.WriteLine("学生情報が登録されていません。");
}
```

この例では、学生情報の件数が0件の場合にメッセージを表示する。

### else

```csharp
if (score >= 0 && score <= 100)
{
    return score;
}
else
{
    Console.WriteLine("0～100の整数を入力してください。");
}
```

条件を満たす場合と満たさない場合で処理を分けられる。

### switch文

```csharp
switch (choice)
{
    case "1":
        AddStudent();
        break;

    case "2":
        ShowStudents();
        break;

    case "3":
        SearchStudent();
        break;

    default:
        Console.WriteLine("正しい番号を入力してください。");
        break;
}
```

ユーザーが入力した番号に応じて、実行する機能を切り替えている。

## 8. 繰り返し処理：whileとforeachとfor

### while文

whileは、指定した条件が成立している間、処理を繰り返す。

```csharp
while (true)
{
    Console.WriteLine("メニューを表示します。");
}
```

今回のアプリでは、メニューを繰り返し表示するために使用している。

なお、while(true)は条件が常にtrueであるため、returnなどで処理を終了しない限り繰り返し続ける。

### foreach文

foreachは、コレクションに格納された要素を順番に取り出すために使用する。

```csharp
foreach (Student student in students)
{
    Console.WriteLine(student.Name);
}
```

今回のアプリでは、登録された学生情報を一覧表示したり、検索・編集したりする際に使用している。

### for文

forは、繰り返す回数や条件を指定して処理を行う。

```csharp
for (int i = 0; i < students.Count; i++)
{
    Console.WriteLine(students[i].Name);
}
```

今回の削除機能では、インデックスを使って対象の学生を探し、RemoveAt()で削除している。

foreachで要素を列挙している最中にリストを変更すると、例外が発生する可能性がある。そのため、削除機能ではfor文を利用した。

## 9. List<T></t>：リスト

List<T></t>は、複数のデータをまとめて管理できるコレクションである。

今回のアプリでは、学生情報をList<Student></student>で管理している。

```csharp
static List<Student> students = new List<Student>();
```

| コード                  | 意味                              |
| ----------------------- | --------------------------------- |
| List<Student></student> | Student型のデータを格納するリスト |
| students                | リストの変数名                    |
| new                     | 新しいインスタンスを作成する      |
| Add()                   | 要素を追加する                    |
| RemoveAt()              | 指定した位置の要素を削除する      |
| Count                   | 要素数を取得する                  |

### 学生情報の追加

```csharp
students.Add(student);
```

### 学生情報の件数確認

```csharp
students.Count
```

### 学生情報の削除

```csharp
students.RemoveAt(i);
```

Listは要素数が変化するデータを管理する際に便利である。

## 10. 入力処理と入力チェック

### Console.ReadLine()

```csharp
string name = Console.ReadLine() ?? "";
```

Console.ReadLine()は、コンソールから入力された文字列を読み取る。

??は、左側の値がnullの場合に右側の値を使用する演算子である。

### string.IsNullOrWhiteSpace()

```csharp
if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("名前を入力してください。");
}
```

文字列がnull、空文字列、または空白だけの場合にtrueを返す。

名前の未入力を防ぐために使用している。

### int.TryParse()

```csharp
if (int.TryParse(input, out int score))
{
    Console.WriteLine(score);
}
```

文字列を整数に変換できるか確認する。

変換できた場合はtrue、できなかった場合はfalseを返す。

今回のアプリでは、点数として整数が入力されたか確認するために利用している。

さらに0～100の範囲に収まっているかを確認することで、不適切な点数の登録を防いでいる。

## 11. returnとbreak

### return

returnは、メソッドの処理を終了するために使用する。

```csharp
if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("名前を入力してください。");
    return;
}
```

この場合、名前が入力されていなければ、そのメソッドの処理を終了する。

### break

breakは、主にswitch文や繰り返し処理から抜け出すために使用する。

```csharp
case "1":
    AddStudent();
    break;
```

この場合、case "1"の処理を終えてswitch文から抜け出す。

returnはメソッド自体を終了し、breakは対象となるswitch文やループから抜け出すという違いがある。

## 12. 例外処理：try-catch

例外処理とは、プログラムの実行中に発生したエラーに対応するための仕組みである。

```csharp
try
{
    File.WriteAllText(filePath, json);
}
catch (IOException ex)
{
    Console.WriteLine("ファイルの保存に失敗しました。");
    Console.WriteLine(ex.Message);
}
```

| 構文       | 役割                             |
| ---------- | -------------------------------- |
| try        | エラーが発生する可能性のある処理 |
| catch      | 指定した例外が発生した場合の処理 |
| ex         | 例外に関する情報                 |
| ex.Message | エラーの内容を表すメッセージ     |

今回のアプリでは、ファイルの保存・読み込みに関するエラーや、JSONの形式に関するエラーに対応するために使用している。

## 13. JSONとファイル操作

### JSONへの変換

```csharp
string json = JsonSerializer.Serialize(
    students,
    new JsonSerializerOptions { WriteIndented = true }
);
```

C#のList<Student></student>をJSON形式の文字列に変換する。

### JSONからの復元

```csharp
students = JsonSerializer.Deserialize<List<Student>>(json)
           ?? new List<Student>();
```

JSON形式の文字列をList<Student></student>に変換する。

### ファイルへの保存

```csharp
File.WriteAllText(filePath, json);
```

指定したファイルに文字列を書き込む。

### ファイルからの読み込み

```csharp
string json = File.ReadAllText(filePath);
```

指定したファイルから文字列を読み込む。

## 14. 今回の開発で重要だった考え方

今回の開発では、単にC#の文法を使用するだけでなく、プログラムを機能ごとに整理することを意識した。

特に重要だった点は以下のとおり。

1. Studentクラスに学生情報と平均点の計算処理をまとめた。
2. Programクラスでは、登録・表示・検索・編集・削除などの処理をメソッドに分けた。
3. List<Student></student>を利用して複数の学生情報を管理した。
4. TryParse()や条件分岐を利用して入力チェックを行った。
5. JSON形式を利用して、アプリ終了後も学生情報を保持できるようにした。

## 15. Webアプリ開発との関係

今後、ASP.NET Core Razor Pagesを利用したWebアプリを開発する際にも、今回学んだC#の知識を活用できる。

| 現在学んだ知識 | Webアプリでの活用          |
| -------------- | -------------------------- |
| class          | 学生情報を表すモデル       |
| property       | 学生の名前や点数の管理     |
| method         | 登録・検索・編集などの処理 |
| if             | 入力チェックや条件判定     |
| List<T></t>    | 複数の学生情報の管理       |
| try-catch      | エラーへの対応             |
| JSON           | データの受け渡しや保存     |
| File操作       | ファイルの読み書き         |

ただし、Webアプリではブラウザからの入力を受け取る仕組みや、HTTPリクエスト、データベースなど、新しい知識も必要になる。

## 16. 理解度チェック

以下の質問に自分の言葉で答えられるか確認する。

- [ ] classとobjectの違いを説明できる。
- [ ] stringとintとdoubleの違いを説明できる。
- [ ] getとsetの役割を説明できる。
- [ ] メソッドに処理を分ける理由を説明できる。
- [ ] if文とswitch文の違いを説明できる。
- [ ] while・foreach・forの違いを説明できる。
- [ ] List<Student></student>の役割を説明できる。
- [ ] TryParse()を使う理由を説明できる。
- [ ] returnとbreakの違いを説明できる。
- [ ] try-catchの役割を説明できる。
- [ ] Serialize()とDeserialize()の違いを説明できる。

## 17. 学習の振り返り

今回の成績管理アプリの開発を通じて、C#の基本的な文法だけでなく、複数の機能を組み合わせて一つのアプリケーションを構築する経験を得ることができた。

今後は、これらの知識を土台として、ASP.NET CoreによるWebアプリ開発に取り組みたい。
