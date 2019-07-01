using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Problems
{
    public class math_equation_compute_stack_solution
    {

        public double Compute(string equation)
        {
            Stack<double> stackNumbers = new Stack<double>();
            Stack<Operator> stackOperator = new Stack<Operator>();
            bool isNextNumber = true;
            int index = 0;
            while(index < equation.Length)
            {
                double operand = 0d;
                Operator op = Operator.Blank;
                if(isNextNumber)
                {
                    index = getNextOperand(equation, index, out operand);
                    stackNumbers.Push(operand);
                }
                else
                {
                    index = getNextOperator(equation, index, out op);

                    if(stackOperator.Count == 0)
                    {
                        stackOperator.Push(op);
                    }
                    else
                    {
                        if ((op == Operator.Multiply || op == Operator.Devide) &&
    (stackOperator.Peek() == Operator.Add || stackOperator.Peek() == Operator.Subtract))
                        {
                            stackOperator.Push(op);
                        }
                        else
                        {
                            if (stackNumbers.Count >= 2 && stackOperator.Count > 0)
                            {
                                Collapse(stackOperator, stackNumbers, op);
                            }
                        }
                    }
                }
                isNextNumber = !isNextNumber;
            }

            return stackNumbers.Pop();
        }

        private void Collapse(Stack<Operator> stackOp, Stack<double> stackNum, Operator curr)
        {
            var condition = (curr == Operator.Multiply || curr == Operator.Devide) &&
                        (stackOp.Peek() == Operator.Add || stackOp.Peek() == Operator.Subtract);
            while (!condition)
            {                
                var op1 = stackNum.Pop();
                var op2 = stackNum.Pop();

                var op = stackOp.Pop();

                var result = Calculate(op1, op2, op);

                stackNum.Push(result);

                condition = (curr == Operator.Multiply || curr == Operator.Devide) &&
                        (stackOp.Peek() == Operator.Add || stackOp.Peek() == Operator.Subtract);

                if (stackNum.Count < 2) condition = true;
                if (stackOp.Count == 0) condition = true;
            }
        }

        private double Calculate(double op1, double op2, Operator op)
        {
            double result = 0d;
            switch (op)
            {
                case Operator.Add:
                    result = op1 + op2;
                    break;
                case Operator.Subtract:
                    result = op1 - op2;
                    break;
                case Operator.Multiply:
                    result = op1 * op2;
                    break;
                case Operator.Devide:
                    result = op1 / op2;
                    break;
            }
            return result;
        }

        private int getNextOperand(string equation, int index, out double val)
        {
            val = double.MinValue;
            string num = "";
            while(index < equation.Length)
            {
                var charAti = equation[index];
                if(char.IsNumber(charAti))
                {
                    num = num + charAti.ToString();
                    index++;
                }
                else
                {
                    val = Convert.ToDouble(num);
                    break;
                }
            }
            if(val == double.MinValue) val = Convert.ToDouble(num);
            return index;
        }
        private int getNextOperator(string equation, int index, out Operator op)
        {
            op = Operator.Blank;            

            while (index < equation.Length)
            {
                var charAti = equation[index];

                if (charAti == ' ') { index++; continue; }

                if (IsOperator(charAti))
                {
                    op = parseOperator(charAti);
                    index++;
                    break;
                }                
            }
            return index;
        }

        private bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/';
        }

        private Operator parseOperator(char op)
        {
            switch (op)
            {
                case '+': return Operator.Add;
                case '-': return Operator.Subtract;
                case '*': return Operator.Multiply;
                case '/': return Operator.Devide;
            }
            return Operator.Blank;
        }
    }

    public class math_equation_compute
    {
        /*
         * you are give a equation as input e.g. 2*3+5/6*3+15
         * compute result
         */

       

        public double Compute(string equation)
        {
            var termService = new Term();
            var terms = termService.ParseString(equation);

            double result = 0;
            Term processing = null;
            Term current = null;
            Term next = null;

            for (int i = 0; i < terms.Count; i++)
            {
                current = terms[i];
                next = i + 1 < terms.Count ? terms[i + 1] : null;

                processing = CollapseTerm(processing, current);

                if(next == null || next.Op == Operator.Add || next.Op == Operator.Subtract)
                {
                    result = Calculate(result, processing.Value, processing.Op);
                    processing = null;
                }
            }
            return result;
        }

        private Term CollapseTerm(Term primary, Term secondary)
        {
            if (primary == null) return secondary;
            if (secondary == null) return primary;

            double value = Calculate(primary.Value, secondary.Value, secondary.Op);

            primary = new Term(value, primary.Op);

            return primary;
        }

        private double Calculate(double op1, double op2, Operator op)
        {
            double result = 0d;
            switch(op)
            {
                case Operator.Add:
                    result = op1 + op2;
                    break;
                case Operator.Subtract:
                    result = op1 - op2;
                    break;
                case Operator.Multiply:
                    result = op1 * op2;
                    break;
                case Operator.Devide:
                    result = op1 / op2;
                    break;
            }
            return result;
        }
    }
    public enum Operator
    {
        Add,
        Subtract,
        Multiply,
        Devide,
        Blank
    }
    public class Term
    {
        public double Value { get; set; }
        public Operator Op { get; set; }
        public Term()
        {

        }
        public Term(double v, Operator op)
        {
            this.Value = v;
            this.Op = op;
        }

        public List<Term> ParseString(string equation)
        {
            /*
             * input: 3+4*5-6
             * should retunr {+,3},{+,4},{*,5},{-,6}
             */
            var retVal = new List<Term>();
            int index = 0;
            while(index < equation.Length)
            {

                var op = Operator.Blank;
                string num = "";
                while (index < equation.Length)
                {
                    var charAti = equation[index];
                    
                    

                    if (charAti == ' ') { index++; continue; }
                    if (index == 0 && char.IsNumber(charAti)) { op = Operator.Add; }

                    if (op == Operator.Blank)
                    {
                        op = parseOperator(charAti);
                        index++;
                        continue;
                    }
                    else
                    {
                        bool isOperator = IsOperator(charAti);
                        if (num == "" && isOperator) return null; // two operator in a row

                        if (!isOperator)
                        {
                            num = num + charAti;
                            index++;
                            continue;
                        }                            
                        else
                            break;
                    }
                    
                }

                var term = new Term(Convert.ToDouble(num), op);
                retVal.Add(term);
            }
            return retVal;
        }

        public bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/';
        }

        public Operator parseOperator(char op)
        {
            switch (op)
            {
                case '+': return Operator.Add;
                case '-': return Operator.Subtract;
                case '*': return Operator.Multiply;
                case '/': return Operator.Devide;
            }
            return Operator.Blank;
        }
    }
}