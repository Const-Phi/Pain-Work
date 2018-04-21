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
        
        #region Operators
        
        public static Monome operator +(Monome arg1, Monome arg2) =>
            arg1.degree == arg2.degree ? 
                new Monome(arg1.factor + arg2.factor, arg1.degree) : 0; //что тут вставлять хрен его знает 
        
        public static Monome operator +(Monome arg1, double arg2) =>
            new Monome(arg1.factor + arg2, arg1.degree);

        public static Monome operator +(double arg1, Monome arg2) => 
            arg2 + arg1;
        
        public static Monome operator -(Monome arg1, Monome arg2) =>
            arg1.degree == arg2.degree ?
                new Monome(arg1.factor - arg2.factor, arg1.degree) : 0;
        
        public static Monome operator -(Monome arg1, double arg2) =>
            new Monome(arg1.factor - arg2, arg1.degree);

        public static Monome operator -(double arg1, Monome arg2) => 
            arg2 - arg1;
        
        public static Monome operator *(Monome arg1, Monome arg2) =>
             new Monome(arg1.factor * arg2.factor, arg1.degree + arg1.degree);
        
        public static Monome operator *(Monome arg1, double arg2) =>
             new Monome(arg1.factor * arg2, arg1.degree);

        public static Monome operator *(double arg1, Monome arg2) =>
            arg2 * arg1;
        
        public static Monome operator /(Monome arg1, Monome arg2) =>
            new Monome(arg1.factor / arg2.factor, arg1.degree - arg2.degree);

        public static Monome operator /(Monome arg1, double arg2) =>
            new Monome(arg1.factor / arg2, arg1.degree);
        
        public static Monome operator /(double arg1, Monome arg2) =>
            new Monome(arg1 / arg2.factor, arg2.degree * (-1)); //0 - arg2.degree         
        
        public static Monome operator ^(Monome arg1, double arg2) =>
            new Monome(arg1.factor, (int)(arg1.degree * arg2));
        
        #endregion
        
    }
}
