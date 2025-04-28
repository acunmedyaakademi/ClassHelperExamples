using ClassHelperExamples;
using ClassHelperExamples.Helpers;

var me = new Student
{
    FirstName = "Orhan",
    LastName = "Ekici",
    BirthDate = new DateOnly(1989, 3, 17),
    Gender = "Erkek"
};

var students = new List<Student> { me };

while (true)
{
    Console.Clear();
    Console.WriteLine("Öğrenci Yönetim Sistemi\n".ToUpper());
    var inputSelection = Helper.AskOption("Yapmak istediğin işlemi seç", ["Listele", "Ekle", "Sil", "Çıkış"]);

    if (inputSelection == 1)
    {
        // bu methodun bazı eksikleri var. mesela öğrencileri listelerken eğer öğrenci yoksa bilgi vermeli.
        StudentHelper.ListStudents(students);
    } else if (inputSelection == 2)
    {
        // buraya sihirli kodlar yaz ve diğer else if'leri de yap
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Hoşçakalın...");
        Thread.Sleep(1000);
        break;
    }
    
    Console.WriteLine("\nMenüye dönmek için bir tuşa basın.");
    Console.ReadKey(true);
}



