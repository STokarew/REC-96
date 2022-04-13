using System;

namespace REC_96
{
    sealed class Money
    {
        private int rub;
        private int kop;

        public Money(int rub, int kop)
        {
            Rub = rub;
            Kop = kop;
        }

        public int Rub { get; set; }

        public int Kop    
        {
            set
            {
                if (value > 100)
                {
                    throw new Exception("Больше 100 копеек не может быть");
                }
                else
                {
                    kop = value;
                }
            }
            get { return kop; }
}
public override string ToString()
            => $"{Rub},{Kop:00}";

        public static Money operator + (Money money1, Money money2)
        {
            return new Money((money1.Rub + money2.Rub + ((money1.Kop + money2.Kop) / 100)), (money1.Kop + money2.Kop) % 100);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = new Money(10, 52);
            var num2 = new Money(2, 90);
            Money sum = num1 + num2;
            Console.WriteLine($"{num1} {num2} Сумма: {sum}");

            var num3 = new Money(10, 50);
            var num4 = new Money(2, 90);
            Money sum34 = num3 + num4;
            Console.WriteLine($"{num3} {num4} Сумма: {sum34}");
        }
    }
}