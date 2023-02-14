// See https://aka.ms/new-console-template for more information
class main
{
    public static void Main(string[] args)
    {
        string[] student = new string[5];
        for(int i = 0; i < student.Length; i++)
        {
            student[i] = Console.ReadLine();
        }
        
        var list = student.ToList();
        foreach(var i in list)
        {
            if(i.Contains("Nhat"))
            {
                list.Remove(i);
                break;
            }
        }

        foreach(var i in list)
        {
            Console.WriteLine(i);
        }
    }
}