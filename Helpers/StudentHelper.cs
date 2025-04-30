using System.Globalization;

namespace ClassHelperExamples.Helpers;

public static class StudentHelper
{
    public static void ListStudents(List<Student> students)
    {
        Console.Clear();
        Console.WriteLine("TÜM ÖĞRENCİLER \n");

        if (students.Count == 0)
        {
            Helper.ShowInfoMsg("Listelenecek öğrenci yok!");
        }
        
        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} - {student.GetAge()}");
        }
    }
    
    public static void AddNewStudent(List<Student> students)
    {
        Console.Clear();
        Console.WriteLine("ÖĞRENCİ EKLE \n");

        var newStudent = new Student
        {
            FirstName = Helper.Ask("Ad", true),
            LastName = Helper.Ask("Soyad", true),
            BirthDate = DateOnly.ParseExact(Helper.Ask("Doğum Tarihi (gg.aa.yyyy)", true), "dd.MM.yyyy"),
            Gender = Helper.Ask("Cinsiyet", true),
        };
        
        students.Add(newStudent);
        
        SaveStudentToTxt(newStudent);
        
        Helper.ShowSuccessMsg("Öğrenci eklendi!");
    }

    private static async Task SaveStudentToTxt(Student student)
    {
        await using var writer = new StreamWriter("students.txt", true);
        await writer.WriteLineAsync($"{student.FirstName};{student.LastName};{student.BirthDate.ToString()};{student.Gender}");
        writer.Close();
    }

    private static async Task SaveToTxt(List<Student> students)
    {
        await using (var writer = new StreamWriter("students.txt"))
        {
            foreach (var student in students)
            {
                await writer.WriteLineAsync($"{student.FirstName};{student.LastName};{student.BirthDate.ToString()};{student.Gender}");
            }
            writer.Close();
        }
    }

    public static async Task<List<Student>> LoadFromTxt()
    {
        var students = new List<Student>();
        
        // yeni using kullanımı örneği
        try
        {
            using var reader = new StreamReader("students.txt");
            var lines = await reader.ReadToEndAsync(); // methodları üst üste yazmaya chaining denir async de farklı yöntemler denemeliyiz.
            foreach (var line in lines.Split("\n"))
            {
                // eğer satırımız boş ise bir sonraki iterasyona geç
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
            
                var parts = line.Split(";");
                students.Add(new Student
                {
                    FirstName = parts[0],
                    LastName = parts[1],
                    BirthDate = DateOnly.ParseExact(parts[2], "dd.MM.yyyy"),
                    Gender = parts[3]
                });
            }
        }
        catch
        {
            // ignored
        }
        
        return students;
    }
}