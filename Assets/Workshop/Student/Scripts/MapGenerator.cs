using System;
using UnityEngine;

namespace Workshop.Student
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };

        // 1. declare Players variable
        public GameObject[] playerPrefab;
        
        // 7. declare Exit variable 
        public GameObject exitPrefab;

        public void Start()
        {
            // 1. random player at the position <0, 0> map
            int playerIndex = UnityEngine.Random.Range(0, playerPrefab.Length);
            Instantiate(playerPrefab[playerIndex], 
                new Vector2(0, 0), 
                Quaternion.identity);
            
            // 2. create obstacles
            for (int posX = 0; posX < 5; posX++)
            {
                Instantiate(wallTiles[0], new Vector2(posX, 2), Quaternion.identity);
            }

            // 3. create floor
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    Instantiate(floorTiles[0], new Vector2(x,y), Quaternion.identity);
                }
            }

            // 4. create walls
            for (int y = -1; y < rows+1; y++)
            {
                for (int x = -1; x < columns+1; x++)
                {
                    if (x == -1 || x== columns || y == -1 || y ==rows)
                    {
                        Instantiate(wallTiles[0], new Vector2(x,y), Quaternion.identity);
                    }
                }
            }

            // 5. random foods
            int numberOfItems = UnityEngine.Random.Range(2, 4);
            for (int i = 0; i < numberOfItems; i++)
            {
                int x = UnityEngine.Random.Range(0, columns);
                int y = UnityEngine.Random.Range(0, rows);
                Instantiate(foodTiles[i], new Vector2(x,y), Quaternion.identity);
            }

            // 6. generate item along with the saveItemMap
            for (int y = 0; y < saveItemMap.GetLength(0); y++)
            {
                for (int x = 0; x < saveItemMap.GetLength(1); x++)
                {
                    string item = saveItemMap[x, y];
                    if (item != " ")
                    {
                        int prefabIndex = 0;
                        for (int i = 0; i < foodTiles.Length; i++)
                        {
                            if (foodTiles[i].name == item)
                            {
                                prefabIndex = i;
                                break;
                            }
                        }
                        GameObject itemPrefab = foodTiles[prefabIndex];
                        Instantiate(itemPrefab, new Vector2(x,y), Quaternion.identity);
                    }
                }
            }

            // 7. place exit
            Instantiate(exitPrefab, new Vector2(rows-1, columns-1), Quaternion.identity);

        }
    }

}