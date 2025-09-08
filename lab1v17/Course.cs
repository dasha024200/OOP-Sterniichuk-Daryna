namespace Lab1v17
{
    public class Course
    {
        // Поля
        private string _title;
        private string _teacher;

        // Властивість
        public int Credits { get; set; }

        // Конструктор
        public Course(string title, string teacher, int credits)
        {
            _title = title;
            _teacher = teacher;
            Credits = credits;
        }

        // Метод
        public void EnrollStudent(string studentName)
        {
            Console.WriteLine($"{studentName} зараховано на курс \"{_title}\" (викладач: {_teacher}, кредити: {Credits}).");
        }

        public override string ToString() =>
            $"Курс: {_title}, Викладач: {_teacher}, Кредити: {Credits}";
    }
}
