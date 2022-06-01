using System;

namespace CSharpAplicacion1
{
    public class partes
    {
        public int a { get; set; }
        public int b { get; set; }
        public string str { get; set; }
        public bool[] arrelgoDesicion;

        public partes(int a,int b,string str)
        {
            this.a = a;
            this.b = b;
            this.str = str;
            arrelgoDesicion = new bool[10];
        }

        public void imprimir()
        {
            Console.WriteLine("a: "+a+" b: ",b," str: "+str);
            Console.WriteLine();
        }

        // con este metodo al hacer departe = partes se ejecutara este metodo
        public static implicit operator departes(partes d1)
        {
            return new departes(a, str + " " + b);
        }


        //con este metodo podemos regresar un atributo explicito de la clase, este  podria ser calculado
        public static explicit operator bool[](partes d1)
        {
            return d1.arrelgoDesicion;
        }
    }  
    
    public class departes
    {
        public int a { get; set; }
        public string str { get; set; }

        public departes(int a,string str)
        {
            this.a = a;
            this.str = str;
        }

        public void imprimir()
        {
            Console.WriteLine("imprimriendo: "+a+" str:"+str);
        }

        
    }

}