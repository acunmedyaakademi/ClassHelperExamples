namespace ClassHelperExamples;

public class Person // kişi
{
    // private sadece kendi class'ı içinde erişim
    // protected private gibi ama interit edilebilir
    protected int GenerateId() 
    {
        return 1;
    }
    public string FirstName { get; set; } // ad
    public string LastName { get; set; } // soyad
    public DateOnly BirthDate { get; set; } // yaş
    public string Gender { get; set; }

    public int GetAge()
    {
        return CalculateAge();
    }

    private int CalculateAge()
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - BirthDate.Year;
        if (today < BirthDate.AddYears(age))
        {
            age--;
        }

        return age;
    }

    public Person()
    {
        GenerateId();
    }
}

public class Student : Person
{
    public string ClassName { get; set; }

    public Student()
    {
        GenerateId();
    }
}

