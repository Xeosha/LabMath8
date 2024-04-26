

while(true)
{
    Console.WriteLine("Введите слово: ");

    if (RecognizingAutomaton.IsWord(Console.ReadLine()))
        Console.WriteLine("+");
    else
        Console.WriteLine("-");

}




//public class RecognizingAutomaton
//{

//    private enum States
//    {
//        Start,
//        A,
//        AA,
//        B,
//        BB,
//        C,
//        CC,
//        D,
//        DD,
//        Final
//    }

//    // тут можно сделать States вместо int
//    private static int[,] matrix = new int[,]
//    {
//        {1, 2, 9, 1, 1, 1, 1, 1, 1, 9},
//        {2, 3, 3, 4, 9, 3, 3, 3, 3, 9},
//        {3, 5, 5, 5, 5, 6, 9, 5, 5, 9},
//        {4, 7, 7, 7, 7, 7, 7, 8, 9, 9}
//    };

//    public static bool IsWord(string word)
//    {
//        var state = States.Start;

//        for (int i = 0; i < word.Length && state != States.Final; i++)
//        {
//            var letter = word[i];


//            // можно вынести в отдельный массив private static char[] alphabet = { 'a', 'b', 'c', 'd' };
//            if (letter == 'a')
//                state = (States)matrix[0, (int)state];
//            else if (letter == 'b')
//                state = (States)matrix[1, (int)state];
//            else if (letter == 'c')
//                state = (States)matrix[2, (int)state];
//            else if (letter == 'd')
//                state = (States)matrix[3, (int)state];
//            else
//            {
//                Console.WriteLine("такой буквы не может быть в алфавите!");
//                state = States.Final;
//            }

//            Console.WriteLine($"Letter: {letter}; State: {state}");
//        }

//        return state != States.Final;
//    }
//}

public class RecognizingAutomaton
{
    private enum States
    {
        Start,
        A, AA,
        B, BB,
        C, CC,
        D, DD,
        Final
    }

    private static readonly char[] alphabet = { 'a', 'b', 'c', 'd' };

    private static readonly int[,] matrix = new int[,]
    {
        {1, 2, 9, 1, 1, 1, 1, 1, 1, 9},
        {2, 3, 3, 4, 9, 3, 3, 3, 3, 9},
        {3, 5, 5, 5, 5, 6, 9, 5, 5, 9},
        {4, 7, 7, 7, 7, 7, 7, 8, 9, 9}
    };

    private static States Transition(States currentState, char input)
    {
        int inputIndex = Array.IndexOf(alphabet, input);
        if (inputIndex == -1)
        {
            Console.WriteLine("такой буквы не может быть в алфавите!");
            return States.Final;
        }

        return (States)matrix[inputIndex, (int)currentState];
    }

    public static bool IsWord(string word)
    {
        States state = States.Start;

        foreach (char letter in word)
        {
            state = Transition(state, letter);
            Console.WriteLine($"Letter: {letter}; State: {state}");

            if (state == States.Final)
                break;
        }

        return state != States.Final;
    }
}
