
# 03：Programクラスの詳細解説

## 1. Programクラスの役割

`Program` クラスは、学生成績管理アプリ全体の処理を管理するクラスである。

`Student` クラスが学生の名前や点数などの情報を管理するのに対して、`Program` クラスは学生情報の登録・表示・検索などの機能を実行する。

現在実装している主な機能は次の4つである。

1. 学生情報の登録
2. 学生情報の一覧表示
3. 学生情報の検索
4. アプリケーションの終了

## 2. Programクラスの基本構造

```csharp
class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        // メニューを表示して処理を選択する
    }

    static void AddStudent()
    {
        // 学生情報を登録する
    }

    static int GetScore(string subject)
    {
        // 点数を入力してもらう
    }

    static void ShowStudents()
    {
        // 学生情報を一覧表示する
    }

    static void SearchStudent()
    {
        // 学生情報を検索する
    }
}
```

※上記はクラスの構造を理解するための抜粋であり、実際のProgram.csには各メソッドの処理が記述されている。

## 3. class Program

```csharp
class Program
```

- `class`：クラスを定義するためのキーワード。
- `Program`：クラスの名前。

Programクラスは、アプリケーションの処理をまとめる役割を持つ。

StudentクラスとProgramクラスを分けることで、学生情報の管理とアプリケーションの処理を整理できる。

## 4. 学生情報を保存するList

```csharp
static List<Student> students = new List<Student>();
```

このコードは、学生情報を複数保存するためのリストを作成している。

### ① static

`static` は、クラスに属するメンバーであることを示す。

このプログラムでは、MainメソッドやAddStudentメソッドなどから同じ学生リストを利用できるようにしている。

### ② List<Student></student>

`List<T>` は、複数のデータを順番に管理できるコレクションである。

今回の `Student` は、リストに格納するデータの型を表している。

つまり、`List<Student>` はStudent型のオブジェクトを複数保存できるリストである。

### ③ students

`students` はリストにつけた変数名である。

学生情報を登録すると、このリストに追加される。

### ④ new List<Student></student>()

`new` は、新しいオブジェクトを生成するためのキーワード。

`new List<Student>()` によって、Student型のデータを保存するための新しいリストを作成している。

### 実際の動作イメージ

学生を3人登録した場合、リストには次のような情報が保存される。

```text
students
  ├─ Student（山田太郎）
  ├─ Student（佐藤花子）
  └─ Student（鈴木一郎）
```

### 注意点

現在のstudentsはメモリ上に保存される。

そのため、アプリを終了すると登録した学生情報は失われる。

今後はJSONファイルやデータベースを利用して、データを保存できるようにする予定である。

## 5. Mainメソッド

```csharp
static void Main()
```

Mainメソッドは、C#のコンソールアプリケーションにおけるエントリーポイントである。

プログラムを実行すると、基本的に最初にMainメソッドから処理が始まる。

### それぞれの意味

- `static`：クラスのインスタンスを作成しなくても呼び出せる。
- `void`：メソッドが値を返さないことを示す。
- `Main`：プログラムの実行開始地点となるメソッド名。
- `()`：メソッドの引数を記述する場所。

## 6. while(true)によるメニューの繰り返し

```csharp
while (true)
{
    // メニューを表示する
}
```

`while` は、指定した条件がtrueである間、処理を繰り返す構文である。

今回の `true` は常に真であるため、基本的には無限ループになる。

メニューを何度でも表示し、ユーザーが複数の操作を続けられるようにするために利用している。

ただし、アプリを終了するときには `return` などでMainメソッドを終了させる必要がある。

## 7. Console.WriteLineによる画面表示

```csharp
Console.WriteLine("===== 学生成績管理アプリ =====");
```

`Console.WriteLine()` は、コンソール画面に文字列を表示するメソッドである。

表示した後、自動的に改行される。

例えば、次のコードを実行すると、

```csharp
Console.WriteLine("こんにちは");
Console.WriteLine("学生成績管理アプリです");
```

次のように表示される。

```text
こんにちは
学生成績管理アプリです
```

## 8. Console.ReadLineによる入力

```csharp
string? choice = Console.ReadLine();
```

