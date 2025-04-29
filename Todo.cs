namespace ClassHelperExamples;

// access modifiers - yetkilendirme kelimeleri
// public
// private
// protected
// internal

// assembly 
// internal sadece aynı assembly içinden çağrılabilir demek
public class Todo
{
    public int Id { get; }
    public string Task { get; set; } // task = iş
    public bool IsCompleted { get; set; }

    public Todo()
    {
        Id = 1;
    }
}