using System;

namespace Algebra
{
    public class Monome
    {
        private double factor;
        private int degree;

        public double Factor
        {
            get { return factor; }
            set
            {
                if (double.IsNaN(value))
                    throw new Exception($"Значение {nameof(value)} не может быть пустым!");
                factor = value;
            }
        }

        public int Degree
        {
            get { return degree; }
            set
            {
                if (double.IsNaN(value))
                    throw new Exception($"Значение {nameof(value)} не может быть пустым!");
                degree = value;
            }
        }
        
        /// <summary>
       /// Конструктор монома
       /// </summary>
       /// <param name="factor">числовой множитель</param>
       /// <param name="degree">степень переменной</param>
        public Monome(double factor = 0, int degree = 0)
        {
            Degree = degree;
            Factor = factor;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="another">Копируемый объект</param>
        public Monome(Monome another)
        {
            Factor = another.factor;
            Degree = another.degree;
        }

        public override string ToString() => $"{factor}.x^{degree}";
 
        /// <summary>
        /// Неявное приведение типа <see cref="double"/> к типу <see cref="Monome"/>.
        /// </summary>
        /// <param name="value">Объект, приводимый к типу <see cref="Monome"/>.</param>
        /// <returns></returns>
        public static implicit operator Monome(double value) => new Monome(value);
        
        public static Monome operator +(Monome arg1, Monome arg2)
        {
            return new Monome();
        }
        
    }
}