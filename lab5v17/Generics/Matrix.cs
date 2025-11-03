using System;

namespace lab5v17.Generics
{
    public class Matrix<T>
    {
        private readonly T[,] _data;

        public int Rows { get; }
        public int Cols { get; }

        public Matrix(int rows, int cols, T? defaultValue = default)
        {
            if (rows <= 0 || cols <= 0) throw new ArgumentException("Розміри матриці мають бути > 0");
            Rows = rows;
            Cols = cols;
            _data = new T[rows, cols];

            // Якщо задано не-дефолтне значення — заповнити ним
            if (!Equals(defaultValue, default(T)))
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        _data[i, j] = defaultValue!;
            }
        }

        public T this[int r, int c]
        {
            get => _data[r, c];
            set => _data[r, c] = value;
        }
    }
}
