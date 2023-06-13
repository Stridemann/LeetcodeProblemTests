using System.Diagnostics.Contracts;
using System.Text;

public class Sudoku_Solver
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 3, 4, 5 }, 5)]
    public void Test(int[] nums, int unique)
    {
        var s = new Solution();

        var board = new char[][]
        {
            new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };

        s.SolveSudoku(board);
    }
}

public class Solution
{
    public void SolveSudoku(char[][] board)
    {
        var initialState = new SudokuState(board);

        if (initialState.Solve())
        {
            for (var x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    board[x][y] = initialState.Cells[x, y].FinalNumber.ToString()[0];
                }
            }
        }
    }

    public class SudokuState
    {
        public SudokuState(char[][] data)
        {
            Cells = new CellState[9, 9];

            for (var y = 0; y < 9; y++)
            {
                for (var x = 0; x < 9; x++)
                {
                    var c = data[x][y];
                    var num = c - '0';

                    if (c == '.')
                        num = 0;
                    Cells[x, y] = new CellState((byte)num, x, y);
                }
            }
        }

        public SudokuState(CellState[,] cells)
        {
            Cells = cells;
        }

        public CellState[,] Cells { get; }

        public bool Solve()
        {
            bool solved;
            bool changed;

            do
            {
                changed = false;
                solved = true;

                for (var y = 0; y < 9; y++)
                {
                    for (var x = 0; x < 9; x++)
                    {
                        var cellData = Cells[x, y];

                        if (cellData.IsDone)
                        {
                            changed = RemovePossibleVertically(x, cellData.FinalNumber) || changed;
                            changed = RemovePossibleHorisontally(y, cellData.FinalNumber) || changed;
                            changed = RemovePossibleInSector(x, y, cellData.FinalNumber) || changed;
                        }

                        if (!Cells[x, y].IsDone)
                        {
                            solved = false;
                        }
                    }
                }
            } while (changed);

            return solved;
        }

        private bool RemovePossibleVertically(int x, byte value)
        {
            var shortInvVal = ~(1 << value);
            var changed = false;

            for (var y = 0; y < 9; y++)
            {
                changed = RemovePossibleInCell(x, y, shortInvVal) || changed;
            }

            return changed;
        }

        private bool RemovePossibleHorisontally(int y, byte value)
        {
            var shortInvVal = ~(1 << value);
            var changed = false;

            for (var x = 0; x < 9; x++)
            {
                changed = RemovePossibleInCell(x, y, shortInvVal) || changed;
            }

            return changed;
        }

        private bool RemovePossibleInSector(int x, int y, byte value)
        {
            var sectorStartX = x / 3 * 3;
            var sectorStartY = y / 3 * 3;
            var shortInvVal = ~(1 << value);
            var changed = false;

            for (var startX = sectorStartX; startX < sectorStartX + 3; startX++)
            {
                for (var startY = sectorStartY; startY < sectorStartY + 3; startY++)
                {
                    changed = RemovePossibleInCell(startX, startY, shortInvVal) || changed;
                }
            }

            return changed;
        }

        private bool RemovePossibleInCell(int x, int y, int shortInvVal)
        {
            var cellData = Cells[x, y];

            if (cellData.IsDone)
            {
                return false;
            }

            var oldPossible = cellData.PossibleNumbers;
            cellData.PossibleNumbers &= shortInvVal;

            if (cellData.PossibleNumbers != oldPossible)
            {
                cellData.PossibleAmount--;

                if (cellData.PossibleAmount == 1)
                {
                    cellData.UpdateFinalValue();
                }

                Cells[x, y] = cellData;

                return true;
            }

            return false;
        }
    }

    public struct CellState
    {
        private const int ALL_POSSIBLE = 0b00000000_00000000_00000011_11111110;

        public CellState(byte finalNumber, int x, int y) : this()
        {
            FinalNumber = finalNumber;

            if (finalNumber == 0)
            {
                PossibleNumbers = ALL_POSSIBLE;
                PossibleAmount = 9;
            }
            else
            {
                IsDone = true;
            }
        }

        public bool IsDone;
        public byte FinalNumber;
        public int PossibleNumbers = ALL_POSSIBLE;
        public int PossibleAmount;

        public void UpdateFinalValue()
        {
            for (byte i = 1; i <= 9; i++)
            {
                if ((PossibleNumbers & (1 << i)) != 0)
                {
                    ChoseValue(i);

                    return;
                }
            }
        }

        public void ChoseValue(byte i)
        {
            FinalNumber = i;
            IsDone = true;
        }
    }
}
