using static lab2.Controllers.CalculatorController;

namespace lab2.Models
{
    public class Calculator
    {
        public Operators? Op { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }

        public String Operator
        {
            get
            {
                switch (Op)
                {
                    case Operators.ADD:
                        return "+";
                    case Operators.SUB:
                        return "-";
                    case Operators.MUL:
                        return "*";
                    case Operators.DIV:
                        return "/";
                    case Operators.POW:
                        return "^";
                    default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return Op != null && A != null && B != null;
        }

        public double Calculate()
        {
            switch (Op)
            {
                case Operators.ADD:
                    return (double)A + (double)B;
                case Operators.SUB:
                    return (double)B - (double)A;
                case Operators.MUL:
                    return (double)A * (double)B;
                case Operators.DIV:
                    return (double)A / (double)B;
                case Operators.POW:
                    return Math.Pow((double)A, (double)B);
                default:
                    return double.NaN;
            }
        }
    }
}
