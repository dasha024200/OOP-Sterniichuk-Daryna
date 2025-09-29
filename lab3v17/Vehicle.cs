using System;

namespace Lab3.Vehicles
{
    // Базовий абстрактний клас: показує спільні поля/поведінку
    public abstract class Vehicle
    {
        public string Model { get; }
        // Базова витрата в л/100км за “ідеальних” умов (порожній транспорт)
        public double BaseLitersPer100 { get; }

        protected Vehicle(string model, double baseLitersPer100)
        {
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model cannot be empty");
            if (baseLitersPer100 <= 0) throw new ArgumentException("Base consumption must be > 0");

            Model = model;
            BaseLitersPer100 = baseLitersPer100;
        }

        // Абстрактний метод: похідні МАЮТЬ реалізувати формулу витрати на сегмент
        public abstract double FuelConsumption(RouteSegment segment);

        // Поліморфне представлення
        public override string ToString() => $"{GetType().Name} {Model} (base {BaseLitersPer100:0.##} L/100km)";

        // Демонстраційний деструктор (finalizer) для критерію з “деструктором”
        ~Vehicle()
        {
            // У житті так робити не треба — лише для навчальної демонстрації
            System.Diagnostics.Debug.WriteLine($"Finalized {GetType().Name} {Model}");
        }
    }
}
