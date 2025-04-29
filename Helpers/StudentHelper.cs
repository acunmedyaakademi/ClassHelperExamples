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
        
        students.Add(new Student
        {
            FirstName = Helper.Ask("Ad", true),
            LastName = Helper.Ask("Soyad", true),
            BirthDate = DateOnly.ParseExact(Helper.Ask("Doğum Tarihi (gg.aa.yyyy)", true), "dd.MM.yyyy"),
            Gender = Helper.Ask("Cinsiyet", true),
        });
        
        SaveToTxt(students);
        
        Helper.ShowSuccessMsg("Öğrenci eklendi!");
    }
    
    public static void SaveToTxt(List<Student> students)
    {
        using (var writer = new StreamWriter("students.txt"))
        {
            foreach (var student in students)
            {
                writer.WriteLine($"{student.FirstName};{student.LastName};{student.BirthDate.ToString()};{student.Gender}");
            }
            writer.Close();
        }
    }

    public static List<Student> LoadFromTxt()
    {
        var students = new List<Student>();
        
        // yeni using kullanımı örneği
        try
        {
            using var reader = new StreamReader("students.txt");
            var lines = reader.ReadToEnd().Split("\n");
            foreach (var line in lines)
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