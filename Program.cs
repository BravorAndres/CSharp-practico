using System;

namespace CSharpAplicacion1
{
    class VectorEnteros
    {
        private int[] vec;

        public VectorEnteros()
        {
            vec = new int[5];
        }

        public void Cargar()
        {
            for (int f = 0; f < vec.Length; f++)
            {
                vec[f] = f * 2;
            }
        }

        public void Imprimir()
        {
            for (int f = 0; f < vec.Length; f++)
            {
                Console.Write(vec[f] + " ");
            }
            Console.WriteLine();
        }

        public static VectorEnteros operator +(VectorEnteros v1, VectorEnteros v2)
        {
            VectorEnteros su = new VectorEnteros();
            for (int f = 0; f < su.vec.Length; f++)
            {
                su.vec[f] = v1.vec[f] + v2.vec[f];
            }
            return su;
        }
    }

    public struct valorFinanciero
    {
        public int partReal { get; set; }
        public double partDecimal { get; set; }


        //Sobrecarga de operadores numericos tambien se puede con < > pero con igual(==) hay que tener algo de cuidado
        public static valorFinanciero operator +(valorFinanciero v1, valorFinanciero v2)
        {
            return new valorFinanciero
            {
                partReal = v1.partReal + v2.partReal,
                partDecimal = v1.partDecimal + v2.partDecimal
            };
        }

        public static valorFinanciero operator -(valorFinanciero v1, valorFinanciero v2)
        {
            return new valorFinanciero
            {
                partReal = v1.partReal - v2.partReal,
                partDecimal = v1.partDecimal - v2.partDecimal
            };
        }

        public static valorFinanciero operator *(valorFinanciero v1, valorFinanciero v2)
        {
            return new valorFinanciero
            {
                partReal = v1.partReal * v2.partReal,
                partDecimal = v1.partDecimal * v2.partDecimal
            };
        }

        public static valorFinanciero operator /(valorFinanciero v1, valorFinanciero v2)
        {
            return new valorFinanciero
            {
                partReal = v1.partReal / v2.partReal,
                partDecimal = v1.partDecimal / v2.partDecimal
            };
        }

        //Procesos para ==

        //primero se crea un metodo Equals habitual
        public bool Equals(valorFinanciero other)
        {
            if(ReferenceEquals(other,null)) return false;//si otro es nulo
            if(ReferenceEquals(other,this)) return true;//si otro es el mismo objeto
            return (this.partDecimal==other.partDecimal && this.partReal==other.partReal);// si comparten valores
        }

        public override bool Equals(Object obj)//que es override???   resscribe un metodo de la calse padre. todas la clases tienen un padre
        {
            if(ReferenceEquals(obj,null)) return false;//si obj es nulo
            if(ReferenceEquals(obj,this)) return true;//si obj es el mismo objeto

            return Equals(obj as valorFinanciero);// struct no es un objeto por eso no compila
        }

        public override int GetHashCode()//?
        {
            return base.GetHashCode();
        }

        public static bool operator ==(valorFinanciero v1,valorFinanciero v2)
        {
            return Equals(v1,v2);
        }

        public static bool operator !=(valorFinanciero v1,valorFinanciero v2)
        {
            return !Equals(v1,v2);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            VectorEnteros v1 = new VectorEnteros();
            VectorEnteros v2 = new VectorEnteros();
            v1.Cargar();
            v2.Cargar();
            VectorEnteros v3 = v1 + v2;

            valorFinanciero f1 = new valorFinanciero() { partReal = 234, partDecimal = 0.342 };
            valorFinanciero f2 = new valorFinanciero() { partReal = 343, partDecimal = 34.244 };
            valorFinanciero f3 = f1 + f2;
         //   Console.WriteLine(f3.partDecimal + " " + f3.partReal);

         //   partes p1 = new partes(12,134,"hello word!!");
         //   partes p2 = new partes(34,53,"hola mundo!!");

            /*** operador ?: forma compleaj de reemplazar if's****/
            string name = "andrew";
            Console.WriteLine(name == "andrew" ? "esto se escribe si la condicion es verdad": "esto se escribe si la condicon es falsa." + " se pueden hacer anidaciones");
            VectorEnteros obj1 = null;
            VectorEnteros obj2 = new VectorEnteros();
            Console.WriteLine(obj1 ?? obj2);//la expresion devolvera el primer objeto que no sea nulo

            
        
        }

    }
}

