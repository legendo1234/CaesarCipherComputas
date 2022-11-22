using System;
using System.IO;

namespace CaesarCipherComputas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Path to a text file containing the cypher.
            Console.WriteLine("Please enter a valid path to a text file (containing a text file name)");
            Console.WriteLine(@"[Example: C:\CaesarCipher.txt ]");
            string filePath = Convert.ToString(Console.ReadLine());
            Console.WriteLine("\n");

            if (!File.Exists(filePath)) //Talk about this
            {
                Console.WriteLine("File not found.");
                return;
            }

            //Defining the action we want to perform (decryption - d/encryption - e).
            Console.WriteLine("Do you want to decrypt or encrypt the cipher? (d - decrypt | e - encrypt)");
            char action = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("\n");

            //Checking if proper action has been entered.
            if (action != 'd' && action != 'e')
            {
                Console.WriteLine("You must enter one of the following values: 'd', 'e'.");
                return;
            }

            Console.WriteLine("Enter a shift (number of places letters need to be shifted):");
            int shift = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            ReadFile(filePath, action, shift);
        }

        public static void ReadFile(string filePath, char action, int shift)
        {

            //Reading a cipher from a text file.
            string cipher = System.IO.File.ReadAllText(filePath);
            string cipherAfterShift = "";

            //Separation of each letter of a cipher. ->>> this was hard talk about this
            char[] cipherExploded = cipher.ToCharArray();

            //Iteration through each letter of separated cipher.
            foreach (char letter in cipherExploded)
            {
                char letterShift = letter;
                if (Char.IsLetter(letter)) //If a character is anything other than a letter, it is skipped.
                {
                    //We are shifting a letter to the right/left as many times as it is defined with 'shift' variable.
                    for (int i = 0; i < shift; i++)
                    {
                        if (action == 'e')//Encryption
                        {
                            //If variable 'letterShift' has reached the end of an alphabet (it is equal to letter Z), it has 
                            //to go to the start of the alphabet (it is assigned a value of 'A'). If that is not the case,
                            //it will be shifted to the next letter in line. --> talk about this
                            if (letterShift == 'z')
                            {
                                letterShift = 'a';
                            }
                            else if (letterShift == 'Z')
                            {
                                letterShift = 'A';
                            }
                            else
                            {
                                letterShift++;
                            }
                        }
                        else if (action == 'd')//Decryption
                        {
                            //If variable 'letterShift' has reached the start of an alphabet (it is equal to letter A), it has 
                            //to go to the END of the alphabet (it is assigned a value of 'Z'). If that is not the case,
                            //it will be shifted to the previous in line.
                            if (letterShift == 'a')
                            {
                                letterShift = 'z';
                            }
                            else if (letterShift == 'A')
                            {
                                letterShift = 'Z';
                            }
                            else
                            {
                                letterShift--;
                            }

                        }

                    }
                }
                //Adding each of the shifted letters to a variable 'cipherAfterShift'. -->> this was hard talk about it
                cipherAfterShift += letterShift;
            }
            if (action == 'd')
            {
                Console.WriteLine("Decrypted text:");
            }
            else if (action == 'e')
            {
                Console.WriteLine("Encrypted text:");
            }
            //Cipher after each letter has been shifted.
            Console.WriteLine(cipherAfterShift);
        }
    }
}
