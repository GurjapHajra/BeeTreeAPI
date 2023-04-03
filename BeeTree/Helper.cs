
namespace BeeTree
{
    public class Helper
    {

        public char numToGen(int n)
        {
            if (n == 1)
            {
                return 'M';
            }else if (n == 2)
            {
                return 'F';
            }
            else
            {
                return 'N';
            }
        }

    }
}
