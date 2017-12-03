using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        enum Direction { up, right, left, down };

        static void Main(string[] args)
        {
            int width = 700; //700
            int height = 700; //700
            int count = 480000; //480000
            int[,] matrix = new int[width, height];

            matrix[width / 2, height / 2] = 1;
            int x = width / 2 - 1;
            int y = height / 2;
            int directionCount = 2;
            int helpDirectionCount = 0;
            bool secondTime = false;
            Direction direction = Direction.right;

            { //Creates first matrix
                for (int i = 1; i < count; i++)
                {
                    if (directionCount == helpDirectionCount)
                    {
                        switch (direction)
                        {
                            case Direction.up:
                                direction = Direction.left;
                                break;
                            case Direction.right:
                                direction = Direction.up;
                                break;
                            case Direction.left:
                                direction = Direction.down;
                                break;
                            case Direction.down:
                                direction = Direction.right;
                                break;
                            default: throw new ArgumentOutOfRangeException();
                        }


                        if (secondTime == true)
                        {
                            helpDirectionCount = 2;
                            directionCount++;
                            secondTime = false;
                        }
                        else
                        {
                            secondTime = true;
                            helpDirectionCount = 2;
                        }
                    }
                    else helpDirectionCount++;

                    if (direction == Direction.right) x += 1;
                    else if (direction == Direction.up) y -= 1;
                    else if (direction == Direction.left) x -= 1;
                    else if (direction == Direction.down) y += 1;


                    matrix[x, y] = i;
                }
            }

            //for (int i = 0; i < height; i++)
            //{
            //    for (int l = 0; l < width; l++)
            //    {
            //        Console.Write("{0}  ", matrix[l, i]);
            //    }
            //    Console.Write("\n");
            //}

            Console.Write("#1: From which square?: ");
            int input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (input == matrix[i, j])
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }
            Console.Write("The shortest Path is: {0} \n\n", (Math.Abs(width / 2 - x) + Math.Abs(height / 2 - y))); 

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            matrix[width / 2, height / 2] = 1;
            x = width / 2 - 1;
            y = height / 2;
            directionCount = 2;
            helpDirectionCount = 0;
            secondTime = false;
            direction = Direction.right;

            int lastSum = 0;

            Console.Write("#2: Bigger than which input?: ");
            int input2 = Convert.ToInt32(Console.ReadLine());

            { //Creates second matrix
                for (int i = 1; lastSum < input2 ; i++)
                {
                    if (directionCount == helpDirectionCount)
                    {
                        switch (direction)
                        {
                            case Direction.up:
                                direction = Direction.left;
                                break;
                            case Direction.right:
                                direction = Direction.up;
                                break;
                            case Direction.left:
                                direction = Direction.down;
                                break;
                            case Direction.down:
                                direction = Direction.right;
                                break;
                            default: throw new ArgumentOutOfRangeException();
                        }


                        if (secondTime == true)
                        {
                            helpDirectionCount = 2;
                            directionCount++;
                            secondTime = false;
                        }
                        else
                        {
                            secondTime = true;
                            helpDirectionCount = 2;
                        }
                    }
                    else helpDirectionCount++;

                    if (direction == Direction.right) x += 1;
                    else if (direction == Direction.up) y -= 1;
                    else if (direction == Direction.left) x -= 1;
                    else if (direction == Direction.down) y += 1;

                    int sum = 0;
                    sum = matrix[x - 1, y] + matrix[x + 1, y] + matrix[x, y - 1] + matrix[x, y + 1] + matrix[x - 1, y - 1] + matrix[x - 1, y + 1] + matrix[x + 1, y - 1] + matrix[x + 1, y + 1];
                    matrix[x, y] = (sum == 0 ? 1 : sum);
                    lastSum = matrix[x, y];
                }
            }

            //for (int i = 0; i < height; i++)
            //{
            //    for (int l = 0; l < width; l++)
            //    {
            //        Console.Write("{0}  ", matrix[l, i]);
            //    }
            //    Console.Write("\n");
            //}

            Console.Write("The awnser is: {0} ", lastSum);

            Console.ReadKey();
        }
    }
}
