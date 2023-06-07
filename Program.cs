using static System.Console;
using static System.Linq.Enumerable;

internal class Program
{
    static void Main()
    {
        string[] rl = ReadLine().Split( ' ' );
        int N = int.Parse( rl[0] );
        int K = int.Parse( rl[1] );
        ushort o = 0;
        Cus[] c = new Cus[N];

        foreach( int i in Range( 0, N ) ) {
            c[i] = new Cus( byte.Parse( ReadLine() ) );
        }
        foreach( int i in Range( 0, K ) ) {
            rl = ReadLine().Split( ' ' );

            int j = int.Parse( rl[0] ) - 1;

            if( rl[1] == "A" ) {
                o++;
                WriteLine( c[j].Price );
            } else if( c[j].Age < 20 && ( rl[1] == "alcohol" || rl[1] == "0" ) ) {
                continue;
            } else if( c[j].Age < 20 ) {
                c[j].Order( uint.Parse( rl[2] ) );
            } else if( rl[1] == "0" ) {
                c[j].Order( "alcohol", 500 );
            } else {
                c[j].Order( rl[1], uint.Parse( rl[2] ) );
            }
        }
        WriteLine( o );
        return;
    }

    class CusB
    {
        public byte Age { get; set; }
        public uint Price { get; set; }

        public CusB( byte age )
        {
            Age = age;
            Price = 0;
        }

        public void Order( uint price )
        {
            Price += price;
            return;
        }
    }

    class Cus : CusB
    {
        bool alc = false;

        public Cus( byte age ) : base( age ) { }

        public void Order( string kind, uint price )
        {
            if( kind == "alcohol" ) {
                alc = true;
            }
            if( alc == true && kind == "food" ) {
                price -= 200;
            }
            Price += price;
            return;
        }
    }
}