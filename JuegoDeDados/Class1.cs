using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    class Nent
    {
        private int N;


        public Nent()
        {
            N =6;
        }
        public void Cargar(int num)
        {
            N = num;

        }
        public int Descargar()
        {
            return N;
        }
        public bool VerifPar()
        {
            int r;
            r = N % 2;
            return (r == 0);
        }


        public int Lanzar()
        {
            int i, d;
            Random r;
            r = new Random();
            N = 0;
            for (i = 1; i <= 5; i++)
            {
                d = r.Next(1, 7);
                N = N * 10 + d;
            }
            return N;

        }
        public bool VerifGrande()
        {
            bool b = true;
            int dr, d, a;
            a = N;
            dr = N % 10; N = N / 10;

            while ((b == true) && (N > 0))
            {
                d = N % 10;
                N = N / 10;
                if (d != dr)
                    b = false;
            }
            N = a;

            return b;
        }


        public bool verifDig(int db)
        {
            bool b;
            int a, d;
            b = false;
            a = N;
            while ((N > 0) && (b == false))
            {
                d = N % 10; N = N / 10;
                if (d == db)
                    b = true;
            }
            N = a;
            return b;
        }

        public void filtrar(ref Nent f)
        {
            int a, d;
            a = N;
            f.N = 0;
            while (N > 0)
            {
                d = N % 10; N = N / 10;
                if (!(f.verifDig(d)))
                {
                    f.N = f.N * 10 + d;
                }
            }
            N = a;
        }
        public int frec(int dig)
        {
            int d;
            d = 0;
            int a = N;
            int fr = 0;
            while (N > 0)
            {
                d = N % 10; N = N / 10;
                if (d == dig)
                {
                    fr++;
                }
            }
            N = a;
            return fr;
        }

        public int Ndigs()
        {
            int a = N;
            if (N == 0)
            {
                return 1;
            }
            else
            {
                int contador = 0;
                while (N != 0)
                {
                    N = N / 10;
                    contador++;
                }
                N = a;
                return contador;
            }
        }

        public bool Poker()
        {
            Nent f = new Nent();
            f.N = 0;
            bool B = false;
            this.filtrar(ref f);

            if (f.Ndigs() == 2)
            {
                int D1 = f.N % 10;
                f.N = f.N / 10;
                int D2 = f.N % 10;
                f.N = f.N / 10;

                if ((this.frec(D1) == 1) && (this.frec(D2) == 4))
                {
                    B = true;
                }
                else if ((this.frec(D1) == 4) && (this.frec(D2) == 1))
                {
                    B = true;
                }
            }

            return B;
        }

        public bool Par()
        {
            Nent f = new Nent();
            f.N = 0;
            int cont = 0;
            bool B = false;
            this.filtrar(ref f);

            if (f.Ndigs() == 4)
            {
                while (f.N > 0)
                {
                    int D = f.N % 10;
                    f.N = f.N / 10;
                    if ((this.frec(D) == 2))
                    {
                        cont++;
                    }
                    if (cont == 1)
                    {
                        B = true;
                    }
                }
            }
            return B;

        }
        public bool Trica()
        {
            Nent f = new Nent();
            int d = 0; int cont = 0;
            bool b = false;
            this.filtrar(ref f);
            if (f.Ndigs() == 3)
            {
                while (f.N > 0)
                {
                    d = f.N % 10;
                    f.N = f.N / 10;
                    if ((this.frec(d) == 3))
                    {
                        cont++;
                    }
                    if (cont == 1)
                    {
                        b = true;
                    }
                }
            }

            return b;
        }

        public bool Full()
        {
            Nent f = new Nent();
        bool b = false;
        int d = 0;
            int cont = 0;
          
            this.filtrar(ref f);
            if ((f.Ndigs() == 2))
            {
                while (f.N > 0)
                {
                    d = f.N % 10;
                    f.N = f.N / 10;
                    if ((this.frec(d) == 2) || ((this.frec(d) == 3)))
                    {
                        cont++;
                    }
                    if (cont == 2)
                    {
                        b = true;
                    } 

                }
            }
            return b;
            }
      
        public bool Escalera()
        {
            Nent f = new Nent();
            bool b = false;
            int ds = 0; int d = 0;
            {
                if (this.Ndigs() == 5)
                {
                    this.filtrar(ref f);
                    if ((f.Ndigs() == 5))
                    {
                        while (f.N > 0)
                        {
                            d = f.N % 10;
                            f.N = f.N / 10;
                            ds = ds + d;
                        }
                        if ((ds == 15) || (ds == 20))
                        {
                            b = true;
                        }
                    }
                }
            }
            return b;
        }
        public bool chanfle ()
        {
            Nent f = new Nent();
            bool b = false;
            this.filtrar(ref f); 
            if ((f.Ndigs () == 5) && (f.Escalera ()== false))
            {
                b = true;
            }
            return b;
        }
        public bool doblepar()
        {
            Nent f = new Nent();
            int cont = 0;
            bool b = false;
            this.filtrar(ref f);
            
            if ((f.Ndigs ()== 3))
            {
                while (f.N > 0)
                {
                    int d1 = f.N % 10;
                    f.N = f.N / 10;
                    if ((this.frec(d1) == 2))
                    {
                        cont++;
                    } 
                    if (cont == 2)
                    {
                        b = true;
                    }
                }
            }
            return b;
        }

    }
}
         
    
        

    