`Console.ReadLine()` は、ユーザーが入力した文字列を読み取るメソッドである。

例えば、メニューで「1」を入力すると、その文字列を取得できる。

### string? の意味

- `string`：文字列型。
- `?`：nullになる可能性があることを示す。

Console.ReadLine()は、入力が終了した場合などにnullを返す可能性がある。

そのため、nullを考慮した変数宣言になっている。

### ?? 演算子

```csharp
string choice = Console.ReadLine() ?? "";
```

`??` はnull合体演算子と呼ばれる。

左側の値がnullの場合、右側の値を使用する。

この例では、Console.ReadLine()がnullなら空文字列を代入する。

## 9. switch文によるメニュー選択

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

    case "4":
        return;

    default:
        Console.WriteLine("正しい番号を入力してください。");
        break;
}
```

### switch

`switch` は、変数の値に応じて処理を分岐させる構文である。

今回の場合、ユーザーが入力したchoiceの値によって実行するメソッドを変えている。

### case

`case` は、値が一致した場合に実行する処理を指定する。

- `"1"`：学生情報を登録する。
- `"2"`：学生情報を表示する。
- `"3"`：学生情報を検索する。
- `"4"`：アプリケーションを終了する。

### break

`break` は、switch文から抜け出すために使う。

例えば、case "1"でAddStudent()を実行した後、breakによってswitch文を終了し、Mainメソッドの次の処理へ進む。

### return

`return` は、現在実行しているメソッドを終了する。

今回のcase "4"ではMainメソッドを終了するため、アプリケーションの処理も終了する。

### default

どのcaseにも一致しなかった場合に実行される。

例えば、ユーザーが「5」を入力した場合に、正しい番号を入力するように案内する。

## 10. AddStudentメソッド：学生情報の登録

```csharp
static void AddStudent()
{
    Student student = new Student();

    // 学生の名前を入力する
    // 数学・英語・国語の点数を入力する

    students.Add(student);
}
```

※実際の処理には、空欄チェックやGetScoreメソッドによる点数チェックも含まれる。

### ① Student student = new Student();

新しいStudentオブジェクトを作成する。

- `Student`：データ型。
- `student`：変数名。
- `new Student()`：新しいStudentオブジェクトを生成する。

このオブジェクトに名前や点数を設定する。

### ② students.Add(student);

```csharp
students.Add(student);
```

`Add()` は、Listに新しい要素を追加するメソッドである。

今回の場合、入力した学生情報をstudentsリストに追加している。

## 11. GetScoreメソッド：点数の入力チェック

```csharp
static int GetScore(string subject)
{
    while (true)
    {
        Console.Write(subject + "の点数を入力してください：");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int score))
        {
            if (score >= 0 && score <= 100)
            {
                return score;
            }
        }

        Console.WriteLine("0～100の整数を入力してください。");
    }
}
```

※上記は主要な処理を理解するための例である。実際のProgram.csと照らし合わせて確認する。

### ① static int GetScore(string subject)

- `static`：クラスから直接呼び出せる。
- `int`：整数を返すメソッドである。
- `GetScore`：メソッド名。
- `string subject`：科目名を受け取る引数。

例えば、GetScore("数学")と呼び出すと、数学の点数を入力するように表示できる。

### ② while (true)

正しい点数が入力されるまで、入力処理を繰り返す。

### ③ int.TryParse()

```csharp
int.TryParse(input, out int score)
```

TryParseは、文字列を整数に変換できるかどうかを確認するメソッドである。

変換できた場合はtrue、できなかった場合はfalseを返す。

例えば、

- `"80"`：整数に変換できる。
- `"abc"`：整数に変換できない。
- `"80.5"`：整数として変換できない。

### ④ out

`out` は、メソッドから値を受け取るために使うキーワードである。

今回の場合、変換できた整数をscoreに格納する。

### ⑤ score >= 0 && score <= 100

点数が0以上かつ100以下であるかを確認する。

`&&` はAND演算子で、左右の条件が両方trueの場合にtrueとなる。

これによって、0～100の範囲の点数だけを受け付ける。

### ⑥ return score;

入力された点数を呼び出し元のメソッドに返す。

正しい点数が入力された場合は、その値を返してGetScoreの処理を終了する。

## 12. ShowStudentsメソッド：学生情報の一覧表示

```csharp
static void ShowStudents()
{
    if (students.Count == 0)
    {
        Console.WriteLine("登録されている学生はいません。");
        return;
    }

    foreach (Student student in students)
    {
        Console.WriteLine(student.Name);
        Console.WriteLine(student.MathScore);
        Console.WriteLine(student.EnglishScore);
        Console.WriteLine(student.JapaneseScore);
        Console.WriteLine(student.GetAverage().ToString("F1"));
    }
}
```

※実際のコードでは、各情報に説明用の文字列を付けて表示している。

### ① students.Count

`Count` は、Listに格納されている要素数を取得するプロパティである。

例えば、学生を3人登録している場合、students.Countは3になる。

### ② if (students.Count == 0)

登録されている学生が0人かどうかを確認する。

学生がいない場合は、そのことを画面に表示してreturnでメソッドを終了する。

### ③ foreach

```csharp
foreach (Student student in students)
```

foreachは、コレクションに格納されている要素を順番に取り出すための構文である。

今回の場合、studentsに登録されているStudentオブジェクトを1人ずつ取り出している。

### ④ student.Name

StudentオブジェクトのNameプロパティにアクセスしている。

同じように、MathScore、EnglishScore、JapaneseScoreから各科目の点数を取得できる。

### ⑤ student.GetAverage()

Studentクラスで定義したGetAverage()メソッドを呼び出している。

これによって、学生の3科目の平均点を取得できる。

### ⑥ ToString("F1")

```csharp
student.GetAverage().ToString("F1")
```

ToString("F1")は、数値を小数点以下1桁で表示するための書式指定である。

例えば、平均点が80.666...の場合、80.7と表示できる。

## 13. SearchStudentメソッド：学生情報の検索

```csharp
static void SearchStudent()
{
    Console.Write("検索する学生の名前を入力してください：");

    string? name = Console.ReadLine();

    bool found = false;

    foreach (Student student in students)
    {
        if (student.Name == name)
        {
            // 学生情報を表示する
            found = true;
        }
    }

    if (!found)
    {
        Console.WriteLine("該当する学生が見つかりません。");
    }
}
```

※上記は検索処理の主要部分を抜粋した例である。

### ① bool found = false;

`bool` は、trueまたはfalseの2つの値を扱うデータ型である。

foundは、検索対象の学生が見つかったかどうかを管理する変数である。

最初はまだ見つかっていないため、falseにしておく。

### ② foreach

studentsに登録されている学生を1人ずつ確認する。

### ③ if (student.Name == name)

検索する名前と、リスト内の学生の名前が一致しているかを確認する。

`==` は、左右の値が等しいかどうかを比較する演算子である。

### ④ found = true;

一致する学生が見つかった場合、foundをtrueに変更する。

### ⑤ if (!found)

`!` はNOT演算子である。

`!found` はfoundがfalseであることを意味する。

つまり、検索結果が見つからなかった場合に、該当する学生がいないというメッセージを表示する。

## 14. アプリケーション全体の処理の流れ

```text
アプリケーション開始
        ↓
     Main()
        ↓
   メニューを表示
        ↓
  ユーザーが番号を入力
        ↓
    switchで分岐
        │
   ┌────┼────┬────┐
   ↓    ↓    ↓    ↓
  登録  表示  検索  終了
   ↓    ↓    ↓    ↓
