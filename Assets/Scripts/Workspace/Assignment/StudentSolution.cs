using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            string[] ironManSuit = new string[2];
            ironManSuit[0] = "Mark I";
            ironManSuit[1] = "Mark II";
            string tonyStarkWear = ironManSuit[0];
            Debug.Log($"TonyStark Wear: {tonyStarkWear}");
            Debug.Log($"Room size: {ironManSuit.Length}");
            Debug.Log(ironManSuit[0]);
            Debug.Log(ironManSuit[1]);
        }

        public void LCT02_ArrayInitialize()
        {
            string[] spiderMan = {
                "Classic SpiderMan", // 0
                "Black Suit", // 1
                "Iron Spider Suit" // 2
            };
            int size = spiderMan.Length;
            Debug.Log($"Room size: {size}");
            Debug.Log(spiderMan[0]);
            Debug.Log(spiderMan[1]);
            Debug.Log(spiderMan[2]);
            
            string[] batman = {
                "Classic BatMan",
                "White bat"
            };
            int size2 = batman.Length;
            Debug.Log($"Room size: {size2}");
            Debug.Log(batman[0]);
            Debug.Log(batman[1]);
        }

        public void LCT03_SyntaxLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("<10 : " + i);
            }
            Debug.Log("===");
            for (int i = 1; i <= 10; i++)
            {
                Debug.Log("<=10 : " + i);   
            }
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            for (int i = 0; i < ironManSuitNames.Length; i++)
            {
                Debug.Log(ironManSuitNames[i]);
            }
            Debug.Log("===");
            for (int i = 0; i < ironManSuitNames.Length; i+=2)
            {
                Debug.Log(ironManSuitNames[i]);
            }
        }

        public void LCT05_Syntax2DArray()
        {
            int[,] my2DArray;
            my2DArray = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };
            Debug.Log($"my2DArray[0, 0] = {my2DArray[0, 0]}");
            Debug.Log($"my2DArray[0, 1] = {my2DArray[0, 1]}");
            Debug.Log($"my2DArray[1, 0] = {my2DArray[1, 0]}");
            Debug.Log($"my2DArray[1, 1] = {my2DArray[1, 1]}");
            Debug.Log("After change value");
            my2DArray[0, 1] = 6;
            my2DArray[1, 1] = 8;
            Debug.Log($"my2DArray[0, 1] = {my2DArray[0, 1]}");
            Debug.Log($"my2DArray[1, 1] = {my2DArray[1, 1]}");
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            int row = my2DArray.GetLength(0);
            int column = my2DArray.GetLength(1);
            Debug.Log($"rows = {row}");
            Debug.Log($"cols = {column}");
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                string row = "";
                for (int j = 0; j < columns; j++)
                {
                    row += "*";
                }
                Debug.Log(row);
            }
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            if (items == null || items.Length == 0) return; 
            int randomIndex = Random.Range(0, items.Length);
            GameObject droppedItem = Instantiate(items[randomIndex]);
            string itemName = droppedItem.name.Replace("(Clone)", "");
            Debug.Log("Got item: " + itemName);
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int randIndex = Random.Range(0, floorTiles.Length);
                    GameObject tile = Instantiate(floorTiles[randIndex], new Vector2(x, y), transform.rotation);
                    tile.name = $"[{x}:{y}]";
                    Debug.Log(tile.name);
                }
            }
        }

        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                    {
                        GameObject w = Instantiate(wall, new Vector2(x, y), transform.rotation);
                        w.name = $"[{x}:{y}]";
                    }
                }
            }
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            enemyHP[0] = Mathf.Max(0, enemyHP[0] - damage);
            Debug.Log($"FirstEnemy hp :{enemyHP[0]}");

            int lastIndex = enemyHP.Length - 1;
            enemyHP[lastIndex] = Mathf.Max(0, enemyHP[lastIndex] - damage);
            Debug.Log($"LastEnemy hp :{enemyHP[lastIndex]}");

            enemyHP[target] = Mathf.Max(0, enemyHP[target] - damage);
            Debug.Log($"TargetEnemy {target} hp :{enemyHP[target]}");
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Debug.Log(i);
            }
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            int i = 0;
            while (i < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[i]);
                i++;
            }

            Debug.Log("===");

            int j = 0;
            while (j < ironManSuitNames.Length)
            {
                Debug.Log(ironManSuitNames[j]);
                j += 2;
            }
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            heroHPs[0] += heal;
            Debug.Log($"FirstHero hp :{heroHPs[0]}");

            int lastIndex = heroHPs.Length - 1;
            heroHPs[lastIndex] += heal;
            Debug.Log($"LastHero hp :{heroHPs[lastIndex]}");

            heroHPs[targetIndex] += heal;
            Debug.Log($"TargetHero {targetIndex} hp :{heroHPs[targetIndex]}");
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            int index = Random.Range(0, dialogues.Length);
            Debug.Log(dialogues[index]);
        }

        public void AS09_MultiplicationTable(int n)
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{n}x{i}={n * i}");
            }
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            int i = 0, sum = 0;
            while (i <= n)
            {
                sum += i;
                i++;
            }
            Debug.Log($"ผลรวมของ n จาก 0 ถึง {n} คือ {sum}");
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            for (int i = 0; i < enemyHPs.Length; i++)
            {
                Vector2 pos = new Vector2(i + 1, 0);
                Instantiate(enemyPrefab, pos, transform.rotation);
                Debug.Log($"new enemy at position x = {i + 1}");
            }
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            float timer = 0f;
            while (timer < CountTime)
            {
                timer += Time.deltaTime;
                yield return null;
                Debug.Log($"timer : {timer.ToString("F2")}");
            }
            Debug.Log($"End timer : {CountTime.ToString("F2")}");
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                sum += matrix[row, i];
            }
            Debug.Log(sum);
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, column];
            }
            Debug.Log(sum);
        }

        public void AS15_MakeTheTriangle(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                string line = "";
                for (int j = 0; j < i; j++)
                {
                    line += "*";
                }
                Debug.Log(line);
            }
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            for (int i = 1; i <= 12; i++)
            {
                string row = $"2 x {i} = {2 * i}\t3 x {i} = {3 * i}\t4 x {i} = {4 * i}";
                Debug.Log(row);
            }
        }

        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            bool isEmpty = false;
            if (row >= 0 && row < 3 && column >= 0 && column < 3)
            {
                string cellValue = board[row, column];
                isEmpty = cellValue == "_" || cellValue == " ";
            }

            if (row < 0 || row > 2 || column < 0 || column > 2 || !isEmpty)
            {
                PrintBoard(board);
                Debug.Log(">> Invalid move");
                return;
            }
            board[row, column] = playerTurn;

            if (CheckWin(board, playerTurn))
            {
                PrintBoard(board);
                Debug.Log($">> {playerTurn} wins!");
                return;
            }

            if (IsBoardFull(board))
            {
                PrintBoard(board);
                Debug.Log(">> Draw");
                return;
            }

            PrintBoard(board);
            Debug.Log(">> Continue");
        }

        private bool CheckWin(string[,] board, string player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsCellEqual(board[i, 0], player) && 
                    IsCellEqual(board[i, 1], player) && 
                    IsCellEqual(board[i, 2], player))
                    return true;
            }

            for (int j = 0; j < 3; j++)
            {
                if (IsCellEqual(board[0, j], player) && 
                    IsCellEqual(board[1, j], player) && 
                    IsCellEqual(board[2, j], player))
                    return true;
            }

            if (IsCellEqual(board[0, 0], player) && 
                IsCellEqual(board[1, 1], player) && 
                IsCellEqual(board[2, 2], player))
                return true;

            if (IsCellEqual(board[0, 2], player) && 
                IsCellEqual(board[1, 1], player) && 
                IsCellEqual(board[2, 0], player))
                return true;

            return false;
        }

        private bool IsCellEqual(string cellValue, string player)
        {
            return cellValue == player || 
                   (player == "X" && cellValue == "X") || 
                   (player == "O" && cellValue == "O");
        }

        private bool IsBoardFull(string[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    string cellValue = board[i, j];
                    if (cellValue == "_" || cellValue == " ")
                        return false;
                }
            }
            return true;
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
        #endregion
    }

}
