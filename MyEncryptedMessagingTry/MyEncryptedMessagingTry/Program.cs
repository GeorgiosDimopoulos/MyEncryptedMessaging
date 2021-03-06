using System;

namespace MyEncryptedMessagingTry
{
    class Program
    {
        protected static string madeText;
        protected static int firstResult, finalResult;
        protected static char []_alphabet;

        static void Main()
        {
            try
            {
                _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // three times beacause of index-out-of-bounds exception
                //var alphabetSize = _alphabet.Length;
                while (true)
                {
                    Console.WriteLine("\nPress 1 for my example! \nPress 2 for your own message!\nFor exit press 0");
                    var choice = Console.ReadLine();
                    if (choice != null)
                    {
                        int intChoice = int.Parse(choice);
                        if (intChoice == 1)
                        {
                            Console.WriteLine("\n1. The following is my example and my given text is:");
                            madeText = "Hi this text is an example";
                            Console.WriteLine(madeText);
                            Console.WriteLine("\n2. Now we will take the exact time and take the sum of its digits");
                            int convertedTime = ConvertingTime();
                            Console.WriteLine("\n3. Final sum of time digits (the two previous digits added, if the sum was bigger than 9): " + convertedTime);

                            var encryptedText = EncryptionProcess(madeText, convertedTime);
                            Console.WriteLine("\n4. Final result of encrypted text: " + encryptedText);

                            Console.WriteLine("\n5. Original result (dencrypted text): " + DecryptionProcess(encryptedText, convertedTime));
                        }
                        else if (intChoice == 2)
                        {
                            Console.WriteLine("\n1. Give your own text please: ");
                            string usersText = Console.ReadLine();
                            Console.WriteLine("\n2. Now we will take the exact time and take the sum of its digits");
                            int convertedTime = ConvertingTime();
                            Console.WriteLine("\n3. Final sum of time digits (the two previous digits added): " + convertedTime);

                            var encryptedText = EncryptionProcess(usersText, convertedTime);
                            Console.WriteLine("\n4. Final result of encrypted text: " + encryptedText);

                            Console.WriteLine("\n5. Original result (dencrypted text): " + DecryptionProcess(encryptedText, convertedTime));
                        }
                        else if (intChoice == 0)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
        }

        public static int ConvertingTime()
        {
            try
            {
                // we separate the time in the hour and the minute
                var nowHour = DateTime.Now.Hour;
                var nowMinute = DateTime.Now.Minute;
                Console.WriteLine("Time now: " + nowHour + ":" + nowMinute);

                // we separate the digits of the time, hour and minute each
                int hourFirstDigit = nowHour / 10;
                int hourSecondDigit = nowHour % 10;
                int minuteFirstDigit = nowMinute / 10;
                int minuteSecondDigit = nowMinute % 10;

                Console.WriteLine("Result after separate the digits of time: " + hourFirstDigit + " " + hourSecondDigit + " : " + minuteFirstDigit + " " + minuteSecondDigit);

                firstResult = hourFirstDigit + hourSecondDigit + minuteFirstDigit + minuteSecondDigit;
                Console.WriteLine("First sum of digits (all digits added): " + firstResult);

                int nowResultFirstDigit = firstResult / 10;
                int nowResultSecondDigit = firstResult % 10;
                finalResult = nowResultFirstDigit + nowResultSecondDigit;                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);                
            }
            return finalResult;
        }

        public static string EncryptionProcess(string array,int number)
        {
            string finalString = null;
            try
            {
                char[] stringArray = array.ToUpper().ToCharArray();
                int i = 0;
                
                foreach (char letter in stringArray)
                {
                    if (Char.IsWhiteSpace(letter))
                    {
                        stringArray[i++] = ' ';
                    }
                    else
                    {
                        int tempLetterNumber = letter; // letter as number in ASCII   
                        tempLetterNumber -= 65;
                        int tempInt = tempLetterNumber + number;
                        stringArray[i++] = _alphabet[tempInt+26]; // without 26
                    }
                }
                finalString = new string(stringArray);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return finalString;
        }
        public static string DecryptionProcess(string array, int number)
        {
            string originalString = null;
            try
            {
                char[] stringArray = array.ToCharArray();
                int i = 0;
                foreach (char letter in stringArray)
                {
                    if (Char.IsWhiteSpace(letter))
                    {
                        stringArray[i++] = ' ';
                    }
                    else
                    {
                        int tempLetterNumber = letter; // letter as number in ASCII
                        tempLetterNumber -= 65;
                        int tempInt = tempLetterNumber - number + 52;
                        stringArray[i++] = _alphabet[tempInt];
                    }
                }
                originalString = new string(stringArray);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return originalString;
        }
    }
}