AddStudent  ShowStudents  SearchStudent  return
   │    │    │
   └────┴────┘
        ↓
   メニューに戻る
```

このように、Mainメソッドが全体の流れを管理し、具体的な処理は各メソッドに分けて実行している。

## 15. 今回学んだC#の重要な知識

| C#の構文・機能 | 役割                                   |
| -------------- | -------------------------------------- |
| class          | クラスを定義する                       |
| static         | クラスに属するメンバーを定義する       |
| void           | 戻り値がないことを示す                 |
| int            | 整数型                                 |
| string         | 文字列型                               |
| bool           | true・falseを扱う                      |
| List<T></t>    | 複数のデータを管理する                 |
| new            | オブジェクトを生成する                 |
| while          | 条件に応じて繰り返す                   |
| switch         | 条件に応じて処理を分岐する             |
| foreach        | コレクションの要素を順番に取り出す     |
| if             | 条件によって処理を分岐する             |
| return         | メソッドを終了し、必要に応じて値を返す |
| break          | switchやループなどから抜け出す         |
| TryParse       | 文字列を数値などに変換できるか確認する |

## 16. なぜ処理をメソッドに分けたのか

今回のアプリでは、登録・表示・検索などの機能を別々のメソッドに分けている。

理由は次のとおりである。

1. **可読性の向上：** どのメソッドが何を担当しているか分かりやすい。
2. **保守性の向上：** ある機能を変更するときに、修正箇所を特定しやすい。
3. **再利用性の向上：** 同じ処理を必要な場所から呼び出せる。
4. **テストのしやすさ：** 機能ごとに動作を確認しやすい。

例えば、点数入力のチェックをGetScoreメソッドにまとめることで、数学・英語・国語の入力時に同じ処理を利用できる。

## 17. 現在のアプリケーションの課題

現時点では、学生情報の登録・表示・検索ができる。

一方で、今後改善したい点もある。

| 課題                     | 今後の改善案                         |
| ------------------------ | ------------------------------------ |
| データが終了時に消える   | JSONファイルやデータベースに保存する |
| 学生情報を変更できない   | 編集機能を追加する                   |
| 学生情報を削除できない   | 削除機能を追加する                   |
| 名前だけで検索している   | 学生IDによる検索を追加する           |
| コンソール画面で操作する | Webアプリケーションに発展させる      |

## 18. 面接で聞かれそうな質問と回答例

### Q1. このアプリケーションでは、どのような機能を実装しましたか？

**回答例：**

C#を用いて学生成績管理アプリを開発しました。学生の名前と3科目の点数を登録し、一覧表示や名前による検索ができるようにしています。また、点数入力時にはTryParseを利用し、整数以外の入力や0～100の範囲外の点数を受け付けないようにしました。

### Q2. なぜList<Student></student>を使用したのですか？

**回答例：**

複数の学生情報をまとめて管理するためです。Studentクラスで学生1人分の情報を定義し、それをList<Student></student>に格納することで、学生の追加や一覧表示、検索を実装しやすくしました。

### Q3. なぜ処理を複数のメソッドに分けたのですか？

**回答例：**

処理ごとの役割を明確にし、コードの見通しを良くするためです。例えば、学生登録はAddStudent、点数入力はGetScoreというように分けました。これにより、機能ごとに修正や動作確認をしやすくなると考えました。

### Q4. 今後どのような機能を追加したいですか？

**回答例：**

まずは学生情報の編集・削除機能と、アプリケーション終了後も情報を保持できる保存機能を追加したいです。その後、Web技術も学びながら、ブラウザから利用できるアプリケーションに発展させたいと考えています。

## 19. 理解度チェック

次の質問に、自分の言葉で答えられるか確認する。

1. StudentクラスとProgramクラスの役割の違いは何か？
2. List<Student></student>を使用する理由は何か？
3. Mainメソッドはどのような役割を持つか？
4. while(true)を使用する理由は何か？
5. switch文とif文はどのように使い分けられるか？
6. breakとreturnの違いは何か？
7. TryParseを使用する理由は何か？
8. foreachはどのような処理に使うか？
9. foundというbool型の変数は何のためにあるか？
10. 現在のアプリケーションの課題は何か？

## 20. 学習の振り返り

今回学んだこと：

- Programクラスの役割を理解できたか？
- Mainメソッドからアプリケーションが始まる仕組みを理解できたか？
- List<Student></student>の仕組みを理解できたか？
- 各メソッドの役割を説明できるか？
- if、switch、while、foreachの違いを理解できたか？
- TryParseによる入力チェックの仕組みを理解できたか？

**次の学習目標：**

Programクラスのコードを見ながら、各メソッドがどのようにつながって動作するのかを自分の言葉で説明できるようにする。
