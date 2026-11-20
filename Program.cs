
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// 学生情報を管理するクラス
class Student
{
    // 学生の名前
    public string Name { get; set; } = "";

    // 数学の点数
    public int MathScore { get; set; }

    // 英語の点数
    public int EnglishScore { get; set; }

    // 国語の点数
    public int JapaneseScore { get; set; }

    // 平均点を計算するメソッド
    public double GetAverage()
    {
        return (MathScore + EnglishScore + JapaneseScore) / 3.0;
    }
}

// アプリケーションのメインクラス
class Program
{
    // 学生情報を管理するリスト
    static List<Student> students = new List<Student>();

    // 学生情報を保存するJSONファイルの場所
    static readonly string filePath =
        Path.Combine(Directory.GetCurrentDirectory(), "students.json");

    // メイン処理
    static void Main()
    {
        // アプリ起動時に保存済みの学生情報を読み込む
        LoadStudents();

        while (true)
        {
            Console.WriteLine("===== 学生成績管理アプリ =====");
            Console.WriteLine("1. 学生情報を登録する");
            Console.WriteLine("2. 学生情報を表示する");
            Console.WriteLine("3. 学生情報を検索する");
            Console.WriteLine("4. 学生情報を編集する");
            Console.WriteLine("5. 学生情報を削除する");
            Console.WriteLine("6. 終了する");
            Console.Write("番号を選択してください：");

            string choice = Console.ReadLine() ?? "";

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
                    EditStudent();
                    break;

                case "5":
                    DeleteStudent();
                    break;

                case "6":
                    Console.WriteLine("アプリを終了します。");
                    return;

                default:
                    Console.WriteLine("1～6の数字を入力してください。");
                    break;
            }
        }
    }

    // 学生情報を登録する
    static void AddStudent()
    {
        Student student = new Student();

        // 名前が空欄でないか確認する
        while (true)
        {
            Console.Write("学生の名前を入力してください：");
            string name = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("名前を入力してください。");
                continue;
            }

            student.Name = name;
            break;
        }

        // 各教科の点数を入力する
        student.MathScore = GetScore("数学");
        student.EnglishScore = GetScore("英語");
        student.JapaneseScore = GetScore("国語");

        // リストに学生情報を追加する
        students.Add(student);

        // 登録した学生情報をJSONファイルに保存する
        SaveStudents();

        Console.WriteLine("学生情報を登録しました！");
    }

    // 点数を入力・チェックする
    static int GetScore(string subject)
    {
        while (true)
        {
            Console.Write($"{subject}の点数を入力してください：");
            string input = Console.ReadLine() ?? "";

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

    // 学生情報をすべて表示する
    static void ShowStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("学生情報が登録されていません。");
            return;
        }

        foreach (Student student in students)
        {
            Console.WriteLine("===== 学生情報 =====");
            Console.WriteLine($"名前：{student.Name}");
            Console.WriteLine($"数学：{student.MathScore}点");
            Console.WriteLine($"英語：{student.EnglishScore}点");
            Console.WriteLine($"国語：{student.JapaneseScore}点");
            Console.WriteLine($"平均点：{student.GetAverage():F1}点");
        }
    }

    // 名前から学生情報を検索する
    static void SearchStudent()
    {
        Console.Write("検索する学生の名前を入力してください：");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("名前を入力してください。");
            return;
        }

        bool found = false;

        foreach (Student student in students)
        {
            if (student.Name == name)
            {
                Console.WriteLine("===== 検索結果 =====");
                Console.WriteLine($"名前：{student.Name}");
                Console.WriteLine($"数学：{student.MathScore}点");
                Console.WriteLine($"英語：{student.EnglishScore}点");
                Console.WriteLine($"国語：{student.JapaneseScore}点");
                Console.WriteLine($"平均点：{student.GetAverage():F1}点");

                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("該当する学生が見つかりませんでした。");
        }
    }

    // 学生情報を編集する
    static void EditStudent()
    {
        Console.Write("編集する学生の名前を入力してください：");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("名前を入力してください。");
            return;
        }

        foreach (Student student in students)
        {
            if (student.Name == name)
            {
                Console.WriteLine("===== 現在の学生情報 =====");
                Console.WriteLine($"名前：{student.Name}");
                Console.WriteLine($"数学：{student.MathScore}点");
                Console.WriteLine($"英語：{student.EnglishScore}点");
                Console.WriteLine($"国語：{student.JapaneseScore}点");

                Console.WriteLine("新しい点数を入力してください。");

                // 点数を更新する
                student.MathScore = GetScore("数学");
                student.EnglishScore = GetScore("英語");
                student.JapaneseScore = GetScore("国語");

                // 編集した学生情報をJSONファイルに保存する
                SaveStudents();

                Console.WriteLine("学生情報を更新しました！");
                return;
            }
        }

        Console.WriteLine("該当する学生が見つかりませんでした。");
    }

    // 学生情報を削除する
    static void DeleteStudent()
    {
        Console.Write("削除する学生の名前を入力してください：");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("名前を入力してください。");
            return;
        }

        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Name == name)
            {
                Console.WriteLine("===== 削除対象の学生 =====");
                Console.WriteLine($"名前：{students[i].Name}");
                Console.WriteLine($"数学：{students[i].MathScore}点");
                Console.WriteLine($"英語：{students[i].EnglishScore}点");
                Console.WriteLine($"国語：{students[i].JapaneseScore}点");

                // リストから学生情報を削除する
                students.RemoveAt(i);

                // 削除した結果をJSONファイルに保存する
                SaveStudents();

                Console.WriteLine("学生情報を削除しました！");
                return;
            }
        }

        Console.WriteLine("該当する学生が見つかりませんでした。");
    }

    // 学生情報をJSONファイルに保存する
    static void SaveStudents()
    {
        try
        {
            // 学生情報をJSON形式の文字列に変換する
            string json = JsonSerializer.Serialize(
                students,
                new JsonSerializerOptions { WriteIndented = true }
            );

            // JSONファイルに書き込む
            File.WriteAllText(filePath, json);

            Console.WriteLine("学生情報を保存しました！");
        }
        catch (IOException ex)
        {
            Console.WriteLine("ファイルの保存に失敗しました。");
            Console.WriteLine(ex.Message);
        }
    }

    // JSONファイルから学生情報を読み込む
    static void LoadStudents()
    {
        // JSONファイルが存在しない場合
        if (!File.Exists(filePath))
        {
            students = new List<Student>();
            return;
        }

        try
        {
            // JSONファイルの内容を読み込む
            string json = File.ReadAllText(filePath);

            // JSON形式から学生情報のリストに変換する
            students = JsonSerializer.Deserialize<List<Student>>(json)
                       ?? new List<Student>();

            Console.WriteLine($"{students.Count}件の学生情報を読み込みました！");
        }
        catch (JsonException)
        {
            Console.WriteLine("JSONファイルの形式が正しくありません。");
            students = new List<Student>();
        }
        catch (IOException ex)
        {
            Console.WriteLine("ファイルの読み込みに失敗しました。");
            Console.WriteLine(ex.Message);
            students = new List<Student>();
        }
    }
}
