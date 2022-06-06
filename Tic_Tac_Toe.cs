/******************************************************************************
* Assignment: 01 Developer: Tic-Tac-Toe
* Author: Collin Squires
******************************************************************************/

/******************************************************************************
* Function: isXFirst()
* Purpose: This will randomly pick a number between 1 and 100 to determine if X
*   or O will go first.
******************************************************************************/

bool isXFirst()
{
    bool xFirst = false;
    Random rnd = new Random();
    int coinFlip = rnd.Next(1, 100);
    if (coinFlip < 50)
    {
        xFirst = true;
    }
    return xFirst;
}

/******************************************************************************
* Function: getBoard()
* Purpose: This will fill in the tic-tac-toe board with the initial values we
*   will see on screen when we first start playing the game.
******************************************************************************/

string[] getBoard()
{
    string[] board = new string[9];
    for (int i = 0; i < 9; i++)
    {
        int temporaryNumber = (i + 1);
        board[i] = temporaryNumber.ToString();
    }
    return board;
}

/******************************************************************************
* Function: displayBoard()
* Purpose: This will be called multiple times.  It shows the tic-tac-toe board
*   with not only the numbers of the empty cells but also the X's and O's that
*   were put on the board.
******************************************************************************/

void displayBoard(string[] board)
{
    Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
    Console.WriteLine("-+-+-");
    Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
    Console.WriteLine("-+-+-");
    Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
}

/******************************************************************************
* Function: winner()
* Purpose: All of the win conditions are listed here.  I feel like there's a
*   more effective way to program the win conditions but I'm not sure how to
*   do it so each combination of wins is listed.
******************************************************************************/

bool winner(string[] board)
{
    bool hasWon = false;
    if (board[0] == board[1] && board[1] == board[2])
    {
        hasWon = true;
    }
    else if (board[3] == board[4] && board[4] == board[5])
    {
        hasWon = true;
    }
    else if (board[6] == board[7] && board[7] == board[8])
    {
        hasWon = true;
    }
    else if (board[0] == board[3] && board[3] == board[6])
    {
        hasWon = true;
    }
    else if (board[1] == board[4] && board[4] == board[7])
    {
        hasWon = true;
    }
    else if (board[2] == board[5] && board[5] == board[8])
    {
        hasWon = true;
    }
    else if (board[0] == board[4] && board[4] == board[8])
    {
        hasWon = true;
    }
    else if (board[2] == board[4] && board[4] == board[6])
    {
        hasWon = true;
    }
    return hasWon;
}

/******************************************************************************
* Function: drawConditions
* Purpose: If the board fills up but there is no winner, this function will
*   check for it and declare a draw between X and O.
******************************************************************************/

bool drawConditions(bool winner, string[] board)
{
    bool draw = false;
    if (winner)
    {
        draw = false;
    }
    else
    {
        draw = true;
        for (int i = 0; i < 9; i++)
        {
            if (board[i] is not "X" && board[i] is not "O")
            {
                draw = false;
            }
        }
    }
    return draw;
}

/******************************************************************************
* Function: game()
* Purpose: This is probably the most complicated function here.  This is where
*   the values in the board are replaced by X's and O's.  It also checks to
*   make sure the player doesn't try to replace a slot that's already filled.
*   I also made sure to add code to determine if an input is a number or not
*   or if the number is in range.
******************************************************************************/

void game(string[] board)
{
    int turnNumber = 0;
    if (isXFirst())
    {
        Console.WriteLine("X will go first");
    }
    else
    {
        Console.WriteLine("O will go first");
        turnNumber = 1;
    }
    string stringCell = "";
    int cellNumber = 0;
    bool win = false;
    bool draw = false;
    bool invalid = true;
    do
    {
        displayBoard(board);
        if (turnNumber % 2 == 0)
        {
            do
            {
                Console.Write("X's turn to choose a square (1-9): ");
                try
                {
                    stringCell = Console.ReadLine();
                    cellNumber = Int32.Parse(stringCell);

                    if (board[cellNumber - 1] is "X" || board[cellNumber - 1] is "O")
                    {
                        invalid = true;
                        Console.WriteLine("That cell is already full you silly goose!");
                    }
                    else if (cellNumber < 1 || cellNumber > 9)
                    {
                        invalid = true;
                        Console.WriteLine("That's not a valid spot on the board.");
                    }
                    else
                    {
                        invalid = false;
                    }
                }

                catch
                {
                    Console.WriteLine("You can only enter a number.");
                    invalid = true;
                }
            }
            while (invalid);
            board[cellNumber - 1] = "X";
        }
        else
        {
            do
            {
                Console.Write("O's turn to choose a square (1-9): ");
                try
                {
                    stringCell = Console.ReadLine();
                    cellNumber = Int32.Parse(stringCell);

                    if (board[cellNumber - 1] is "X" || board[cellNumber - 1] is "O")
                    {
                        invalid = true;
                        Console.WriteLine("That cell is already full you silly goose!");
                    }
                    else if (cellNumber < 1 || cellNumber > 9)
                    {
                        invalid = true;
                        Console.WriteLine("That's not a valid spot on the board.");
                    }
                    else
                    {
                        invalid = false;
                    }
                }
                catch
                {
                    Console.WriteLine("You can only enter a number.");
                    invalid = true;
                }
            }
            while (invalid);
            board[cellNumber - 1] = "O";
        }
        turnNumber ++;
        win = winner(board);
        draw = drawConditions(win, board);
    }
    while (!win && !draw);
    displayBoard(board);
    if (win)
    {
        Console.WriteLine("Congrats! You win!");
    }
    else
    {
        Console.WriteLine("Uh, y'all tied...");
    }
}

/******************************************************************************
* Function: main()
* Purpose: Finally, we have main().  It's really just the function that runs
*   everything else.
******************************************************************************/

int main()
{
    string[] boardSlots = getBoard();
    game(boardSlots);

    return 0;
}

main();