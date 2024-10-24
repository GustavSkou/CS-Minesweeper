class Player {
    public int[] Input()
    {
        Dictionary<char,int> keyCharNumberPairs = new Dictionary<char, int>
        {
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},

        };
        var keyInput = Console.ReadKey();

        int number = keyCharNumberPairs[keyInput.KeyChar];

        /*switch (keyInput.KeyChar)
        {
            case '0':
            break;
            case '1':
            break;
            case '2':
            break;
            case '3':
            break;
            case '4':
            break;
            case '5':
            break;
            case '6':
            break;
            case '7':
            break;
            case '8':
            break;
            case '9':
            break;
            
            default:
        }*/

        int[] input;
        return input
    }
}