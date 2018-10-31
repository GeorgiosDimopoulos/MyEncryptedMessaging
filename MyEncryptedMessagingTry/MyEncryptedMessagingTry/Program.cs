using System;

namespace MyEncryptedMessagingTry
{
    class Program
    {
        static void Main()
        {
            try
            {
                string madeText = "Hi this message is the normal one";
                string encryptedText = "";

                // we separate the time in the hour and the minute
                var nowHour = DateTime.Now.Hour;
                var nowMinute = DateTime.Now.Minute;
                Console.WriteLine("Time now: " + nowHour + ":" + nowMinute);

                // we separate the digits of the time, hour and minute each
                int hourFirstDigit = nowHour / 10;
                int hourSecondDigit = nowHour % 10;
                int minuteFirstDigit = nowMinute/ 10;
                int minuteSecondDigit = nowMinute % 10;

                Console.WriteLine("Result after split: " + hourFirstDigit + "" + hourSecondDigit + ":" + minuteFirstDigit + "" + minuteSecondDigit);

                int firstResult = hourFirstDigit + hourSecondDigit + minuteFirstDigit + minuteSecondDigit;
                Console.WriteLine("First sum: " + firstResult);

                int nowResultFirstDigit = firstResult / 10;
                int nowResultSecondDigit = firstResult % 10;
                int finalResult = nowResultFirstDigit + nowResultSecondDigit;
                Console.WriteLine("Final sum: " + finalResult);

                char[] stringArray = madeText.ToCharArray();
                int i = 0;
                foreach (char letter in stringArray)
                {
                    int tempLetterNumber = letter; // letter as number in ASCII                    
                    char tempLetter = Convert.ToChar(tempLetterNumber + firstResult);
                    stringArray[i++]= tempLetter;
                }
                string finalString = new string(stringArray);
                Console.WriteLine("Final result: " + finalString);

                Console.WriteLine("Press 1 for my example! \nPress 2 for your own message. \nFor exit press 0");
                var choice = Console.ReadLine();
                while (true)
                {
                    if (choice != null)
                    {
                        int intChoice = int.Parse(choice);
                        if (intChoice == 1)
                        {
                            Console.WriteLine("My premade text is: " + madeText);
                            Console.WriteLine("My encrypted result of text is: " + encryptedText);
                        }
                        if (intChoice == 2)
                        {

                        }
                        if (intChoice == 0)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
        }

        public void EncryptionProcess(int addedNumber,char []tempArray)
        {

        }
        public void DecryptionProcess(int addedNumber, char[] tempArray)
        {

        }
    }
}
